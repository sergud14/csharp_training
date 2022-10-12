using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTests:TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupHelper.InitGroupCreation();
            GroupData groupData = new GroupData("name");
            groupData.Header = "header";
            groupData.Footer = "footer";
            app.GroupHelper.FillGroupForm(groupData);
            app.GroupHelper.SubmitGroupCreation();
            app.GroupHelper.ReturnToGroupsPage();
        }
    }
}
