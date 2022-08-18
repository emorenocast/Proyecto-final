public class Descripcion
{
    public int Codigo { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public Pelicula Pelicula { get; set; }

    public Descripcion(int codigo, int cantidad, Pelicula pelicula)
    {
        Codigo = codigo;
        Cantidad = cantidad;
        Pelicula = pelicula;
        Precio = pelicula.Precio;
    }
}