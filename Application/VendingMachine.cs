using System;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public int Amount { get; private set; }

		public bool InsertCoin (int coinSize)
		{
			if (coinSize <= 0)
				return false;

			Amount += coinSize;
			return true;
		}


		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
