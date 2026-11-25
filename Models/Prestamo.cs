namespace SistemaBiblioteca.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; private set; } = EstadoPrestamo.Activo;

        public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo, DateTime fechaLimite)
        {
            Id = id;
            Libro = libro;
            Usuario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            Libro.Disponible = false;
        }

        
        public double DiasPrestamo =>
            ((FechaDevolucion ?? DateTime.Now) - FechaPrestamo).TotalDays;

        public void Devolver()
        {
            FechaDevolucion = DateTime.Now;
            Estado = EstadoPrestamo.Devuelto;
            Libro.Disponible = true;
        }

        
        public void ActualizarEstado()
        {
            if (Estado == EstadoPrestamo.Activo && DateTime.Now > FechaLimite)
                Estado = EstadoPrestamo.Vencido;
        }

        public override string ToString() =>
            $"Préstamo #{Id} | {Libro.Titulo} -> {Usuario.Nombre} | " +
            $"Límite: {FechaLimite:yyyy-MM-dd} | {Estado}";
    }
}
