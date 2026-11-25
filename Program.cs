using SistemaBiblioteca;
using SistemaBiblioteca.Models;
using SistemaBiblioteca.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

static void Titulo(string t) => Console.WriteLine($"\n========== {t} ==========");
static void Imprimir<T>(IEnumerable<T> items) { foreach (var i in items) Console.WriteLine(i); }

// 1. Crear instancias de los servicios
var libroService = new LibroService();
var usuarioService = new UsuarioService();
var prestamoService = new PrestamoService();

// 2. Datos de prueba
libroService.AgregarLibro(new Libro("978-1", "Clean Code", "Robert C. Martin", 2008));
libroService.AgregarLibro(new Libro("978-2", "El Quijote", "Miguel de Cervantes", 1605));
libroService.AgregarLibro(new Libro("978-3", "Cien años de soledad", "Gabriel García Márquez", 1967));
libroService.AgregarLibro(new Libro("978-4", "El Principito", "Antoine de Saint-Exupéry", 1943));
libroService.AgregarLibro(new Libro("978-5", "C# en profundidad", "Jon Skeet", 2019));

usuarioService.AgregarUsuario(new Usuario("1001", "Carlos Pérez", "carlos@mail.com"));
usuarioService.AgregarUsuario(new Usuario("1002", "Ana Gómez", "ana@mail.com"));
usuarioService.AgregarUsuario(new Usuario("1003", "Luis Torres", "luis@mail.com"));
usuarioService.AgregarUsuario(new Usuario("1004", "María Ríos", "maria@mail.com"));

var l1 = libroService.BuscarPorIsbn("978-1")!;
var l2 = libroService.BuscarPorIsbn("978-2")!;
var l3 = libroService.BuscarPorIsbn("978-3")!;
var u1 = usuarioService.BuscarPorDocumento("1001")!;
var u2 = usuarioService.BuscarPorDocumento("1002")!;
var u3 = usuarioService.BuscarPorDocumento("1003")!;

prestamoService.AgregarPrestamo(new Prestamo(1, l1, u1, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(7)));   // activo
prestamoService.AgregarPrestamo(new Prestamo(2, l2, u2, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5))); // vencido
prestamoService.AgregarPrestamo(new Prestamo(3, l3, u3, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-2))); // se devolverá
prestamoService.DevolverPrestamo(3);
usuarioService.DesactivarUsuario("1004");

// 3. Listado
Titulo("LIBROS"); Imprimir(libroService.ObtenerTodos());
Titulo("USUARIOS"); Imprimir(usuarioService.ObtenerTodos());
Titulo("PRÉSTAMOS"); Imprimir(prestamoService.ObtenerTodos());

// 4. Búsquedas
Titulo("BÚSQUEDAS");
Console.WriteLine("Libro por ISBN 978-3: " + libroService.BuscarPorIsbn("978-3"));
Console.WriteLine("\nLibros con título 'clean':"); Imprimir(libroService.BuscarPorTitulo("clean"));
Console.WriteLine("\nLibros del autor 'Cervantes':"); Imprimir(libroService.BuscarPorAutor("Cervantes"));
Console.WriteLine("\nUsuario documento 1002: " + usuarioService.BuscarPorDocumento("1002"));
Console.WriteLine("\nUsuarios con nombre 'ana':"); Imprimir(usuarioService.BuscarPorNombre("ana"));
Console.WriteLine("\nPréstamo ID 1: " + prestamoService.BuscarPorId(1));
Console.WriteLine("\nPréstamos vencidos:"); Imprimir(prestamoService.BuscarPorEstado(EstadoPrestamo.Vencido));

// 5. Ordenaciones
Titulo("ORDENACIONES");
Console.WriteLine("Libros por título:"); Imprimir(libroService.OrdenarPorTitulo());
Console.WriteLine("\nLibros por año:"); Imprimir(libroService.OrdenarPorAnio());
Console.WriteLine("\nUsuarios por nombre:"); Imprimir(usuarioService.OrdenarPorNombre());
Console.WriteLine("\nPréstamos por fecha límite:"); Imprimir(prestamoService.OrdenarPorFechaLimite());

// 6. KPIs
Titulo("KPIs LIBROS"); libroService.MostrarKpis();
Titulo("KPIs USUARIOS"); usuarioService.MostrarKpis();
Titulo("KPIs PRÉSTAMOS"); prestamoService.MostrarKpis();

// 7. Eliminación
Titulo("ELIMINACIÓN");
Console.WriteLine("Eliminar libro 978-5: " + libroService.EliminarLibro("978-5"));
Console.WriteLine("Total de libros ahora: " + libroService.TotalLibros());

// 8. Array vs List
Titulo("COMPARACIÓN ARRAY VS LIST");
ComparacionArrayList.Ejecutar();
