namespace SistemaBiblioteca.Models
{
    public class Usuario
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; } = true;

        public Usuario(string documento, string nombre, string email)
        {
            Documento = documento;
            Nombre = nombre;
            Email = email;
        }

        public override string ToString() =>
            $"[{Documento}] {Nombre} - {Email} | {(Activo ? "Activo" : "Inactivo")}";
    }
}
