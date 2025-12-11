using System;
using System.Collections.Generic;
using System.Linq;

class EjercicioIntegrador_Clase6
{
    static void Main()
    {
        var profesor = new Profesor
        {
            Nombre = "Sergio Yáñez",
            Edad = 35,
            Asignatura = "Programación .NET"
        };

        var curso = new Curso
        {
            NombreCurso = "Desarrollo C#",
            Profesor = profesor
        };

        curso.AgregarAlumno(new Alumno { Nombre = "Ana", Edad = 20, NotaFinal = 5.5 });
        curso.AgregarAlumno(new Alumno { Nombre = "Pedro", Edad = 19, NotaFinal = 3.8 });
        curso.AgregarAlumno(new Alumno { Nombre = "Carlos", Edad = 22, NotaFinal = 6.0 });
        curso.AgregarAlumno(new Alumno { Nombre = "Lucía", Edad = 21, NotaFinal = 4.2 });
        curso.AgregarAlumno(new Alumno { Nombre = "Diego", Edad = 20, NotaFinal = 2.9 });

        Console.WriteLine("=== Profesor ===");
        curso.Profesor.Presentarse();

        Console.WriteLine("\n=== Alumnos ===");
        curso.MostrarAlumnos();

        Console.WriteLine($"\nPromedio del curso: {curso.PromedioCurso():F2}");

        // LINQ
        Console.WriteLine("\n=== Alumnos aprobados ===");
        curso.Alumnos.Where(a => a.Aprobado()).ToList().ForEach(a => Console.WriteLine(a.Nombre));

        Console.WriteLine("\n=== Nombres de reprobados ===");
        curso.Alumnos.Where(a => !a.Aprobado()).Select(a => a.Nombre).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("\n=== Ordenados por nota (desc) ===");
        curso.Alumnos.OrderByDescending(a => a.NotaFinal).ToList().ForEach(a =>
            Console.WriteLine($"{a.Nombre}: {a.NotaFinal:F1}"));

        Console.WriteLine("\n=== Agrupación: Aprobados / Reprobados ===");
        var grupos = curso.Alumnos.GroupBy(a => a.Aprobado() ? "Aprobado" : "Reprobado");
        foreach (var g in grupos)
        {
            Console.WriteLine($"{g.Key}:");
            foreach (var a in g) Console.WriteLine($"  - {a.Nombre}");
        }
    }
}
