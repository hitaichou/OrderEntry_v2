using System;
using System.Collections.Generic;
using System.Text;

namespace OrderEntry_v2.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; } = new Product();


        //CONSTRUTORES
        public OrderItem()
        {

        }
        public OrderItem(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }
        public OrderItem(string name, double price)
        {
            Product.Name = name;
            Product.Price = price;
        }
        public OrderItem(int quantity, double price, string name)
        {
            Quantity = quantity;
            //Price = price;
            //Name = name;
            //Product.Name = Name;
            //Product.Price = Price;
            Product.Name = name;
            Product.Price = price;
        }


        //METODOS
        public double SubTotal()
        {
            return (Quantity * Product.Price);
            //return (Quantity * Price);

        }
        //Concateno os detalhes do produto/pedido-item
        public string Products()
        {
            return "Product: " + Product.Name + " "
                + "Quantity: " + Quantity + " "
                + //"Price: " + Product.Price.ToString("F2")
                "Price: " + SubTotal().ToString("F2")
                + "\n";
        }
    }
}
