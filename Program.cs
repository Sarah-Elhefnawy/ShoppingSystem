
namespace ShoppingSystem
{
	internal class Program
	{
		// written in namespace so cart value is available to all methods
		// static so that easily available without making instance/object to access
		static public List<string> cartItems = new List<string>();         // STOCK

		// items in store are simple starting with only name and price
		// saved in dictionary since it is a key value types so consists of key and its value
		// dictionary is generic type
		static public Dictionary<string, double> itemPrices = new Dictionary<string, double>()
		{
			{"Camera",1500 },
			{"Laptop",3000 },
			{"TV",2500 }
		};       // USER SHOPPING CART

		static Stack<string> actions = new Stack<string>();

		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Shopping System!!!!");
			Console.WriteLine("****************************************");
			Console.WriteLine("1. Add item to cart");
			Console.WriteLine("2. View cart");
			Console.WriteLine("3. Remove item from cart");
			Console.WriteLine("4. Checkout");
			Console.WriteLine("5. Undo last action");
			Console.WriteLine("6. Exit");


			while (true)
			{
				Console.WriteLine("Enter your choice number (1-6):");
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						AddItem();
						break;
					case 2:
						ViewCart();
						break;
					case 3:
						RemoveItem();
						break;
					case 4:
						Checkout();
						break;
					case 5:
						Undo();
						break;
					case 6:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid nnumber please try again (1-6)");
						break;
				}
			}
		}
		private static void AddItem()
		{
			Console.WriteLine("Available items:");

			foreach (var Item in itemPrices)
			{
				Console.WriteLine($"Item:{Item.Key}, Price:{Item.Value}");
			}

			Console.WriteLine("Please enter product name: ");
			string cartItem = Console.ReadLine();

			// using containsKey instead of contains cuz i wanted to check from the stock dictionary
			if (itemPrices.ContainsKey(cartItem))
			{
				cartItems.Add(cartItem);

				// saving action in stack
				actions.Push($"Item {cartItem} added to cart");

				Console.WriteLine($"Item {cartItem} is added to your cart");
			}
			else Console.WriteLine("Item is out of stock or not available");
		}
		private static void ViewCart()
		{
			if (cartItems.Any())
			{
				Console.WriteLine("Your cart items :");

				var itemPriceCollection = GetCartPrices();
				// you can leave it without casting but you can't add, remove, .....

				foreach (var Item in itemPriceCollection)
				{
					// item name, price
					Console.WriteLine($"Item: {Item.Item1}, Price: {Item.Item2}");
				}
			}
			else Console.WriteLine("Cart is empty!!");
				
		}
		private static IEnumerable<Tuple<string, double>> GetCartPrices()
		{
			// it can also be stored in many others structures
			// List=> storing multible data, this data could be <=Tuple
			// Tuple could have 2 variables or more up to 8
			// Tuple and List are both data structures <>
			// the main purpose of this is to save the results in a List of Tuples
			var cartPrices = new List<Tuple<string,double>>();

			// now i am doing a loop on all items i have in the store
			// to look for the price of the specific item the user chose to buy
			foreach (var Item in cartItems)
			{
				double price = 0;

				// TryGetValue method takes the Key type(string name) and
				// does something called out to the value type(double price)
				// Try meaning it will try to find it(return true) or didn't find it(return false)
				bool foundItem = itemPrices.TryGetValue(Item, out price);
				if (foundItem)
				{
					// creating a new Tuple which has both the item and price
					Tuple<string,double> itemPrice = new Tuple<string,double>(Item, price);

					// and now i add to the cartPrices which contains what the user chose to add the cart
					// and add to them the new Tuple
					cartPrices.Add(itemPrice);
				}
			}
			// it is preferred when returning any data structure type <> in its origin
			// so instead of making the method typr List<Tuple<string,double>> it will be IEnumerable<Tuple<string,double>>
			// IEnumerable gives me a a type of abstraction
			// and flexbility as other classes to cast the output to any other collection implementing IEnumerable
			// and non mutable which means others can't change its value to implement security
			return cartPrices;
		}
		private static void RemoveItem()
		{
			ViewCart();
			if (cartItems.Any())
			{
				Console.WriteLine("Please select item to remove: ");
				string itemToRemove = Console.ReadLine();

				// using contains not containsKey cuz i wants to check the current availables in cartItems List 
				// lists do not have key values but has a group of items
				if (cartItems.Contains(itemToRemove))
				{
					cartItems.Remove(itemToRemove);

					// saving action in stack
					actions.Push($"Item {itemToRemove} removed from cart");

					Console.WriteLine($"{itemToRemove} item is removed");
				}
				else Console.WriteLine("Item doesn't exists in shopping cart!!");
			}
		}
		private static void Checkout()
		{
			if (cartItems.Any())
			{
				double totalPrice = 0;
				Console.WriteLine("Your cart items are: ");

				IEnumerable<Tuple<string, double>> itemsInCart = GetCartPrices();
				foreach (var item in itemsInCart)
				{
					totalPrice += item.Item2;
					Console.WriteLine(item.Item1 + " " + item.Item2);
				}
				Console.WriteLine($"Total price to pay: {totalPrice}");
				Console.WriteLine("Please proceed to payment, Thank you for shopping with us");
				cartItems.Clear();

				// can not save action in stack cuz customer already paid
				actions.Push("Checkout");
			}
			else Console.WriteLine("Your cart is empty!!");
		}
		private static void Undo()
		{
			// first i need to save all actions in data structure/collection
			// in this case we aill use STACK ==>> cuz it goes by LIFO rule(last in first out) 
			
			if (actions.Count > 0)
			{
				// pop is used to bring the last action saved in the Stack
				string lastAction = actions.Pop();
				Console.WriteLine($"TYour last action is {lastAction}");

				// since i saved the action by saying what method has occured(added, removed, Checkout)

				// to search for the in actions message
				// when no argument is written in split method then the separator is==>>space
				var actionArray = lastAction.Split();        
				
				if (lastAction.Contains("added"))
				{
					// 1. if it says added==>>>> actions.Push($"Item {cartItem} added to cart");

					// i need to remove added the item
					// search the item in actions message==>> it is the second index numbered 1
					cartItems.Remove(actionArray[1]);
				}
				else if (lastAction.Contains("removed"))
				{
					//2.  if it says removed==>>>> actions.Push($"Item {itemToRemove} removed from cart");

					// i need to add the removed item
					// search the item in actions message==>> it is the second index numbered 1
					cartItems.Add(actionArray[1]);
				}
			}
		}
	}
}
