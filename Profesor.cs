public class Profesor : Persona
{
    public string Asignatura { get; set; }

    public override void Presentarse()
    {
        Console.WriteLine($"Hola, soy el profesor {Nombre}, tengo {Edad} años y dicto {Asignatura}.");
    }
}
