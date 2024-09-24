
namespace ShoppingSystem
{
	internal class Program
	{
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

		private static void Undo()
		{
			throw new NotImplementedException();
		}

		private static void Checkout()
		{
			throw new NotImplementedException();
		}

		private static void RemoveItem()
		{
			throw new NotImplementedException();
		}

		private static void ViewCart()
		{
			throw new NotImplementedException();
		}

		private static void AddItem()
		{
			throw new NotImplementedException();
		}
	}
}
