using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int numberOfContact = 3;
            ContactData newdata = new ContactData("Ivan", "Ivanov");
            if (app.Contacts.ContactsCount() >= numberOfContact)
            {
                app.Contacts.Modify(numberOfContact, newdata);
            }
            else
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                app.Contacts.Modify(app.Contacts.FindLastAddedContactNumber(), newdata);
            }
        }
    }
}
