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
        //List<Product> shoppingList = new List<Product>
        //{
        //    new Product() { name="milk", price=.79M, category="food" },
        //    new Product() { name="beer", price=1.45M, category="alcoholic beverages" },
        //    new Product() { name="bread", price=2M, category="food" },
        //    new Product() { name="bulbs", price=6.49M, category="household goods" },
        //    new Product() { name="socks", price=11.11M, category="clothes" },
        //};

        public void Print()
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
                        //SeeList(shoppingList);
                        SeeList();
                        break;
                    case 4:

                        //ListByPriceRange(shoppingList);
                        break;
                    case 5:
                        SeeList(cart.Filter(new CategoryFilter("food")));
                        //ListByCategory(shoppingList);
                        break;
                    case 6:
                        SaveToFile();
                        // Cart.SaveToFile(shoppingList);
                        break;
                    //case 7:

                    //    break;
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
            {
                Console.WriteLine("File saved successfully.");
            }
            else
            {
                Console.WriteLine("File not saved.");
            }
        }

        private void RemoveItem()
        {
            Console.Write("\nEnter the name of the product to remove from the shopping cart: ");
            string productToRemove = Console.ReadLine();
            bool productRemoved = false;

            foreach (Product item in cart.shoppingList)
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
            {
                Console.WriteLine("Entered product name does not exist in the shopping cart!");
            }
        }

        //private void SeeList(List<Product> shoppingList)
        //{
        //    Console.WriteLine("\nHere is the shopping list: ");

        //    foreach (Product item in shoppingList)
        //    {
        //        Console.WriteLine(item.name);
        //    }
        //}

        private void SeeList()
        {

            Console.WriteLine("\nHere is the shopping list: ");

            foreach (Product item in cart.getList())
            {
                Console.WriteLine(item.name);
            }
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


        // SeeList(cart.Filter(new PriceRangeFilter(1,10));
        private void ListByPriceRange(List<Product> shoppingList)
        {
            Console.Write("\nEnter minimum price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());

            Console.Write("\nEnter maximum price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            List<Product> priceRangeList = new List<Product>();

            foreach (Product item in shoppingList)
            {
                if (item.price >= minPrice && item.price <= maxPrice)
                {
                    priceRangeList.Add(item);
                }
            }
            // SeeList(priceRangeList);
        }

        // SeeList(cart.Filter(new CategoryFilter("fruit"));  OOD Visitor pattern
        public void ListByCategory(List<Product> shoppingList)
        {
            Console.Write("\nEnter the category name you wish to see: ");
            string categoryName = Console.ReadLine();
            List<Product> categoryList = new List<Product>();

            foreach (Product item in shoppingList)
            {
                if (item.category == categoryName)
                {
                    categoryList.Add(item);
                }
            }
            // SeeList(categoryList);
        }

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
            Console.WriteLine("7 - Load a shopping list from a text file (Sorry, not working)");
            Console.WriteLine("8 - Exit");
        }
    }

  
}
