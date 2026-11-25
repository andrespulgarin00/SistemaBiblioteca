using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        
        public void AgregarPrestamo(Prestamo prestamo)
        {
            if (prestamos.Any(p => p.Id == prestamo.Id))
            {
                Console.WriteLine($"Ya existe un préstamo con ID {prestamo.Id}.");
                return;
            }
            prestamos.Add(prestamo);
        }

        public bool EliminarPrestamo(int id)
        {
            Prestamo? prestamo = BuscarPorId(id);
            return prestamo != null && prestamos.Remove(prestamo);
        }

        public bool DevolverPrestamo(int id)
        {
            Prestamo? prestamo = BuscarPorId(id);
            if (prestamo == null || prestamo.Estado == EstadoPrestamo.Devuelto) return false;
            prestamo.Devolver();
            return true;
        }

        public List<Prestamo> ObtenerTodos()
        {
            ActualizarEstados();
            return new List<Prestamo>(prestamos);
        }

      
        public Prestamo? BuscarPorId(int id) =>
            prestamos.FirstOrDefault(p => p.Id == id);

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            ActualizarEstados();
            return prestamos.Where(p => p.Estado == estado).ToList();
        }


        public List<Prestamo> OrdenarPorFechaLimite() =>
            prestamos.OrderBy(p => p.FechaLimite).ToList();

        
        public int TotalPrestamos() => prestamos.Count;

        public int PrestamosActivos()
        {
            ActualizarEstados();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        }

        public int PrestamosVencidos()
        {
            ActualizarEstados();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido);
        }

        public int PrestamosDevueltos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public double PromedioDiasPrestamo() =>
            prestamos.Count == 0 ? 0 : prestamos.Average(p => p.DiasPrestamo);

        public void MostrarKpis()
        {
            Console.WriteLine($"Total de préstamos: {TotalPrestamos()}");
            Console.WriteLine($"Activos: {PrestamosActivos()} | Vencidos: {PrestamosVencidos()} | Devueltos: {PrestamosDevueltos()}");
            Console.WriteLine($"Promedio de días de préstamo: {PromedioDiasPrestamo():F1}");
        }

       
        private void ActualizarEstados()
        {
            foreach (Prestamo p in prestamos)
                p.ActualizarEstado();
        }
    }
}
