using System;
using System.IO;

namespace WebAddressbookTests
{ 
    public class ContactData
    {
    private string firstname;
    private string lastname;
    private string middlename = "middlename";
    private string nickname= "nickname";
    private string title = "title";
    private string company= "company";
    private string photo = Directory.GetCurrentDirectory()+ @"\test.jpg";
    private string address = "address";
    private string home = "123456789";
    private string mobile = "123456789";
    private string work = "123456789";
    private string fax = "123456789";
    private string email = "email";
    private string email2 = "email2";
    private string email3 = "email3";
    private string homepage = "homepage";
    private string bday = "1";
    private string bmonth = "January";
    private string byear = "1990";
    private string aday = "1";
    private string amonth = "January";
    private string ayear = "1990";
    private string group = "[none]";
    private string address2 = "address2";
    private string phone2 = "phone2";
    private string notes = "notes";

    public ContactData(string firstname,string lastname)
    {
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public string Firstname
    {
        get { return firstname; }      
        set { firstname = value; }
    }

    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }

    public string Middlename
    {
        get { return middlename; }
        set { middlename = value; }
    }

    public string Nickname
    {
        get { return nickname; }
        set { nickname = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Company
    {
        get { return company; }
        set { company = value; }
    }
    public string Photo
    {
        get { return photo; }
        set { photo = value; }
    }

        public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string Home
    {
        get { return home; }
        set { home = value; }
    }
    public string Mobile
    {
        get { return mobile; }
        set { mobile = value; }
    }

    public string Work
    {
        get { return work; }
        set { work = value; }
    }

        public string Fax
    {
        get { return fax; }
        set { fax = value; }
    }

    public string Email
        {
        get { return email; }
        set { email = value; }
    }

    public string Email2
    {
        get { return email2; }
        set { email2 = value; }
    }

    public string Email3
    {
        get { return email3; }
        set { email3 = value; }
    }

    public string Homepage
    {
        get { return homepage; }
        set { homepage = value; }
    }

    public string Bday
    {
        get { return bday; }
        set { bday = value; }
    }
    public string Bmonth
    {
        get { return bmonth; }
        set { bmonth = value; }
    }

    public string Byear
    {
        get { return byear; }
        set { byear = value; }
    }

    public string Aday
    {
        get { return aday; }
        set { aday = value; }
    }

    public string Amonth
    {
        get { return amonth; }
        set { amonth = value; }
    }

    public string Ayear
    {
        get { return ayear; }
        set { ayear = value; }
    }

    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }

    public string Phone2
    {
        get { return phone2; }
        set { phone2 = value; }
    }

    public string Notes
    {
        get { return notes; }
        set { notes = value; }
    }
    }
}
