using System;
using System.Globalization;
using OrderEntry_v2.Entities;
using OrderEntry_v2.Entities.Enums;

namespace OrderEntry_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ler os dados de um pedido com N itens (N fornecido pelo usuário). 
             * Depois, mostrar um sumário do pedido. Nota: o instante do pedido 
             * deve ser o instante do sistema: DateTime.Now.
             */
            DateTime dtMoment;

            Console.WriteLine("Enter Client Data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date: ");
            DateTime dtBirthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Order Data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());            
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            dtMoment = DateTime.Now;

            //passando para a classe cliente os dados lançados pelo usuário
            Client cli = new Client(name, email, dtBirthDate);
            //associando entrada
            Order order = new Order(dtMoment, status, cli);

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} data:"); //usando interpolação
                Console.Write("Product Name: ");
                string nmProduct = Console.ReadLine();
                Console.Write("Product Price: ");
                double vlPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);                                
                Console.Write("Quantity: ");
                int qtQuantity = int.Parse(Console.ReadLine());
                
                //instancio os itens na classe OrderItem(PedidoItem)
                OrderItem items = new OrderItem(qtQuantity, vlPrice, nmProduct);
                //adicionando os itens no Order(Pedido)
                order.AddItem(items);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine("Order moment: " + order.Moment);
            Console.WriteLine("Order status: " + order.Status);
            //Console.WriteLine("Client: " + order.Client.Name + "(" + order.Client.DateBirth + ") - " + order.Client.Email);
            Console.WriteLine("Client: " + order.Client.Name + "(" + order.Client.DateBirth.ToString("dd/MM/yyyy") + ") - " + order.Client.Email);
            Console.WriteLine("Order Items:");
            Console.WriteLine(order);
            Console.WriteLine("Total Price: " + order.Total().ToString("F2"));




        }
    }
}
