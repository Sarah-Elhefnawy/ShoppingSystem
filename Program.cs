
namespace ShoppingSystem
{
	internal class Program
	{
		// written in namespace so cart value is available to all methods
		// static so that easily available without making instance/object to access
		// STOCK
		static public List<string> cartItems = new List<string>();

		// items in store are simple starting with only name and price
		// saved in dictionary since it is a key value types so consists of key and its value
		// dictionary is generic type
		// USER SHOPPING CART
		static public Dictionary<string, double> itemPrices = new Dictionary<string, double>()
		{
			{"Camera",1500 },
			{"Laptop",3000 },
			{"TV",2500 }
		};
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

			if (itemPrices.ContainsKey(cartItem))
			{
				cartItems.Add(cartItem);
				Console.WriteLine($"Item {cartItem} is added to your cart");
			}
			else Console.WriteLine("Item is out of stock or not available");
		}
		private static void ViewCart()
		{
			Console.WriteLine("Your cart items :");

			if (cartItems.Any())
			{
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
			throw new NotImplementedException();
		}
		private static void Checkout()
		{
			throw new NotImplementedException();
		}
		private static void Undo()
		{
			throw new NotImplementedException();
		}
	}
}
