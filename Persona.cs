public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public virtual void Presentarse()
    {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años.");
    }
}
