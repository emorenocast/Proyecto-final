using System;

namespace ventadepelicula
{
    class Program
    {
        static void Main(string[] args)
        {
            Basedepelicula datos = new Basedepelicula();
            string opcion = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("Venta de Pelicula online");
                Console.WriteLine("========================");
                Console.WriteLine("");
                Console.WriteLine("1- Lista de Pelicula");
                Console.WriteLine("2- Agregar a carrito de compra");
                Console.WriteLine("3- Lista de Cliente");
                Console.WriteLine("4- Lista de Vendedores");
                Console.WriteLine("5- Lista de compra");
                Console.WriteLine("0- Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                    datos.ListarPelicula();
                    break;
                    case "2":
                    datos.CarritodeCompra();
                    break;
                    case "3":
                    datos.ListarClientes();
                    break;
                    case "4":
                    datos.ListarVendedores();
                    break;
                    case "5":
                    datos.ListadeCompra();
                    break;
                    
                    default:
                        break;
                }

                if (opcion == "0")
                {
                    break;
                }
            }
        }
    }
}