using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newdata = new ContactData("Ivan", "Ivanov");
            app.Contacts.Modify(1, newdata);
        }
    }
}
