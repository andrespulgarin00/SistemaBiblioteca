using SistemaBiblioteca.Models;

namespace SistemaBiblioteca
{
    public static class ComparacionArrayList
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== EJEMPLO CON ARRAY (tamaño fijo) ===");
            Libro[] arrayLibros = new Libro[2];          
            arrayLibros[0] = new Libro("111", "Clean Code", "Robert C. Martin", 2008);
            arrayLibros[1] = new Libro("222", "El Quijote", "Miguel de Cervantes", 1605);
            foreach (Libro l in arrayLibros)
                Console.WriteLine(l);
            Console.WriteLine($"Tamaño del array (Length): {arrayLibros.Length}");

            Console.WriteLine("\n=== EJEMPLO CON LIST<T> (tamaño dinámico) ===");
            List<Libro> listaLibros = new List<Libro>();  
            listaLibros.Add(new Libro("111", "Clean Code", "Robert C. Martin", 2008));
            listaLibros.Add(new Libro("222", "El Quijote", "Miguel de Cervantes", 1605));
            listaLibros.Add(new Libro("333", "Cien años de soledad", "Gabriel García Márquez", 1967)); // sí se puede
            listaLibros.RemoveAt(0);                     
            foreach (Libro l in listaLibros)
                Console.WriteLine(l);
            Console.WriteLine($"Tamaño de la lista (Count): {listaLibros.Count}");

            Console.WriteLine("\n=== DIFERENCIAS ===");
            Console.WriteLine("1. Array: tamaño fijo, se define al crearlo y no cambia. List: crece o se reduce dinámicamente.");
            Console.WriteLine("2. Array: usa Length. List: usa Count.");
            Console.WriteLine("3. Array: no tiene Add/Remove; hay que crear otro array para cambiar su tamaño.");
            Console.WriteLine("   List: incluye Add, Remove, Insert, Find, Sort, Contains, etc.");
            Console.WriteLine("4. Array: ideal cuando la cantidad de datos es conocida y constante.");
            Console.WriteLine("   List: ideal cuando los datos cambian, como libros, usuarios y préstamos.");
        }
    }
}
