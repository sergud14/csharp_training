using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTests:TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData groupData = new GroupData("name");
            groupData.Header = "header";
            groupData.Footer = "footer";
            FillGroupForm(groupData);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}
