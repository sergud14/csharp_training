using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class GroupCreationTests:TestBase
    {


        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(10))
                {
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10),

                });
            }
                return groups;
        }

        [Test,TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
