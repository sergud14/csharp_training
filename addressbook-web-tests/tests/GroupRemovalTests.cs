using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests:TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numberOfGroup = 50;
            if (app.Groups.GroupsCount() < numberOfGroup)
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                numberOfGroup = app.Groups.FindLastAddedGroupNumber();
            }
                app.Groups.Remove(numberOfGroup);
        }
    }
}
