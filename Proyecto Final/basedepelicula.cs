using System;
using System.Collections.Generic;
public class Basedepelicula
{
    public List<Pelicula> ListadePelicula { get; set; }
    public List<Cliente> ListadeClientes { get; set; }
    public List<Vendedor> ListadeVendedores { get; set; }
    public List<Orden> ListaOrdenes { get; set; }

    public Basedepelicula()
    {
        ListadePelicula = new List<Pelicula>();
        cargarPelicula();

        ListadeClientes = new List<Cliente>();
        cargarClientes();

        ListadeVendedores = new List<Vendedor>();
        cargarVendedores();

        ListaOrdenes = new List<Orden>();
    }

    private void cargarPelicula()
    {
        Pelicula p1 = new Pelicula(1, "Lagrimas del sol", 380);
        ListadePelicula.Add(p1);

        Pelicula p2 = new Pelicula(2, "Bob Esponga: La Pelicula", 350);
        ListadePelicula.Add(p2);

        Pelicula p3 = new Pelicula(3, "Los Vengadores Completa", 400);
        ListadePelicula.Add(p3);

        Pelicula p4 = new Pelicula(4, "Golpe bajo: El juego final", 430);
        ListadePelicula.Add(p4);

        Pelicula p5 = new Pelicula(5, "Soy Leyenda", 355);
        ListadePelicula.Add(p5);

        Pelicula p6 = new Pelicula(6, "Mulan", 289);
        ListadePelicula.Add(p6);

        Pelicula p7 = new Pelicula(7, "Venom", 290);
        ListadePelicula.Add(p7);

        Pelicula p8 = new Pelicula(8, "Diamante de sangre", 400);
        ListadePelicula.Add(p8);

        Pelicula p9 = new Pelicula(9, "G.I Joe: el origen de cobra", 349);
        ListadePelicula.Add(p9);

        Pelicula p10 = new Pelicula(10, "Robin Hood", 313);
        ListadePelicula.Add(p10);
    }

    private void cargarClientes()
    {
        Cliente c1 = new Cliente(1, "Maria", "5432");
        ListadeClientes.Add(c1);

        Cliente c2 = new Cliente(2, "Elmer", "3242");
        ListadeClientes.Add(c2);
    }

    private void cargarVendedores()
    {
        Vendedor v1 = new Vendedor(1, "Gissbell", "321");
        ListadeVendedores.Add(v1);

        Vendedor v2 = new Vendedor(2, "Carmen", "487");
        ListadeVendedores.Add(v2);
    }

    public void ListarPelicula()
    {
        Console.Clear();
        Console.WriteLine("Lista de Peliculas");
        Console.WriteLine("==================");
        Console.WriteLine("");
        
        foreach (var pelicula in ListadePelicula)
        {
            Console.WriteLine(pelicula.Codigo + " | " + pelicula.Descripcion + " | " + pelicula.Precio);
        }

        Console.ReadLine();
    }

    public void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de Clientes");
        Console.WriteLine("=================");
        Console.WriteLine("");
        
        foreach (var cliente in ListadeClientes)
        {
            Console.WriteLine(cliente.Codigo + " | " + cliente.Nombre + " | " + cliente.Telefono);
        }

        Console.ReadLine();
    }

    public void ListarVendedores()
    {
        Console.Clear();
        Console.WriteLine("Lista de Vendedores");
        Console.WriteLine("===================");
        Console.WriteLine("");
        
        foreach (var vendedor in ListadeVendedores)
        {
            Console.WriteLine(vendedor.Codigo + " | " + vendedor.Nombre + " | " + vendedor.CodigoVendedor);
        }

        Console.ReadLine();
    }

    public void CarritodeCompra()
    {
        Console.WriteLine("Carrito de Compra");
        Console.WriteLine("=================");
        Console.WriteLine("");

        Console.WriteLine("Ingrese el codigo del cliente: ");
        string codigoCliente = Console.ReadLine();

        Cliente cliente = ListadeClientes.Find(c => c.Codigo.ToString() == codigoCliente);        
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("");
        }

        Console.WriteLine("Ingrese el codigo del vendedor: ");
        string codigoVendedor = Console.ReadLine();

        Vendedor vendedor = ListadeVendedores.Find(v => v.Codigo.ToString() == codigoVendedor);
        if (vendedor == null) 
        {
            Console.WriteLine("Vendedor no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Vendedor: " + vendedor.Nombre);
            Console.WriteLine("");
        }

        int nuevoCodigo = ListaOrdenes.Count + 1;

        Orden nuevaOrden = new Orden(nuevoCodigo, DateTime.Now, "SPS" + nuevoCodigo, cliente, vendedor);
        ListaOrdenes.Add(nuevaOrden);

        while(true)
        {
            Console.WriteLine("Ingrese la pelicula: ");
            string codigoPelicula = Console.ReadLine();
            Pelicula pelicula = ListadePelicula.Find(p => p.Codigo.ToString() == codigoPelicula);        
            if (pelicula == null)
            {
                Console.WriteLine("Pelicula no encontrado");
                Console.ReadLine();
            } else {
                Console.WriteLine("Pelicula agregado: " + pelicula.Descripcion + " con precio de: " + pelicula.Precio);
                nuevaOrden.AgregarPelicula(pelicula);
            }

            Console.WriteLine("Desea continuar? si/no");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() == "no") {
                break;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Subtotal de la orden es de: " + nuevaOrden.Subtotal);
        Console.WriteLine("Impuesto de la orden es de: " + nuevaOrden.Impuesto);
        Console.WriteLine("Total de la orden es de: " + nuevaOrden.Total);
        Console.ReadLine();
    }

    public void ListadeCompra()
    {
        Console.Clear();
        Console.WriteLine("Lista de Ordenes");
        Console.WriteLine("================");
        Console.WriteLine("");  
        Console.WriteLine("Codigo | Fecha | Subtotal | Impuesto | Total");
        Console.WriteLine("Cliente | Vendedor");
        Console.WriteLine("============================================");
        Console.WriteLine("");  

        foreach (var orden in ListaOrdenes)
        {
            Console.WriteLine(orden.Codigo + " | " + orden.Fecha + " | " + orden.Subtotal + " | " + orden.Impuesto + " | " + orden.Total);
            Console.WriteLine(orden.Cliente.Nombre + " | " + orden.Vendedor.Nombre);
            
            foreach (var detalle in orden.ListaDescripcion)
            {
                Console.WriteLine("     " + detalle.Pelicula.Descripcion + " | " + detalle.Cantidad + " | " + detalle.Precio);
            }

            Console.WriteLine();
        } 

        Console.ReadLine();
    }
}