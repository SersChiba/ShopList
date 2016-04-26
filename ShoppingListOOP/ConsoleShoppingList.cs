using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListOOP
{
    public class ConsoleShoppingList
    {
        Cart cart = new Cart();
        
        public void Run()
        {

            int choice = 0;
            Console.WriteLine("This is a shopping list application.");

            do
            {
                Choices();
                string a = Console.ReadLine();
                int.TryParse(a, out choice);

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        RemoveItem();
                        break;
                    case 3:                        
                        SeeList();
                        break;
                    case 4:
                        SeeList(cart.Filter(new PriceRangeFilter(GetPriceRange())));                        
                        break;
                    case 5:
                        SeeList(cart.Filter(new CategoryFilter(GetCategory())));
                        break;
                    case 6:
                        SaveToFile();
                        break;
                    case 7:
                        LoadFromFile();
                        break;
                    case 8:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Wrong choice, here are available choices:");
                        break;
                }
            } while (choice != 8);
        }

        private void SaveToFile()
        {
            cart.SaveToFile();
            if (cart.SaveToFile())
                Console.WriteLine("File saved successfully.");
            else
                Console.WriteLine("File not saved.");
        }

        private void LoadFromFile()
        {            
            if (cart.LoadFromFile())
                Console.WriteLine("Data from file loaded successfully.");
            else
                Console.WriteLine("Data loading failure.");
        }

        private void RemoveItem()
        {
            Console.Write("\nEnter the name of the product to remove from the shopping cart: ");
            string productToRemove = Console.ReadLine();
            bool productRemoved = false;

            foreach (Product item in cart.getList())
            {
                if (item.name == productToRemove)
                {
                    cart.RemoveItemFromCart(item);
                    Console.WriteLine("Product '{0}' removed.", item.name);
                    productRemoved = true;
                    return;
                }
            }
            if (!productRemoved)
                Console.WriteLine("Entered product name does not exist in the shopping cart!");
        }

        private void SeeList()
        {

            Console.WriteLine("\nHere is the shopping list: ");

            foreach (Product item in cart.getList())
                Console.WriteLine(item.name+"\t"+item.price+"\t"+item.category);
        }

        private void SeeList(List<Product> filteredList)
        {
            Console.WriteLine("\nHere is the shopping list filtered by price: ");

            foreach (Product item in filteredList)
                Console.WriteLine(item.name);
        }

        private void AddItem()
        {
            Product product = new Product();

            Console.Write("\nEnter the name of the product to add to the shopping cart: ");
            product.name = Console.ReadLine();

            Console.Write("\nEnter the price of the new product: ");
            product.price = decimal.Parse(Console.ReadLine());

            Console.Write("\nEnter the category of the new product: ");
            product.category = Console.ReadLine();

            cart.AddItemToCart(product);

            Console.WriteLine("Product added");
            Console.WriteLine("Name:\t\t{0}\nPrice:\t\t{1}\nCategory:\t{2}", product.name, product.price, product.category);
        }

        private Tuple<decimal, decimal> GetPriceRange()
        {
            Console.Write("\nEnter minimum price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());

            Console.Write("\nEnter maximum price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());
            return Tuple.Create(minPrice, maxPrice);
        }

        //// SeeList(cart.Filter(new PriceRangeFilter(1,10));

        //private void ListByPriceRange(List<Product> shoppingList)
        //{
        //    Console.Write("\nEnter minimum price: ");
        //    decimal minPrice = decimal.Parse(Console.ReadLine());

        //    Console.Write("\nEnter maximum price: ");
        //    decimal maxPrice = decimal.Parse(Console.ReadLine());

        //    List<Product> priceRangeList = new List<Product>();

        //    foreach (Product item in shoppingList)
        //        if (item.price >= minPrice && item.price <= maxPrice)
        //            priceRangeList.Add(item);
        //    // SeeList(priceRangeList);
        //}
        public string GetCategory()
        {
            Console.Write("\nEnter the category name you wish to see: ");
            return Console.ReadLine();
        }

        //// SeeList(cart.Filter(new CategoryFilter("fruit"));  OOD Visitor pattern

        //public void ListByCategory(List<Product> shoppingList)
        //{
        //    Console.Write("\nEnter the category name you wish to see: ");
        //    string categoryName = Console.ReadLine();
        //    List<Product> categoryList = new List<Product>();

        //    foreach (Product item in shoppingList)
        //        if (item.category == categoryName)
        //            categoryList.Add(item);
        //    // SeeList(categoryList);
        //}

        private void Exit()
        {
            Console.WriteLine("Good buy! Come again\nPress key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void Choices()
        {
            Console.WriteLine("\nEnter your choice:");
            Console.WriteLine("1 - Add new product to the list");
            Console.WriteLine("2 - Delete product from the list");
            Console.WriteLine("3 - See list");
            Console.WriteLine("4 - List products within a price range");
            Console.WriteLine("5 - List products from a category");
            Console.WriteLine("6 - Save the shopping list into a text file");
            Console.WriteLine("7 - Load a shopping list from a text file");
            Console.WriteLine("8 - Exit");
        }
    }
}
