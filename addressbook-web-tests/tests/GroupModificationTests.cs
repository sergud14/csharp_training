using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        //[Test]
        //public void GroupModificationTest()
        //{
        //    int numberOfGroup = 5;
        //    GroupData newdata = new GroupData("name2");
        //    newdata.Header = "header2";
        //    newdata.Footer = "footer2";
        //    if (app.Groups.GroupsCount() >= numberOfGroup)
        //    { 
        //        app.Groups.Modify(numberOfGroup, newdata);
        //    }
        //    else 
        //    {
        //        GroupData groupData = new GroupData("test");
        //        app.Groups.Create(groupData);
        //        app.Groups.Modify(app.Groups.FindLastAddedGroupNumber(), newdata);
        //    }
        //}

        [Test]
        public void GroupModificationTest()
        {
            GroupData newdata = new GroupData("name2");
            newdata.Header = "header2";
            newdata.Footer = "footer2";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newdata);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newdata.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(newGroups, oldGroups);
        }


    }
}
