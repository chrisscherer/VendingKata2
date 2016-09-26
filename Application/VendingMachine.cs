using System;
using System.Collections.Generic;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public int DepositedAmount { get; private set; }

		public int CoinReturnAmount { get; private set; }

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

		public void ReturnCoins ()
		{
			DepositedAmount = 0;
		}

		public void ClearCoinReturn ()
		{
			CoinReturnAmount = 0;
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
