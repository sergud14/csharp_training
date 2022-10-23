using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int numberOfGroup = 100;
            if (app.Groups.GroupsCount() < numberOfGroup)
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                numberOfGroup = app.Groups.FindLastAddedGroupNumber();
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(numberOfGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(numberOfGroup-1);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}