
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
				foreach (var Item in cartItems)
				{
					// item name
					Console.WriteLine($"Item :{Item}");

					// item price

				}
			}
			else Console.WriteLine("Cart is empty!!");
				
		}
		private static void GetCartPrices()
		{

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
