using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    { 
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            manager.Contacts.InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newdata)
        {
            manager.Navigator.GoToHomePage();
            OpenEditForm(p);
            FillContactForm(newdata);
            SubmitContactUpdate();
            ReturnToContactsPage();

            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeleteContact();
            ReturnToContactsPage();

            return this;
        }
        private ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactsCache = null;
            return this;
        }

        private ContactHelper SelectContact(int p)
        {
            driver.FindElement(By.XPath("(//input[@type='checkbox'][not(contains(@id,'MassCB'))])[" + p + "]")).Click();
            return this;
        }

        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.XPath("//a[text()='home']")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactsCache = null;
            return this;
        }

        public ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("//input[@name='update'][2]")).Click();
            contactsCache = null;
            return this;
        }

        public bool ContactExists()
        {
            bool result = false;
            try
            {
                ReturnToContactsPage();
                if (driver.FindElements(By.XPath("//table//tr[@class]")).Count > 0)
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

        private List<ContactData> contactsCache=null;
        public List<ContactData> GetContactList()
        {
            if (contactsCache == null)
            {
                contactsCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                var elementsLastName = driver.FindElements(By.XPath("//table//tr//td[2]"));
                var elementsFirstName = driver.FindElements(By.XPath("//table//tr//td[3]"));
                for (int i = 0; i < elementsLastName.Count; i++)
                {
                    contactsCache.Add(new ContactData(elementsFirstName[i].Text, elementsLastName[i].Text));
                }
            }
            return new List<ContactData>(contactsCache);
        }


        public int ContactsCount()
        {
            int result = 0;
            try
            {
                ReturnToContactsPage();
                result = driver.FindElements(By.XPath("//table//tr[@class]")).Count;
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public int FindLastAddedContactNumber()
        {
            int result = 0;
            try
            {
                ReturnToContactsPage();
                var rows= driver.FindElements(By.XPath("//table//tr[@class]/td/input[@id]"));
                int[] arrId=new int[rows.Count];
                int[] sortedArrId = new int[rows.Count];

                for (int i = 0; i < rows.Count; i++)
                {
                    By contactRow = By.XPath("//table//tr[@class]/td/input[@id]");
                    int id = Int32.Parse(driver.FindElement((By.XPath("(//table//tr[@class]/td/input[@id])["+(i+1)+"]"))).GetAttribute("value"));
                    arrId[i]=id;
                    sortedArrId[i]=id;
                }

                Array.Sort(sortedArrId);
                int max = sortedArrId[sortedArrId.Length-1];
                string resultmax = max.ToString();

                int j = 0;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (arrId[i] == max)
                    {
                        j = i+1;
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

        public ContactHelper FillContactForm(ContactData contactdata)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactdata.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactdata.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactdata.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contactdata.Nickname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contactdata.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contactdata.Company);
            driver.FindElement(By.XPath("//input[@name='photo']")).SendKeys(contactdata.Photo);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contactdata.Address);
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contactdata.Home);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactdata.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contactdata.Work);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contactdata.Fax);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contactdata.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contactdata.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contactdata.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contactdata.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactdata.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactdata.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contactdata.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactdata.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactdata.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contactdata.Ayear);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contactdata.Address2);
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contactdata.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contactdata.Notes);
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper OpenEditForm(int p)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])["+p+"]")).Click();
            return this;
        }
    }
}
