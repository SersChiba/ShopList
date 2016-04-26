using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoppingListOOP
{
    class Cart
    {
        //string path = @"D:\OneDrive\Koplietošanai\CSharp\ShoppingListOOP\ShoppingList.txt";
        string path = @"D:\Dokumenti\CSharp\ShoppingList.txt";

        private List<Product> shoppingList = new List<Product>()
        {
            new Product() { name="milk", price=.79M, category="food" },
            new Product() { name="beer", price=1.45M, category="alcoholic beverages" },
            new Product() { name="bread", price=2M, category="food" },
            new Product() { name="bulbs", price=6.49M, category="household goods" },
            new Product() { name="socks", price=11.11M, category="clothes" }
        };

        public List<Product> getList()
        {
            return shoppingList;
        }

        internal bool SaveToFile()
        {
            var utf8 = new UTF8Encoding();            
            File.WriteAllText(path, shoppingList[0].name + "\t" + shoppingList[0].price + "\t" + shoppingList[0].category + Environment.NewLine, utf8);
            for (int i = 1; i < shoppingList.Count; i++)
                File.AppendAllText(path, shoppingList[i].name + "\t" + shoppingList[i].price + "\t" + shoppingList[i].category + Environment.NewLine, utf8);
            return true;
        }

        internal bool LoadFromFile()
        {
            if (File.Exists(path))
            {
                string[] textFromFile = File.ReadAllLines(path);
                var loadedList = new List<Product>();
                for (int i = 0; i < textFromFile.Length; i++)
                {
                    string[] tempTextArray = textFromFile[i].Split('\t');
                    Product product = new Product();
                    product.name = tempTextArray[0];
                    product.price = decimal.Parse(tempTextArray[1]);
                    product.category = tempTextArray[2];
                    loadedList.Add(product);
                }
                shoppingList = loadedList;
                return true;
            }
            else return false;
        }

        public void AddItemToCart(Product product)
        {
            shoppingList.Add(product);
        }

        internal void RemoveItemFromCart(Product item)
        {
            shoppingList.Remove(item);
        }

        internal List<Product> Filter(IFilter filter)
        {
            List<Product> result = new List<Product>();
            foreach (Product item in shoppingList)
                if (filter.isValid(item))
                {
                    result.Add(item);
                }
            return result;
        }
    }

    public class PriceRangeFilter : IFilter
    {
        private Tuple<decimal, decimal> priceRange;

        public PriceRangeFilter(Tuple<decimal, decimal> priceRange)
        {
            this.priceRange = priceRange;
        }

        public bool isValid(Product item)
        {
            //Console.WriteLine(priceRange.Item1);
            //Console.WriteLine(priceRange.Item2);
            if (item.price >= priceRange.Item1 && item.price <= priceRange.Item2)
                return true;
            return false;
        }
    }

    public class CategoryFilter : IFilter
    {
        private string category;

        public CategoryFilter(string category)
        {
            this.category = category;
        }

        public bool isValid(Product item)
        {
            if (item.category == category)
                return true;
            return false;
        }
    }

    public interface IFilter
    {
        bool isValid(Product item);
    }
}
