using System;
using System.Collections.Generic;
using System.Linq;

class Ejercicio3_Biblioteca
{
    static void Main()
    {
        var biblioteca = new Biblioteca
        {
            Nombre = "Biblioteca Central"
        };

        // Agregar materiales
        biblioteca.AgregarMaterial(new Libro
        {
            Titulo = "C# en profundidad",
            Autor = "Jon Skeet",
            AñoPublicacion = 2020,
            Disponible = true
        });

        biblioteca.AgregarMaterial(new Libro
        {
            Titulo = "Clean Code",
            Autor = "Robert C. Martin",
            AñoPublicacion = 2008,
            Disponible = true
        });

        biblioteca.AgregarMaterial(new Libro
        {
            Titulo = "El programador pragmático",
            Autor = "Andrew Hunt",
            AñoPublicacion = 1999,
            Disponible = false
        });

        biblioteca.AgregarMaterial(new Revista
        {
            Titulo = "Desarrollo .NET",
            Autor = "Microsoft",
            AñoPublicacion = 2024,
            NumeroEdicion = 45,
            Disponible = true
        });

        biblioteca.AgregarMaterial(new Revista
        {
            Titulo = "Tecnología Hoy",
            Autor = "Editorial Tech",
            AñoPublicacion = 2023,
            NumeroEdicion = 12,
            Disponible = false
        });

        // Mostrar todos
        biblioteca.MostrarMateriales();

        // Prestar un libro
        var libro = biblioteca.BuscarPorTitulo("C# en profundidad") as Libro;
        if (libro != null)
        {
            if (libro.Prestar())
                Console.WriteLine($"\n✅ '{libro.Titulo}' prestado.");
            else
                Console.WriteLine($"\n❌ '{libro.Titulo}' no está disponible.");
        }

        // Devolver una revista
        var revista = biblioteca.BuscarPorTitulo("Tecnología Hoy") as Revista;
        if (revista != null)
        {
            revista.Devolver();
            Console.WriteLine($"\n🔄 '{revista.Titulo}' devuelta y ahora está disponible.");
        }

        // Buscar por título
        var encontrado = biblioteca.BuscarPorTitulo("Clean Code");
        if (encontrado != null)
        {
            Console.WriteLine("\n🔍 Material encontrado:");
            encontrado.MostrarInfo();
        }
        else
        {
            Console.WriteLine("\n❌ Material no encontrado.");
        }

        // Listar disponibles
        biblioteca.ListarDisponibles();

        // ========== LINQ ==========
        Console.WriteLine("\n=== LINQ ===");

        // Filtrar libros disponibles
        Console.WriteLine("Libros disponibles:");
        var librosDisponibles = biblioteca.Materiales
            .OfType<Libro>()
            .Where(l => l.Disponible);
        foreach (var l in librosDisponibles) l.MostrarInfo();

        // Ordenar todos por año (descendente)
        Console.WriteLine("\nMateriales ordenados por año (desc):");
        var ordenados = biblioteca.Materiales
            .OrderByDescending(m => m.AñoPublicacion);
        foreach (var m in ordenados) m.MostrarInfo();

        // Contar por tipo
        int libros = biblioteca.Materiales.OfType<Libro>().Count();
        int revistas = biblioteca.Materiales.OfType<Revista>().Count();
        Console.WriteLine($"\nTotal: {libros} Libros, {revistas} Revistas.");
    }
}
