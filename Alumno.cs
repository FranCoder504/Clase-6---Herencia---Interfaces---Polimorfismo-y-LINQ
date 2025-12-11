public class Alumno : Persona, IEvaluacion
{
    public double NotaFinal { get; set; }

    public bool Aprobado() => NotaFinal >= 4.0;

    public override void Presentarse()
    {
        Console.WriteLine($"Hola, soy {Nombre}, tengo {Edad} años y mi nota es {NotaFinal:F1}.");
    }
}
