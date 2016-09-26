using System;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public int DepositedAmount { get; private set; }

		public bool InsertCoin (int coinSize)
		{
			if (coinSize <= 0)
				return false;

			AddAmount (coinSize);
			return true;
		}

		private void AddAmount (int amountToAdd)
		{
			DepositedAmount += amountToAdd;
		}


		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
