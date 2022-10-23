using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int numberOfContact = 100;
            ContactData newdata = new ContactData("Ivan", "Ivanov");
            if (app.Contacts.ContactsCount() < numberOfContact)
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                numberOfContact = app.Contacts.FindLastAddedContactNumber();
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(numberOfContact, newdata);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[numberOfContact-1].Firstname = newdata.Firstname;
            oldContacts[numberOfContact-1].Lastname = newdata.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
