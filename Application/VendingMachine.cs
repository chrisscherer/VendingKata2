using System;
using System.Collections.Generic;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public List<Coin> DepositedAmount { get; private set; }

		public List<Coin> CoinReturnAmount { get; private set; }

		private List<Product> Products { get; set; }

		public Dictionary<int, int> ValidCoins = new Dictionary<int, int> () {
			{ 5, 5 },
			{ 10, 10 },
			{ 25, 25 }
		};

		public VendingMachine ()
		{
			DepositedAmount = new List<Coin> ();
			CoinReturnAmount = new List<Coin> ();
			Products = new List<Product> ();

			InitializeProducts ();
		}


		public bool InsertCoin (Coin insertedCoin)
		{
			if (!CoinIsValid (insertedCoin))
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

		public List<Product> GetProductList ()
		{
			return Products;
		}

		private void AddAmount (Coin coinToAdd)
		{
			DepositedAmount.Add (coinToAdd);
		}

		private bool CoinIsValid (Coin coin)
		{
			int coinWeight;

			//I believe this is the most efficient way to test both that the Key exists and that the value is the one we want.
			if (ValidCoins.TryGetValue (coin.Size, out coinWeight)) {
				return coinWeight == coin.Weight;
			} else {
				return false;
			}
		}

		private void ResetDepositedAmount ()
		{
			DepositedAmount.Clear ();
		}

		private void ResetCoinReturnAmount ()
		{
			CoinReturnAmount.Clear ();
		}

		private void InitializeProducts ()
		{
			Products.Add (new Product ("Cola", 1.00M));
			Products.Add (new Product ("Chips", .50M));
			Products.Add (new Product ("Candy", .65M));
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
		}
	}
}
