using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.ContactHelper.InitContactCreation();
            ContactData contactData = new ContactData("John", "Johnson");
            app.ContactHelper.FillContactForm(contactData);
            app.ContactHelper.SubmitContactCreation();
            app.ContactHelper.ReturnToContactsPage();
        }
    }
}
