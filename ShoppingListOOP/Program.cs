using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleShoppingList consoleShoppingList = new ConsoleShoppingList();
            consoleShoppingList.Run();
        }
    }

    public class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }
    }
}