using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper:HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Modify(int p, GroupData newdata)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupExists() == true)
            {
                SelectGroup(p);
                InitGroupModification();
                FillGroupForm(newdata);
                SubmitGroupModification();
                ReturnToGroupsPage();
            }
            else
            {
                GroupData groupData = new GroupData("test");
                Create(groupData);
                Modify(1, newdata);
            }
            
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupExists() == true)
            {
                SelectGroup(p);
                RemoveGroup();
                ReturnToGroupsPage();
            }
            else
            {
                GroupData groupData = new GroupData("test");
                Create(groupData);
                Remove(1);
            }

            return this;
        }

        private void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }

        public bool GroupExists()
        {
            ReturnToGroupsPage();
            bool result = false;
            try
            {
                if (driver.FindElements(By.XPath("//span[@class='group']")).Count > 0)
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span["+p+"]/input")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[6]")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.Footer);
            return this;
        }
    }
}
