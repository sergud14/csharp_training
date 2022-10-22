using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        //[Test]
        //public void GroupRemovalTest()
        //{
        //    int numberOfGroup = 5;
        //    if (app.Groups.GroupsCount() >= numberOfGroup)
        //    {
        //        app.Groups.Remove(numberOfGroup);
        //    }
        //    else
        //    {
        //        GroupData groupData = new GroupData("test");
        //        app.Groups.Create(groupData);
        //        app.Groups.Remove(app.Groups.FindLastAddedGroupNumber());
        //    }
        //}


        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}