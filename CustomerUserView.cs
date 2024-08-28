using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class CustomerUserView
    {
        System UseSystem = new System();
        User user = new User();
        public CustomerUserView(User user)
        {
            this.user = user;
        }
        public void Display()
        {
            Console.WriteLine("\n\t\t *** Customer View ***");
            string input = null;

            while (true)
            {
                Console.WriteLine("Select command from (View Profile /\\ List Books /\\ List reading sessions or My sessions/\\ Logout)");
                Console.Write("\tWhat do you want : ");
                input = Console.ReadLine().ToLower();
                if (input == "logout")
                    break;
                else if (input == "view profile")
                    ViewProfile();
                else if (input == "list books")
                    ListBooks();
                else if(input == "list reading sessions" || input == "my sessions")
                {
                    ListUserSessins();
                }
                else
                    Console.WriteLine("Invalid entry, please check your command again");
                Console.WriteLine("\n\n");
            }

        }
        void ViewProfile()
        {
            user.PrintProfile(user);
        }
        void ListBooks()
        {
             if(!UseSystem.PrintSystemBooks())
             {
                Console.WriteLine("We don't have books right now");
                return;
             }
            Console.WriteLine("Now you can choose a book to read by entering its 'Book ID' or you can choose to exit the book list by requesting to 'exit'.");
            string input = null;
            Console.Write("\tWhat do you want : ");
            input = Console.ReadLine().ToLower();
            while (!UseSystem.CheckedBookId(input) && input != "exit")
            {
                Console.WriteLine("Invalid entry, please check your command again");
                Console.Write("\tWhat do you want : ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "exit")
                return;
            else
            {
                Book book = UseSystem.GetBook(input);
                user.AddReadingSession(book.ReadBook(book), user);
            }
        }
        short CheckSessionNum(short up)
        {
            Console.Write("Choose the book by typing session number :");
            short SessionNum = 0;
            while (!short.TryParse(Console.ReadLine(), out SessionNum) || (SessionNum > up || SessionNum < 0))
            {
                Console.WriteLine("Invalid entry, please check Session number again\n");
                Console.Write("Choose the book by typing session number :");
            }
            return SessionNum;
        }
        void ListUserSessins()
        {
            if(user.numSessions==0)
            {
                Console.WriteLine("You don't have sessions right now");
                return;
            }
            List<ReadingSession>UserSessions=user.GetReadingSession(user);
            short counter = 1;
            foreach(var session in UserSessions)
            {
                Console.WriteLine($"Session {counter++}: in {session.currentTime} you read a book {session.MyBook.title} and the ID {session.MyBook.bookid}\n");
            }
            Console.WriteLine("If you want to re-read or continue reading a writer from this list, please select (Continue | Re-read) or you can exit the list by selecting Exit.");
            string input = null;
            Console.Write("\tChoose a command : ");
            input = Console.ReadLine().ToLower();
            while (input != "continue" && input != "exit" && input != "re-read")
            {
                Console.WriteLine("Invalid entry, please check your command again");
                Console.Write("\tChoose a command : ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "exit")
                return;
            else if(input == "continue")
            {
                short SessionNum = CheckSessionNum(Convert.ToInt16(UserSessions.Count));
                UserSessions[SessionNum - 1]=UserSessions[SessionNum - 1].MyBook.ContinueRead(UserSessions[SessionNum - 1], UserSessions[SessionNum - 1].MyBook);
            }
            else
            {
                short SessionNum = CheckSessionNum(Convert.ToInt16(UserSessions.Count));
                UserSessions[SessionNum - 1] = UserSessions[SessionNum - 1].MyBook.ReadBook(UserSessions[SessionNum - 1].MyBook);
            }
            Console.WriteLine("\n\n");
        }
        
    }
}
