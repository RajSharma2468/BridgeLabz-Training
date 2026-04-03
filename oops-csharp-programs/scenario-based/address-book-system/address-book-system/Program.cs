using System;
using System.Threading.Tasks;
using AddressBookSystem.Models;
using AddressBookSystem.Services;

namespace AddressBookSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AddressBookService service = new AddressBookService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Contact contact = GetContactInput();

                        if (ValidationService.ValidateObject(contact))
                        {
                            await service.AddContactAsync(contact);
                            Console.WriteLine("Contact Added");
                        }
                        break;

                    case 2:
                        var list = await service.GetAllContactsAsync();
                        foreach (var c in list)
                        {
                            Console.WriteLine(c.Id + " " + c.FirstName + " " + c.City);
                        }
                        break;

                    case 3:
                        Console.Write("Enter Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        await service.DeleteContactAsync(id);
                        Console.WriteLine("Deleted");
                        break;

                    case 4:
                        exit = true;
                        break;
                }
            }
        }

        static Contact GetContactInput()
        {
            Contact contact = new Contact();

            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("City: ");
            contact.City = Console.ReadLine();

            Console.Write("State: ");
            contact.State = Console.ReadLine();

            Console.Write("Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            return contact;
        }
    }
}
