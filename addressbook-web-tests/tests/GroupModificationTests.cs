using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int numberOfGroup = 5;
            GroupData newdata = new GroupData("name2");
            newdata.Header = "header2";
            newdata.Footer = "footer2";
            if (app.Groups.GroupsCount() >= numberOfGroup)
            { 
                app.Groups.Modify(numberOfGroup, newdata);
            }
            else 
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                app.Groups.Modify(app.Groups.FindLastAddedGroupNumber(), newdata);
            }
        }
    }
}
