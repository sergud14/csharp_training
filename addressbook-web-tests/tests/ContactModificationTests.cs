using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int numberOfContact = 30;
            ContactData newdata = new ContactData("Ivan", "Ivanov");
            if (app.Contacts.ContactsCount() < numberOfContact)
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                numberOfContact = app.Contacts.FindLastAddedContactNumber();
            }
                app.Contacts.Modify(numberOfContact, newdata);
        }
    }
}
