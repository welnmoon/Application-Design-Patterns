using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IUserService
    {
        User Register(string username, string password);
        User Login(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public User Register(string username, string password)
        {
            var user = new User { Id = _users.Count + 1, Username = username, Password = password };
            _users.Add(user);
            Console.WriteLine($"User {username} registered successfully.");
            return user;
        }

        public User Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"User {username} logged in successfully.");
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
            return user;
        }
    }

    public interface IProductService
    {
        List<Product> GetProducts();
        Product AddProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();

        public List<Product> GetProducts() => _products;

        public Product AddProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"Product {product.Name} added.");
            return product;
        }
    }

    public interface IOrderService
    {
        Order CreateOrder(int userId, List<int> productIds);
        Order GetOrderStatus(int orderId);
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public string Status { get; set; }
    }

    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;

        public OrderService(IProductService productService)
        {
            _productService = productService;
        }

        public Order CreateOrder(int userId, List<int> productIds)
        {
            var products = _productService.GetProducts().Where(p => productIds.Contains(p.Id)).ToList();
            var order = new Order { Id = 1, UserId = userId, Products = products, Status = "Created" };
            Console.WriteLine($"Order created with {products.Count} products.");
            return order;
        }

        public Order GetOrderStatus(int orderId)
        {
            return new Order { Id = orderId, Status = "In Progress" };
        }
    }

    class Program
    {
        static void Main()
        {
            var userService = new UserService();
            var productService = new ProductService();
            var orderService = new OrderService(productService);

            var user = userService.Register("user1", "password1");
            userService.Login("user1", "password1");

            var product1 = productService.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 1000m });
            var product2 = productService.AddProduct(new Product { Id = 2, Name = "Mouse", Price = 50m });

            var order = orderService.CreateOrder(user.Id, new List<int> { product1.Id, product2.Id });
            Console.WriteLine($"Order status: {orderService.GetOrderStatus(order.Id).Status}");
        }
    }
}
