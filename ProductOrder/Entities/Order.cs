using ProductOrder.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder.Entities
{
    class Order
    {
        private DateTime Moment { get; set; }
        private OrderStatus Status { get; set; }
        private Client Client { get; set; }
        private List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double priceSum = 0.0;

            foreach (OrderItem item in Items)
            {
                priceSum += item.SubTotal();
            }

            return priceSum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }

            sb.Append("Total Price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString(); 
        }
    }
}
