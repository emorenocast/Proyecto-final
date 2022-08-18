public class Pelicula
{
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }

    public Pelicula(int codigo, string descripcion, double precio)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        Precio = precio;
    }
}