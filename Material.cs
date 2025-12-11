public abstract class Material
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AñoPublicacion { get; set; }

    public abstract void MostrarInfo();
}
