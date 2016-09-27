using System;
using System.Collections.Generic;
using VendingKataTake2;
using NUnit.Framework;


namespace VendingKataTake2Tests
{
	[TestFixture]
	class VendingMachineTests
	{
		VendingMachine testVendingMachine;

		List<Product> testProducts = new List<Product> () {
			new Product ("Cola", 1.00M),
			new Product ("Chips", .50M),
			new Product ("Candy", .65M)
		};

		[SetUp] public void Init ()
		{
			testVendingMachine = new VendingMachine ();
		}

		[TearDown] public void Dispose ()
		{
			testVendingMachine = null;
		}

		[Test]
		public void InsertCoin_ReturnTrueIfCoinIsNickel ()
		{
			Coin testNickel = new Coin (5, 5);

			bool result = testVendingMachine.InsertCoin (testNickel);

			Assert.AreEqual (true, result);
		}

		[Test]
		public void InsertCoin_ReturnFalseIfCoinSizeIsNegative ()
		{
			Coin testFakeCoin = new Coin (-1, -1);

			bool result = testVendingMachine.InsertCoin (testFakeCoin);

			Assert.AreEqual (false, result);
		}

		[Test]
		public void InsertCoin_ReturnFalseIfCoinSizeIsPositiveAndNotRealCoin ()
		{
			Coin testFakeCoin = new Coin (4, 4);

			bool result = testVendingMachine.InsertCoin (testFakeCoin);

			Assert.AreEqual (false, result);
		}

		[Test]
		public void InsertCoin_UpdatesCurrentDepositedAmount ()
		{
			Coin testNickel = new Coin (5, 5);

			testVendingMachine.InsertCoin (testNickel);

			Assert.AreEqual (new List<Coin> { testNickel }, testVendingMachine.DepositedAmount);
		}

		[Test]
		public void ReturnCoins_UpdatesCurrentDepositAmountToZero ()
		{
			testVendingMachine.ReturnCoins ();

			Assert.AreEqual (new List<Coin> (), testVendingMachine.DepositedAmount);
		}

		[Test]
		public void ClearCoinReturn_UpdatesCurrentCoinReturnAmountToZero ()
		{
			//Arrange our preconditions to using the Clear Coin Return Method
			Coin testNickel = new Coin (5, 5);
			testVendingMachine.InsertCoin (testNickel);
			testVendingMachine.ReturnCoins ();

			//Act by running the clear coin return method
			testVendingMachine.ClearCoinReturn ();

			//Assert the Coin Return Amount reflects zero
			Assert.AreEqual (new List<Coin> (), testVendingMachine.CoinReturnAmount);
		}

		[Test]
		public void ClearCoinReturn_ReturnsTheCorrectAmountFromTheCoinReturn ()
		{
			Coin testNickel = new Coin (5, 5);
			testVendingMachine.InsertCoin (testNickel);
			testVendingMachine.ReturnCoins ();

			List<Coin> returnedCoins = testVendingMachine.ClearCoinReturn ();

			Assert.AreEqual (new List<Coin> () { testNickel }, returnedCoins);
		}

		[Test]
		public void GetProductList_ReturnsAListOfProducts ()
		{
			//I originally set this test up this way, but I'm wondering if it wouldn't be better to have the Property be
			//a public getter with private setter and just test that the values are being initialized correctly.
			//The only problem with doing it that way is that the product list doesn't need to be public outside of being read
			//and should probably stay private.
			List<Product> products = testVendingMachine.GetProductList ();

			Assert.AreEqual (testProducts, products);
		}

		[Test]
		public void GetProductPrice_ReturnsThePriceOfAGivenProduct ()
		{
			decimal productPrice = testVendingMachine.GetProductPrice ("Candy");

			Assert.AreEqual (.65M, productPrice);
		}
	}
}
