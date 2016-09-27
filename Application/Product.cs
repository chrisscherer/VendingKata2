using System;

namespace VendingKataTake2
{
	public class Product
	{
		public string Name { get; private set; }

		public decimal Price { get; private set; }

		public Product (string name, decimal price)
		{
			Name = name;
			Price = price;
		}

		//I grabbed the next section off of stack overflow so I could check for product list equivalency
		public override int GetHashCode ()
		{
			int hash = 23;
			hash = hash * 31 + Name == null ? 0 : Name.GetHashCode ();
			hash = hash * 31 + Price.GetHashCode ();
			return hash;
		}

		public override bool Equals (object other)
		{
			return Equals (other as Product);
		}

		public bool Equals (Product other)
		{
			return other != null &&
			this.Name == other.Name &&
			this.Price == other.Price;
		}
	}
}

