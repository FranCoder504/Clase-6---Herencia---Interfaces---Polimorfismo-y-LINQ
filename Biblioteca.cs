using System.Collections.Generic;
using System.Linq;

public class Biblioteca
{
    public string Nombre { get; set; }
    public List<Material> Materiales { get; set; } = new List<Material>();

    public void AgregarMaterial(Material m)
    {
        Materiales.Add(m);
    }

    public void MostrarMateriales()
    {
        Console.WriteLine($"\n=== Materiales en la biblioteca: {Nombre} ===");
        foreach (var m in Materiales)
        {
            m.MostrarInfo();
        }
    }

    public Material BuscarPorTitulo(string titulo)
    {
        return Materiales.FirstOrDefault(m => m.Titulo.Equals(titulo, System.StringComparison.OrdinalIgnoreCase));
    }

    public void ListarDisponibles()
    {
        Console.WriteLine("\n=== Materiales disponibles ===");
        var disponibles = Materiales.Where(m => m is IPrestable p && p.Prestar()); // No se puede usar Prestar así
        // En su lugar, validamos el estado sin prestar
        var realmenteDisponibles = Materiales.Where(m =>
        {
            if (m is Libro l) return l.Disponible;
            if (m is Revista r) return r.Disponible;
            return false;
        });

        foreach (var m in realmenteDisponibles)
        {
            m.MostrarInfo();
        }
    }
}
