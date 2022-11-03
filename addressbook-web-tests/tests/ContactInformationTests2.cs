using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests2 : TestBase
    {

        [Test]
        public void TestContactInformation2()
        {
            Assert.AreEqual(app.Contacts.GetContactInformationFromEditFormFull(0), app.Contacts.GetContactInformationFromDetailView(0);
        }
    }
}
