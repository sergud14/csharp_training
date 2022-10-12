using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contactData = new ContactData("John", "Johnson");
            FillContactForm(contactData);
            SubmitContactCreation();
            ReturnToContactsPage();
        }
    }
}
