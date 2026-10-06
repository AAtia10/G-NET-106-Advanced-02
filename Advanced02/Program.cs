namespace Advanced02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> catalog = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 100 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

            Console.WriteLine("===== Search 1: Electronics =====");

            List< Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");

            for (int i = 0; i < electronics.Count; i++)
            {
                Console.WriteLine(electronics[i].Name);
            }


            Console.WriteLine("\n===== Search 2: Price < $50 =====");

            List<Product> cheapProducts = SearchProducts(catalog, p => p.Price < 50);

            for (int i = 0; i < cheapProducts.Count; i++)
            {
                Console.WriteLine(cheapProducts[i].Name);
            }



            Console.WriteLine("\n===== Search 3: In Stock =====");

            List<Product> inStockProducts = SearchProducts(catalog, p => p.Stock > 0);

            for (int i = 0; i < inStockProducts.Count; i++)
            {
                Console.WriteLine(inStockProducts[i].Name);
            }


            Console.WriteLine("\n===== Search 4: Clothing under $100 =====");

            List<Product> clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            for (int i = 0; i < clothingUnder100.Count; i++)
            {
                Console.WriteLine(clothingUnder100[i].Name);
            }


            Console.WriteLine("\n===== Short Report =====");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n===== Detailed Report =====");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}]{p.Name}| Price:${p.Price}| Stock:{p.Stock}"));



            Console.WriteLine("\n===== Summary List =====");
            List<string> summary = TransformProducts(catalog,  p => $"{p.Name} (${p.Price})" );
            for (int i = 0; i < summary.Count; i++)
            {
                Console.WriteLine(summary[i]);
            }



            Console.WriteLine("\n===== Price Label =====");

            List<string> priceLabels = TransformProducts(
            catalog,
            p =>
                $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}"
        );

            for (int i = 0; i < priceLabels.Count; i++)
            {
                Console.WriteLine(priceLabels[i]);
            }


            Console.WriteLine("\n===== Low Stock Alert =====");

            List<Product> lowStockProducts = FilterProducts(
            catalog,
            p => p.Stock < 20
        );

            for (int i = 0; i < lowStockProducts.Count; i++)
            {
                Console.WriteLine(
                    $"[LOW STOCK] {lowStockProducts[i].Name}: only {lowStockProducts[i].Stock} left!"
                );
            }
        }



        

        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)

        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (filter(products[i]))
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }


       static void PrintReport(List<Product> products, Action<Product> action)

        {
            for (int i = 0; i < products.Count; i++)
            {
                action(products[i]);
            }
        }


       static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)

        {
            List<string> result = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
                result.Add(transform(products[i]));
            }
            return result;
        }


       static List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < products.Count; i++)
            {
                if (predicate(products[i]))
                {
                    result.Add(products[i]);
                }
            }
            return result;


        }
    }
}
