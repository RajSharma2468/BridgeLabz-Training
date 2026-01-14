internal class AddressBookMenu
{
    private IAddressBook addressBookUtility;

    public AddressBookMenu()
    {
        addressBookUtility = new AddressBookUtility();
    }

    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n==== Welcome to Address Book ====\n");
            Console.WriteLine("1. Add a Contact");
            Console.WriteLine("2. Display all Contacts");
            Console.WriteLine("3. Edit existing Contact");
            Console.WriteLine("4. Delete a Contact");
            Console.WriteLine("5. Add Multiple Contacts");
            Console.WriteLine("6. List all Address Books");
            Console.WriteLine("7. Create an Address Book.");
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBookUtility.AddContact();
                    break;
                case 2:
                    addressBookUtility.DisplayAllContacts();
                    break;
                case 3:
                    addressBookUtility.EditExistingContact();
                    break;
                case 4:
                    addressBookUtility.DeleteContact();
                    break;
                case 5:
                    addressBookUtility.AddMultipleContacts();
                    break;
                case 6:
                    addressBookUtility.ListAllAddressBooks();
                    break;
                case 7:
                    addressBookUtility.CreateAddressBook();
                    break;
            }

        } while (choice != 0);
    }
}