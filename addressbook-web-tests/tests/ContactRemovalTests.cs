using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int numberOfContact = 3;
            if (app.Contacts.ContactsCount() >= numberOfContact)
            {
                app.Contacts.Remove(numberOfContact);
            }
            else
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                app.Contacts.Remove(app.Contacts.FindLastAddedContactNumber());
            }
        }
    }
}
