using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newdata = new GroupData("name2");
            newdata.Header = "header2";
            newdata.Footer = "footer2";
            app.Groups.Modify(1, newdata);
        }
    }
}
