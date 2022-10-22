using OpenQA.Selenium;
using System;
using System.Collections.Generic;

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

            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newdata);
            SubmitGroupModification();
            ReturnToGroupsPage();
            
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();

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

        public int GroupsCount()
        {
            ReturnToGroupsPage();
            int result = 0;
            try
            {
                result = driver.FindElements(By.XPath("//span[@class='group']")).Count;
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData> ();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements=driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public int FindLastAddedGroupNumber()
        {
            int result = 0;
            try
            {
                ReturnToGroupsPage();
                var rows = driver.FindElements(By.XPath("//span[@class='group']//input"));
                int[] arrId = new int[rows.Count];
                int[] sortedArrId = new int[rows.Count];

                for (int i = 0; i < rows.Count; i++)
                {
                    By contactRow = By.XPath("//span[@class='group']//input");
                    int id = Int32.Parse(driver.FindElement((By.XPath("(//span[@class='group']//input)[" + (i + 1) + "]"))).GetAttribute("value"));
                    arrId[i] = id;
                    sortedArrId[i] = id;
                }

                Array.Sort(sortedArrId);
                int max = sortedArrId[sortedArrId.Length - 1];
                string resultmax = max.ToString();

                int j = 0;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (arrId[i] == max)
                    {
                        j = i + 1;
                    }
                }

                result = j;
            }
            catch
            {
                result = 0;
            }

            return result;
        }



        public GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span["+(p+1)+"]/input")).Click();
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
