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

		public bool InsertCoin (Coin insertedCoin)
		{
			if (!CoinIsValid (insertedCoin.Size, insertedCoin.Weight))
				return false;

			AddAmount (insertedCoin);
			return true;
		}

		public void ReturnCoins ()
		{
			CoinReturnAmount += DepositedAmount;
			ResetDepositedAmount ();
		}

		//TakeCoinReturnCoins? I wasn't sure what the best name for this method is/was
		public int ClearCoinReturn ()
		{
			int amountToReturn = CoinReturnAmount;
			ResetCoinReturnAmount ();

			return amountToReturn;
		}

		private void AddAmount (Coin coinToAdd)
		{
			DepositedAmount += coinToAdd.Size;
		}

		private bool CoinIsValid (int coinSize, int coinWeight)
		{
			return (ValidCoins.ContainsKey (coinSize) && ValidCoins [coinSize] == coinWeight);
		}

		private void ResetDepositedAmount ()
		{
			DepositedAmount = 0;
		}

		private void ResetCoinReturnAmount ()
		{
			CoinReturnAmount = 0;
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
