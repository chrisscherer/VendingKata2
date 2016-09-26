using System;
using System.Collections.Generic;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public int DepositedAmount { get; private set; }

		public Dictionary<int, int> ValidCoins = new Dictionary<int, int> () {
			{ 5, 5 },
			{ 10, 10 },
			{ 25, 25 }
		};

		public bool InsertCoin (int coinSize)
		{
			if (!CoinIsValid (coinSize))
				return false;

			AddAmount (coinSize);
			return true;
		}

		private void AddAmount (int amountToAdd)
		{
			DepositedAmount += amountToAdd;
		}

		private bool CoinIsValid (int coinDimensions)
		{
			return ValidCoins.ContainsKey (coinDimensions);
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
