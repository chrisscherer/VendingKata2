using System;

namespace VendingKataTake2
{
	//The size and weight of the coin are the same as it's value for ease of use.
	public class Coin
	{
		public decimal Weight { get; private set; }

		public decimal Size { get; private set; }

		public Coin (decimal size, decimal weight)
		{
			Weight = weight;
			Size = size;
		}

		//I grabbed the next section off of stack overflow so I could check for product list equivalency
		public override int GetHashCode ()
		{
			int hash = 23;
			hash = hash * 31 + Weight.GetHashCode ();
			hash = hash * 31 + Size.GetHashCode ();
			return hash;
		}

		public override bool Equals (object other)
		{
			return Equals (other as Coin);
		}

		public bool Equals (Coin other)
		{
			return other != null &&
			this.Weight == other.Weight &&
			this.Size == other.Size;
		}
	}
}

