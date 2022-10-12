using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("John", "Johnson");
            app.Contacts.Create(contact);
        }
    }
}
