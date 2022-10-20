using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests:TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numberOfGroup = 5;
            if (app.Groups.GroupsCount() >= numberOfGroup)
            {
                app.Groups.Remove(numberOfGroup);
            }
            else
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                app.Groups.Remove(app.Groups.FindLastAddedGroupNumber());
            }
        }
    }
}
