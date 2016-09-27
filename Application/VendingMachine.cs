using System;
using System.Linq;
using System.Collections.Generic;

namespace VendingKataTake2
{
	public class VendingMachine
	{
		public List<Coin> DepositedAmount { get; private set; }

		public List<Coin> CoinReturnAmount { get; private set; }

		private List<Product> Products { get; set; }

		public Dictionary<decimal, decimal> ValidCoins = new Dictionary<decimal, decimal> () {
			{ .05M, .05M },
			{ .10M, .10M },
			{ .25M, .25M }
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

		//Is introducing linq at this point breaking TDD? I still don't quite know how hard I'm supposed to stick to
		//only adding things when they're absolutely necessary for getting a test green vs. readability and ease of writing
		public decimal GetProductPrice (string productName)
		{
			return Products.Single (x => x.Name == productName).Price;
		}

		public bool PurchaseProduct (string productName)
		{
			bool success = false;

			if (GetDepositedTotal () >= GetProductPrice (productName)) {
				RefundExtraCoins (GetDepositedTotal () - GetProductPrice (productName));
				ResetDepositedAmount ();
				success = true;
			}

			return success;
		}

		//Should possible be called GetDepositedAmount, I made a distinction because this is returning a Sum total
		//where as the DepositedAmount is a list of coins.
		public decimal GetDepositedTotal ()
		{
			return DepositedAmount.Sum (coin => coin.Size);
		}

		//This ugliness was caused by my deciding to try to model my coin containers in a more real world application style
		private void RefundExtraCoins (decimal extraFunds)
		{
			while (extraFunds > 0M) {
				decimal largestCoin = GetLargestCoinIncrement (extraFunds);
				CoinReturnAmount.Add (new Coin (largestCoin, largestCoin));
				extraFunds -= largestCoin;
			}
		}

		private decimal GetLargestCoinIncrement (decimal input)
		{
			if (input >= .25M)
				return .25M;
			else if (input >= .10M)
				return .10M;
			else if (input >= .05M)
				return .05M;
			else
				return 0M;
		}

		private void AddAmount (Coin coinToAdd)
		{
			DepositedAmount.Add (coinToAdd);
		}

		private bool CoinIsValid (Coin coin)
		{
			decimal coinWeight;

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
