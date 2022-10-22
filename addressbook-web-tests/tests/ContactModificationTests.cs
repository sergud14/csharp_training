using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        //[Test]
        //public void ContactModificationTest()
        //{
        //    int numberOfContact = 3;
        //    ContactData newdata = new ContactData("Ivan", "Ivanov");
        //    if (app.Contacts.ContactsCount() >= numberOfContact)
        //    {
        //        app.Contacts.Modify(numberOfContact, newdata);
        //    }
        //    else
        //    {
        //        ContactData test = new ContactData("test", "test");
        //        app.Contacts.Create(test);
        //        app.Contacts.Modify(app.Contacts.FindLastAddedContactNumber(), newdata);
        //    }
        //}


        [Test]
        public void ContactModificationTest()
        {
            ContactData newdata = new ContactData("Ivan", "Ivanov");
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, newdata);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newdata.Firstname;
            oldContacts[0].Lastname = newdata.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }


    }
}
