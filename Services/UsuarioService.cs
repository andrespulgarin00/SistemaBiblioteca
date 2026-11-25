using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

   
        public void AgregarUsuario(Usuario usuario)
        {
            if (usuarios.Any(u => u.Documento == usuario.Documento))
            {
                Console.WriteLine($"Ya existe un usuario con documento {usuario.Documento}.");
                return;
            }
            usuarios.Add(usuario);
        }

        
        public bool DesactivarUsuario(string documento)
        {
            Usuario? usuario = BuscarPorDocumento(documento);
            if (usuario == null) return false;
            usuario.Activo = false;
            return true;
        }

        
        public bool EliminarUsuario(string documento)
        {
            Usuario? usuario = BuscarPorDocumento(documento);
            return usuario != null && usuarios.Remove(usuario);
        }

        public List<Usuario> ObtenerTodos() => new List<Usuario>(usuarios);

        
        public Usuario? BuscarPorDocumento(string documento) =>
            usuarios.FirstOrDefault(u => u.Documento == documento);

        public List<Usuario> BuscarPorNombre(string nombre) =>
            usuarios.Where(u => u.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

      
        public List<Usuario> OrdenarPorNombre() =>
            usuarios.OrderBy(u => u.Nombre).ToList();

       
        public int TotalUsuarios() => usuarios.Count;

        public int UsuariosActivos() => usuarios.Count(u => u.Activo);

        public int UsuariosInactivos() => usuarios.Count(u => !u.Activo);

        public void MostrarKpis()
        {
            Console.WriteLine($"Total de usuarios: {TotalUsuarios()}");
            Console.WriteLine($"Activos: {UsuariosActivos()} | Inactivos: {UsuariosInactivos()}");
        }
    }
}
