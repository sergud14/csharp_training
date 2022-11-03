using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(3), GenerateRandomString(5))
                {
                    Firstname = GenerateRandomString(5),
                    Lastname = GenerateRandomString(5),
                    Middlename = GenerateRandomString(5),
                    Nickname = GenerateRandomString(5),
                    Title = GenerateRandomString(5),
                    Company = GenerateRandomString(5),
                    Address = GenerateRandomString(5),
                    HomePhone = GenerateRandomString(5),
                    MobilePhone = GenerateRandomString(5),
                    WorkPhone = GenerateRandomString(5),
                    Fax = GenerateRandomString(5),
                    Email = GenerateRandomString(5),
                    Email2 = GenerateRandomString(5),
                    Email3 = GenerateRandomString(5),
                    Homepage = GenerateRandomString(5),
                    Address2 = GenerateRandomString(5),
                    Phone2 = GenerateRandomString(5),
                    Notes = GenerateRandomString(5),
                    Bday = RandomDay(),
                    Bmonth = RandomMonth(),
                    Byear = RandomYear(),
                    Aday = RandomDay(),
                    Amonth = RandomMonth(),
                    Ayear = RandomYear()
                });
            }

            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
