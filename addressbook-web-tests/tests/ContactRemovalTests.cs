using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int numberOfContact = 30;
            if (app.Contacts.ContactsCount() < numberOfContact)
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                numberOfContact = app.Contacts.FindLastAddedContactNumber();
            }
                app.Contacts.Remove(numberOfContact);
        }
    }
}
