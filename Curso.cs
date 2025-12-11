using System.Collections.Generic;
using System.Linq;

public class Curso
{
    public string NombreCurso { get; set; }
    public Profesor Profesor { get; set; }
    public List<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public void AgregarAlumno(Alumno a) => Alumnos.Add(a);

    public void MostrarAlumnos()
    {
        foreach (var a in Alumnos)
        {
            a.Presentarse();
            Console.WriteLine(a.Aprobado() ? "  → Aprobado" : "  → Reprobado");
        }
    }

    public double PromedioCurso() => Alumnos.Any() ? Alumnos.Average(a => a.NotaFinal) : 0;
}
