public class Libro : Material, IPrestable
{
    public bool Disponible { get; set; } = true;

    public bool Prestar()
    {
        if (Disponible)
        {
            Disponible = false;
            return true;
        }
        return false;
    }

    public void Devolver()
    {
        Disponible = true;
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Libro: {Titulo} | Autor: {Autor} | Año: {AñoPublicacion} | " +
                          $"Disponible: {(Disponible ? "Sí" : "No")}");
    }
}
