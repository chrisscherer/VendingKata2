using System;
using System.Collections.Generic;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public List<Coin> DepositedAmount { get; private set; }

		public List<Coin> CoinReturnAmount { get; private set; }

		public VendingMachine ()
		{
			DepositedAmount = new List<Coin> ();
			CoinReturnAmount = new List<Coin> ();
		}

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
			CoinReturnAmount.AddRange (DepositedAmount);
			ResetDepositedAmount ();
		}

		//TakeCoinReturnCoins? I wasn't sure what the best name for this method is/was
		public List<Coin> ClearCoinReturn ()
		{
			List<Coin> amountToReturn = new List<Coin> (CoinReturnAmount);
			ResetCoinReturnAmount ();

			return amountToReturn;
		}

		private void AddAmount (Coin coinToAdd)
		{
			DepositedAmount.Add (coinToAdd);
		}

		private bool CoinIsValid (int coinSize, int coinWeight)
		{
			return (ValidCoins.ContainsKey (coinSize) && ValidCoins [coinSize] == coinWeight);
		}

		private void ResetDepositedAmount ()
		{
			DepositedAmount.Clear ();
		}

		private void ResetCoinReturnAmount ()
		{
			CoinReturnAmount.Clear ();
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
