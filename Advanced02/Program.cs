namespace Advanced02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }

        List<Product> SearchProducts(List<Product> products,Func<Product,bool> filter)

        {
            List<Product> result = new List<Product>();
            for(int i = 0; i < products.Count; i++)
            {
                if (filter(products[i]))
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
    }
}
