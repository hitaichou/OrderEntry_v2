using System;
using OrderEntry_v2.Entities.Enums;
using System.Collections.Generic;

namespace OrderEntry_v2.Entities
{
    class Order
    {
        private string productItem;
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        //Associação entre duas classes
        public Client Client { get; set; }
        //um pedido tem vários itens
        public List<OrderItem> Items { get; set; } = new List<OrderItem>(); 

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            //Adiciona na lista Items o item do pedido através do argumento item
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            //Remove da lista Items o item do pedido através do argumento item
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            //percorre a lista Items somando todos os valores.
            foreach (OrderItem item in Items) 
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        //Sobreposição        
        //Concateno todos os produtos em uma variável
        public override string ToString()
        {
            foreach(OrderItem item in Items)
            {
                productItem = productItem + item.Products();
            }

            return productItem;
        }
    }
}
