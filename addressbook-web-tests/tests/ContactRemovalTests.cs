using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int numberOfContact = 100;
            if (app.Contacts.ContactsCount() < numberOfContact)
            {
                ContactData test = new ContactData("test", "test");
                app.Contacts.Create(test);
                numberOfContact = app.Contacts.FindLastAddedContactNumber();
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(numberOfContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(numberOfContact-1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
