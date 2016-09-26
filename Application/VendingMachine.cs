using System;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public bool InsertCoin (int coinSize)
		{
			if (coinSize <= 0)
				return false;
			
			return true;
		}


		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
