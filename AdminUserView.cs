using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class AdminUserView
    {
        System UseSystem = new System();
        User user = new User();
        public AdminUserView(User user)
        {
            this.user = user;
        }
        public void Display()
        {
            Console.WriteLine("\n\t\t *** Admin View ***");
            string input = null;
           
            while (true)
            {
                Console.WriteLine("Select command from (View Profile /\\ Add Book/\\ Logout)");
                Console.Write("\tWhat do you want : ");
                input = Console.ReadLine().ToLower();
                if (input == "logout")
                    break;
                else if (input == "view profile")
                    ViewProfile();
                else if (input == "add book")
                    AddBook();
                else
                    Console.WriteLine("Invalid entry, please check your command again");
                Console.WriteLine("\n\n");
            }

        }

        void ViewProfile()
        {
            user.PrintProfile(user);
        }
        void AddBook()
        {
            Book book = new Book();
            book.TakeBookData(ref book);
            UseSystem.SetBook(book);
            Console.WriteLine("The book has been added successfully.\n\n");
        }
    }
}
