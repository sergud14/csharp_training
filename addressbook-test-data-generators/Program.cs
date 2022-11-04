using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;
using System.IO;

namespace addressbook_test_data_generators
{
    public class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];


            if (type == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(5))
                    {
                        Header = TestBase.GenerateRandomString(5),
                        Footer = TestBase.GenerateRandomString(5)
                    });
                }
                if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXMLFile(groups, writer);
                }

                void writeGroupsToJsonFile(List<GroupData> groupData, StreamWriter streamWriter)
                {
                    streamWriter.Write(JsonConvert.SerializeObject(groupData, Newtonsoft.Json.Formatting.Indented));
                }

                void writeGroupsToXMLFile(List<GroupData> groupData, StreamWriter streamWriter)
                {
                    new XmlSerializer(typeof(List<GroupData>)).Serialize(streamWriter, groupData);
                }
            }
            else if (type == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(5),
                        Lastname = TestBase.GenerateRandomString(5),
                        Middlename = TestBase.GenerateRandomString(5),
                        Nickname = TestBase.GenerateRandomString(5),
                        Title = TestBase.GenerateRandomString(5),
                        Company = TestBase.GenerateRandomString(5),
                        Address = TestBase.GenerateRandomString(5),
                        HomePhone = TestBase.GenerateRandomString(5),
                        MobilePhone = TestBase.GenerateRandomString(5),
                        WorkPhone = TestBase.GenerateRandomString(5),
                        Fax = TestBase.GenerateRandomString(5),
                        Email = TestBase.GenerateRandomString(5),
                        Email2 = TestBase.GenerateRandomString(5),
                        Email3 = TestBase.GenerateRandomString(5),
                        Homepage = TestBase.GenerateRandomString(5),
                        Address2 = TestBase.GenerateRandomString(5),
                        Phone2 = TestBase.GenerateRandomString(5),
                        Notes = TestBase.GenerateRandomString(5),
                        Bday = TestBase.RandomDay(),
                        Bmonth = TestBase.RandomMonth(),
                        Byear = TestBase.RandomYear(),
                        Aday = TestBase.RandomDay(),
                        Amonth = TestBase.RandomMonth(),
                        Ayear = TestBase.RandomYear()

                    });
                }
                if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXMLFile(contacts, writer);
                }

                void writeContactsToJsonFile(List<ContactData> contactData, StreamWriter streamWriter)
                {
                    streamWriter.Write(JsonConvert.SerializeObject(contactData, Newtonsoft.Json.Formatting.Indented));
                }

                void writeContactsToXMLFile(List<ContactData> contactData, StreamWriter streamWriter)
                {
                    new XmlSerializer(typeof(List<ContactData>)).Serialize(streamWriter, contactData);
                }
            }
            writer.Close();
        }
    }
}
