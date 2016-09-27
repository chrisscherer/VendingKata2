using System;

namespace VendingKataTake2
{
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

