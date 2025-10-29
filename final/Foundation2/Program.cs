using System;
using System.Collections.Generic;

// Address class
class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Check if address is in USA
    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    // Return formatted address string
    public string GetAddressString()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string Name
    {
        get { return name; }
    }

    public Address Address
    {
        get { return address; }
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
    public double PricePerUnit { get { return pricePerUnit; } }
    public int Quantity { get { return quantity; } }

    // Calculate total cost
    public double GetTotalCost()
    {
        return pricePerUnit * quantity;
    }
}

// Order class
class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Calculate total order cost
    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }

        // Add shipping cost
        if (customer.IsInUSA())
        {
            total += 5; // USA shipping
        }
        else
        {
            total += 35; // International shipping
        }

        return total;
    }

    // Generate packing label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += $"Product: {p.Name}, ID: {p.ProductId}\n";
        }
        return label;
    }

    // Generate shipping label
    public string GetShippingLabel()
    {
        string label = $"Shipping Label:\n{customer.Name}\n{customer.Address.GetAddressString()}\n";
        return label;
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        Customer cust1 = new Customer("Alice Smith", addr1);
        Customer cust2 = new Customer("Bob Johnson", addr2);

        // Create products
        Product prod1 = new Product("Laptop", "L100", 999.99, 1);
        Product prod2 = new Product("Mouse", "M200", 25.50, 2);
        Product prod3 = new Product("Keyboard", "K300", 45.75, 1);
        Product prod4 = new Product("Headphones", "H400", 79.99, 1);
        Product prod5 = new Product("Monitor", "M500", 199.99, 2);

        // Create first order
        Order order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod3);

        // Create second order
        Order order2 = new Order(cust2);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

        // Display results for first order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}\n");

        // Display results for second order
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
    }
}
