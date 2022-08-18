using System;
using System.Collections.Generic;

public class Orden
{
    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public string NumerodeOrden { get; set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }
    public List<Descripcion> ListaDescripcion { get; set; }
    public double Total { get; set; }
    public double Subtotal { get; set; }
    public double Impuesto { get; set; }

    public Orden(int codigo, DateTime fecha, string numeroOrden, Cliente cliente, Vendedor vendedor)
    {
        Codigo = codigo;
        Fecha = fecha;
        NumerodeOrden = numeroOrden;
        Cliente = cliente;
        Vendedor = vendedor;
        ListaDescripcion= new List<Descripcion>();
    }

    public void AgregarPelicula(Pelicula pelicula)
    {
        int nuevoCodigo = ListaDescripcion.Count + 1;
        int cantidad = 1;

        Descripcion o = new Descripcion(nuevoCodigo, 1, pelicula);
        ListaDescripcion.Add(o);

        Subtotal += cantidad * pelicula.Precio;
        Impuesto = Subtotal * 0.15;
        Total = Subtotal + Impuesto;
    }
}