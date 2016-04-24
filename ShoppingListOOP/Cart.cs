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


        //internal static void AddItem(List<Product> shoppingList)
        //{            
        //    shoppingList.Add(product);            
        //}

        //public void RemoveItemFromCart(List<Product> shoppingList)
        //{
        //    Console.Write("\nEnter the name of the product to remove from the shopping cart: ");
        //    string productToRemove = Console.ReadLine();
        //    bool productRemoved = false;

        //    foreach (Product item in shoppingList)
        //    {
        //        if (item.name == productToRemove)
        //        {
        //            shoppingList.Remove(item);
        //            Console.WriteLine("Product '{0}' removed.", item.name);
        //            productRemoved = true;
        //            return;
        //        }
        //    }
        //    if (!productRemoved)
        //    {
        //        Console.WriteLine("Entered product name does not exist in the shopping cart!");
        //    }
        //}

        //internal static void SaveToFile(List<Product> shoppingList)
        //{
        //    string path = @"D:\OneDrive\Koplietošanai\CSharp\ShoppingListOOP\ShoppingList.txt";
        //    File.WriteAllText(path, shoppingList[0].name + "\t" + shoppingList[0].price + "\t" + shoppingList[0].category + Environment.NewLine);
        //    for (int i = 1; i < shoppingList.Count; i++)
        //    {
        //        File.AppendAllText(path, shoppingList[i].name + "\t" + shoppingList[i].price + "\t" + shoppingList[i].category + Environment.NewLine);
        //    }
        //}

        internal bool SaveToFile()
        {
            string path = @"D:\OneDrive\Koplietošanai\CSharp\ShoppingListOOP\ShoppingList.txt";
            File.WriteAllText(path, shoppingList[0].name + "\t" + shoppingList[0].price + "\t" + shoppingList[0].category + Environment.NewLine);
            for (int i = 1; i < shoppingList.Count; i++)
            {
                File.AppendAllText(path, shoppingList[i].name + "\t" + shoppingList[i].price + "\t" + shoppingList[i].category + Environment.NewLine);
            }
            return true;
        }

        public void AddItemToCart(Product product)
        {
            shoppingList.Add(product);
        }

        internal void RemoveItemFromCart(Product item)
        {
            shoppingList.Remove(item);
        }

    }
}
