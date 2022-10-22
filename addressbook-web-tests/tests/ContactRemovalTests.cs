using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        //[Test]
        //public void ContactRemovalTest()
        //{
        //    int numberOfContact = 3;
        //    if (app.Contacts.ContactsCount() >= numberOfContact)
        //    {
        //        app.Contacts.Remove(numberOfContact);
        //    }
        //    else
        //    {
        //        ContactData test = new ContactData("test", "test");
        //        app.Contacts.Create(test);
        //        app.Contacts.Remove(app.Contacts.FindLastAddedContactNumber());
        //    }
        //}

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
