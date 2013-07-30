using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Printful.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Printful API Test");

            PrintfulOrder order = new PrintfulOrder(1);
            order.Handling = PrintfulShippingHandling.STANDARD;

            order.Items = new List<PrintfulItem>();
            PrintfulItem shirt = new PrintfulItem();
            shirt.ImageUrl = "http://example.com/shirt.pdf";
            shirt.Name = "Test Shirt";
            shirt.ProductId = 302; //2001 fine jersey short sleeve men, xl red
            shirt.Sku = 1222333;
            shirt.Quantity = 2;
            order.Items.Add(shirt);

            PrintfulItem poster = new PrintfulItem();
            poster.ImageUrl = "http://www.example.com/poster.pdf";
            poster.Name = "Test Poster";
            poster.ProductId = 2; //24x36 unframed
            poster.Sku = 123456;
            poster.Quantity = 1;
            order.Items.Add(poster);

            order.Notes = "Items for hackathon booth!";
            order.Recipient = new PrintfulRecipient();
            order.Recipient.FullName = "Tes Ter";
            order.Recipient.AddressLine1 = "123 Test Ave";
            order.Recipient.AddressLine2 = "Suite 205";
            order.Recipient.City = "Philadelphia";
            order.Recipient.State = "PA";
            order.Recipient.Zip = "19019";
            order.Recipient.Country = "US";

            Console.WriteLine("Testing JSON parsing...");
            Console.WriteLine(order.ToJson());
            Console.WriteLine();

            Printful print = new Printful("YOUR-API-KEY");
            print.LetExceptionsBubble = true;
            print.VerboseLogging = true;
            try
            {
                Console.WriteLine("Testing order creation...");
                Console.WriteLine("Order created successfully? " + print.Orders.CreateOrder(order));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing order status...");
                order.Items.Remove(poster);
                Console.WriteLine("Order status: " + print.Orders.OrderStatus(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing order update...");
                order.Items.Remove(poster);
                Console.WriteLine("Order updated successfully? " + print.Orders.UpdateOrder(1, order));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing order status...");
                order.Items.Remove(poster);
                Console.WriteLine("Order status: " + print.Orders.OrderStatus(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing order deletion...");
                Console.WriteLine("Order deleted successfully? " + print.Orders.DeleteOrder(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing order status...");
                order.Items.Remove(poster);
                Console.WriteLine("Order status: " + print.Orders.OrderStatus(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing GetAllProducts...");
                string products = print.Products.GetAllProducts();
                Console.WriteLine(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();

            try
            {
                Console.WriteLine("Testing GetProduct...");
                string products = print.Products.GetProduct("poster", "{test}");
                Console.WriteLine(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            Console.WriteLine(print.Information);
            

            Console.ReadKey();
        }
    }
}
