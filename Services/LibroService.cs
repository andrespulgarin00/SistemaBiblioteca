using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

       
        public void AgregarLibro(Libro libro)
        {
            if (libros.Any(l => l.Isbn == libro.Isbn))
            {
                Console.WriteLine($"Ya existe un libro con ISBN {libro.Isbn}.");
                return;
            }
            libros.Add(libro);
        }

        public bool EliminarLibro(string isbn)
        {
            Libro? libro = BuscarPorIsbn(isbn);
            return libro != null && libros.Remove(libro);
        }

        public List<Libro> ObtenerTodos() => new List<Libro>(libros);

        
        public Libro? BuscarPorIsbn(string isbn) =>
            libros.FirstOrDefault(l => l.Isbn == isbn);

        public List<Libro> BuscarPorTitulo(string titulo) =>
            libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Libro> BuscarPorAutor(string autor) =>
            libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();

        
        public List<Libro> OrdenarPorTitulo() =>
            libros.OrderBy(l => l.Titulo).ToList();

        public List<Libro> OrdenarPorAnio() =>
            libros.OrderBy(l => l.Anio).ToList();

        
        public int TotalLibros() => libros.Count;

        public int LibrosDisponibles() => libros.Count(l => l.Disponible);

        public int LibrosPrestados() => libros.Count(l => !l.Disponible);

        public void MostrarKpis()
        {
            Console.WriteLine($"Total de libros: {TotalLibros()}");
            Console.WriteLine($"Disponibles: {LibrosDisponibles()} | Prestados: {LibrosPrestados()}");
        }
    }
}
