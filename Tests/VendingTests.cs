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
		public void InsertCoin_ReturnTrueIfValidCoinDimensions ()
		{
			bool result = testVendingMachine.InsertCoin (5);

			Assert.AreEqual (true, result);
		}

		[Test]
		public void InsertCoin_ReturnFalseIfInvalidCoinDimensions ()
		{
			bool result = testVendingMachine.InsertCoin (-1);

			Assert.AreEqual (false, result);
		}

		[Test]
		public void InsertCoin_UpdatesCurrentDepositedAmount ()
		{
			testVendingMachine.InsertCoin (5);

			Assert.AreEqual (5, testVendingMachine.DepositedAmount);
		}
	}
}
