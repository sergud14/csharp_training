using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int numberOfGroup = 50;
            GroupData newdata = new GroupData("name2");
            newdata.Header = "header2";
            newdata.Footer = "footer2";
            if (app.Groups.GroupsCount() < numberOfGroup)
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                numberOfGroup = app.Groups.FindLastAddedGroupNumber();
            }
                app.Groups.Modify(numberOfGroup, newdata);
        }
    }
}
