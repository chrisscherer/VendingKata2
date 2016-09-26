using System;
using NUnit.Framework;


namespace VendingKataTake2Tests
{
	[TestFixture]
	class VendingMachineTests
	{
		[SetUp] public void Init ()
		{
		}

		[TearDown] public void Dispose ()
		{
		}

		[Test]
		public void InsertCoin_ReturnTrueIfValid ()
		{
			bool result = testVendingMachine.InsertCoin (5);

			Assert.AreEqual (true, result);
		}
	}
}
