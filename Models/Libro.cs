namespace SistemaBiblioteca.Models
{
    public class Libro
    {
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public bool Disponible { get; set; } = true;

        public Libro(string isbn, string titulo, string autor, int anio)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
        }

        public override string ToString() =>
            $"[{Isbn}] {Titulo} - {Autor} ({Anio}) | {(Disponible ? "Disponible" : "Prestado")}";
    }
}
