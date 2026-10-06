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


        void PrintReport(List<Product> products,Action<Product> action)

        {
            for (int i = 0; i < products.Count; i++)
            {
                action(products[i]);
            }
        }


        List<string> TransformProducts(List<Product> products,Func<Product,string> transform)

        {
            List<string> result = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
               result.Add(transform(products[i]));
            }
            return result;
        }
    }
}
