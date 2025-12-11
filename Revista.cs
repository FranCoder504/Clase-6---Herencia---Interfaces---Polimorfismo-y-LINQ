public class Revista : Material, IPrestable
{
    public int NumeroEdicion { get; set; }
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
        Console.WriteLine($"Revista: {Titulo} | Autor: {Autor} | Año: {AñoPublicacion} | " +
                          $"Edición: {NumeroEdicion} | Disponible: {(Disponible ? "Sí" : "No")}");
    }
}
