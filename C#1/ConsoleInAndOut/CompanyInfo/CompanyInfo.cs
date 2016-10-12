using System;

class CompanyInfo
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string faxNumber = Console.ReadLine();
        string website = Console.ReadLine();
        string manegersFirstName = Console.ReadLine();
        string manegersLastName = Console.ReadLine();
        uint manegersAge = uint.Parse(Console.ReadLine());
        string manegersPhoneNumber = Console.ReadLine();
        Console.WriteLine(companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Tel. " + phoneNumber);
        Console.WriteLine("Fax: {0}", faxNumber == "" ? "(no fax)" : faxNumber);
        Console.WriteLine("Web site: " + website);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", manegersFirstName, manegersLastName, manegersAge, manegersPhoneNumber);
    }
}