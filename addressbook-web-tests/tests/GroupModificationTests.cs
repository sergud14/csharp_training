using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int numberOfGroup = 100;
            GroupData newdata = new GroupData("name2");
            newdata.Header = "header2";
            newdata.Footer = "footer2";
            if (app.Groups.GroupsCount() < numberOfGroup)
            {
                GroupData groupData = new GroupData("test");
                app.Groups.Create(groupData);
                numberOfGroup = app.Groups.FindLastAddedGroupNumber();
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(numberOfGroup, newdata);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[numberOfGroup-1].Name = newdata.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(newGroups, oldGroups);
        }
    }
}
