using System;
using System.Globalization;
using ProductOrder.Entities;
using ProductOrder.Entities.Enums;

namespace ProductOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();

            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();

            Console.Write("Birth Date (DD//MM/YYYY): ");
            DateTime clientBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");
            Console.Write("Status [PendingPayment/Processing/Shipped/Delivered]: ");
            OrderStatus status = (OrderStatus) Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Order order = new Order(DateTime.Now, status, new Client {
                Name = clientName,
                Email = clientEmail,
                BirthDate = clientBirth
            });

            Console.Write("How many items to this order: ");
            int orderQuantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= orderQuantity; i++)
            {
                Console.WriteLine($"Enter {i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                order.AddItem(new OrderItem(productQuantity, productPrice, new Product(productName, productPrice)));
            }

            Console.WriteLine("\nORDER SUMMARY:");
            Console.Write(order);

            Console.ReadLine();

        }
    }
}
