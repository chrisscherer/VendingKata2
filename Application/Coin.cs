using System;

namespace VendingKataTake2
{
	//The size and weight of the coin are the same as it's value for ease of use.
	public class Coin
	{
		public int Weight { get; private set; }

		public int Size { get; private set; }

		public Coin (int size, int weight)
		{
			Weight = weight;
			Size = size;
		}
	}
}

