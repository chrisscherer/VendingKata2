using System;
using VendingKataTake2;
using NUnit.Framework;


namespace VendingKataTake2Tests
{
	[TestFixture]
	class VendingMachineTests
	{
		VendingMachine testVendingMachine;

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
			bool result = testVendingMachine.InsertCoin (5);

			Assert.AreEqual (true, result);
		}

		[Test]
		public void InsertCoin_ReturnFalseIfCoinSizeIsNegative ()
		{
			bool result = testVendingMachine.InsertCoin (-1);

			Assert.AreEqual (false, result);
		}

		[Test]
		public void InsertCoin_ReturnFalseIfCoinSizeIsPositiveAndNotRealCoin ()
		{
			bool result = testVendingMachine.InsertCoin (4);

			Assert.AreEqual (false, result);
		}

		[Test]
		public void InsertCoin_UpdatesCurrentDepositedAmount ()
		{
			testVendingMachine.InsertCoin (5);

			Assert.AreEqual (5, testVendingMachine.DepositedAmount);
		}

		[Test]
		public void ReturnCoins_UpdatesCurrentDepositAmountToZero ()
		{
			testVendingMachine.ReturnCoins ();

			Assert.AreEqual (0, testVendingMachine.DepositedAmount);
		}

		[Test]
		public void ClearCoinReturn_UpdatesCurrentCoinReturnAmountToZero ()
		{
			//Arrange our preconditions to using the Clear Coin Return Method
			testVendingMachine.InsertCoin (5);
			testVendingMachine.ReturnCoins ();

			//Act by running the clear coin return method
			testVendingMachine.ClearCoinReturn ();

			//Assert the Coin Return Amount reflects zero
			Assert.AreEqual (0, testVendingMachine.CoinReturnAmount);
		}

		[Test]
		public void ClearCoinReturn_ReturnsTheCorrectAmountFromTheCoinReturn ()
		{
			testVendingMachine.InsertCoin (5);
			testVendingMachine.ReturnCoins ();

			int returnedAmount = testVendingMachine.ClearCoinReturn ();

			Assert.AreEqual (5, returnedAmount);
		}
	}
}
