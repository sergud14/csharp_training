using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        //private string firstname;
        //private string lastname;
        //private string middlename;
        //private string nickname= "nickname";
        //private string title = "title";
        //private string company= "company";
        private string photo = Directory.GetCurrentDirectory() + @"\test.jpg";
        //private string address = "address";
        //private string home = "123456789";
        //private string mobile = "123456789";
        //private string work = "123456789";
        private string allPhones;
        //private string fax = "123456789";
        //private string email = "email";
        //private string email2 = "email2";
        //private string email3 = "email3";
        //private string homepage = "homepage";
        //private string bday = "1";
        //private string bmonth = "January";
        //private string byear = "1990";
        //private string aday = "1";
        //private string amonth = "January";
        //private string ayear = "1990";
        //private string group = "[none]";
        //private string address2 = "address2";
        //private string phone2 = "phone2";
        //private string notes = "notes";

        public ContactData(string firstname,string lastname)
    {
            Firstname = firstname;
            Lastname = lastname;
    }

    public string Firstname{get;set;}

    public string Lastname { get; set; }
    
    public string Middlename { get; set; }

     public string Nickname { get; set; }
   
    public string Title { get; set; }
   
    public string Company { get; set; }
    
    public string Photo { get; set; } = Directory.GetCurrentDirectory() + @"\test.jpg";

    public string Address { get; set; }
        
    public string HomePhone { get; set; }

    public string MobilePhone { get; set; }

    public string WorkPhone { get; set; }

    public string AllPhones
    {
        get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone);
                }
            }
        set { allPhones = value; }
    }

        private string CleanUp(string phone)
        {
            if (phone == null)
            {
                return "";
            
            }

            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

    public string Fax { get; set; }

    public string Email{ get; set; }

    public string Email2 { get; set; }

    public string Email3 { get; set; }

    public string Homepage { get; set; }

    public string Bday { get; set; }

    public string Bmonth { get; set; }

    public string Byear { get; set; }

    public string Aday { get; set; }

    public string Amonth { get; set; }

    public string Ayear { get; set; }

    public string Address2 { get; set; }

    public string Group { get; set; }

    public string Phone2 { get; set; }

    public string Notes { get; set; }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (Firstname == other.Firstname && Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            var result = Lastname.CompareTo(other.Lastname);
            if (result != 0) return result;
            return Firstname.CompareTo(other.Firstname);
        }
    }
}
