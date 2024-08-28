using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class System
    {
        private static List<User> users ;
        private static Dictionary<string, string> UserID ;
        static Dictionary<string, Book> Books ;
        private User lastUser;
        public System()
        {

        }
        public System(int run)
        {
            users = new List<User>();
            UserID = new Dictionary<string, string>();
            Books = new Dictionary<string, Book>();
            User user2 = new User
            {
                username = "Aqassem",
                firstname = "Ahmed",
                lastname = "Qassem",
                age = 20,
                password = "02117854",
                type = "admin",
                sex = "male",
                email = "aqassemm2004@gmail.com"
            };
            users.Add(user2);
            UserID[user2.username] = user2.password;
            User user1 = new User
            {
                username = "Aqassem2",
                firstname = "Ahmed",
                lastname = "Qassem",
                age = 20,
                password = "021178542",
                type = "customer",
                sex = "male",
                email = "aqassemm2004@gmail.com"
            };
            users.Add(user1);
            UserID[user1.username] = user1.password;

            List<string> page = new List<string> { "page1 ", "page2 ", "page3 " };
            Book book1 = new Book
            {
                bookid = "123",
                title = "Magek is Top",
                author = "Ahmed Qassem",
                pages = page
            };
            List<string> page2 = new List<string> { "page1 ", "page2 ", "page3 " };
            Book book2 = new Book
            {
                bookid = "1234",
                title = "Magek is Top part 2",
                author = "Ahmed Qassem",
                pages = page2
            };
            Books["123"] = book1;
            Books["1234"] = book2;
        }
        public bool PrintSystemBooks()
        {
            if (Books.Count == 0)
                return false;
            short counter = 1;
            foreach(var book in Books)
            {
                Console.WriteLine($"\tBook {counter++} : Title: {book.Value.title} | Book ID: {book.Value.bookid} | Author: {book.Value.author} | Number of pages: {book.Value.pages.Count}");
            }
            return true;
        }
        public bool CheckedBookId(string BookId)
        {
            return Books.ContainsKey(BookId);
        }
        public void SetBook(Book book)
        {
            Books[book.bookid] = book;
        }
        public Book GetBook(string BookId)
        {
            return Books[BookId];
        }
        private string TakeUsername()
        {
            Console.WriteLine("Enter username without spaces");
            Console.Write("\tUsername: ");
            string input = Console.ReadLine();
            while (input.Contains(' '))
            {
                Console.WriteLine("Enter username without spaces");
                Console.Write("\tUsername: ");
                input = Console.ReadLine();
            }
            return input;
        }

        private string TakePassword()
        {
            Console.Write("\tPassword: ");
            return Console.ReadLine();
        }

        private string TakeRepeatedPassword()
        {
            Console.Write("\tRepeat Password: ");
            return Console.ReadLine();
        }

        private string TakeType()
        {
            Console.Write("\tUser type (admin/customer): ");
            return Console.ReadLine().ToLower();
        }

        private string TakeSex()
        {
            Console.Write("\tSex (male/female): ");
            return Console.ReadLine().ToLower();
        }

        private string TakeEmail()
        {
            Console.Write("\tEmail: ");
            return Console.ReadLine();
        }

        private void TakeUserData(ref User user)
        {
            Console.Write("\tFirst name: ");
            user.firstname = Console.ReadLine();

            Console.Write("\tLast name: ");
            user.lastname = Console.ReadLine();

            Console.Write("\tAge: ");
            short input = 0;
            while (!short.TryParse(Console.ReadLine(), out input) || input > 100)
            {
                if(input > 100)
                {
                    Console.WriteLine("You are not dinosaur enter your real age");
                }
                else
                {
                    Console.WriteLine("Invalid entry, please enter age as a number");
                }
                Console.Write("\tAge: ");
            }
            user.age = input;
        }

        private void AddUser(ref User user)
        {
            users.Add(user);
            UserID[user.username] = user.password;
        }

        private string ValidateInput(Func<string> inputAction, string errorMessage, Func<string, bool> validationFunc)
        {
            string input = inputAction();
            while (validationFunc(input))
            {
                Console.WriteLine(errorMessage);
                input = inputAction();
            }
            return input;
        }

        private short LogInSystem()
        {
            Console.WriteLine("If you do not have an account, you can request to create a new account by entering 'register' as the Username\n");
            string usernameInput = TakeUsername();

            if (usernameInput == "register")
                return 2;

            string password = TakePassword();
            if (UserID.TryGetValue(usernameInput, out string storedPassword) && storedPassword == password)
            {
                Console.WriteLine($"Welcome {usernameInput}!");
                lastUser = users.Find(u => u.username == usernameInput);
                return 1;
            }

            Console.WriteLine("It seems that the username or password is incorrect. Please check it.");
            return 0;
        }

        private void RegisterSystem()
        {
            User newUser = new User();
            string repassword = null;

            newUser.username = ValidateInput(TakeUsername, "This name is already in use.", (string input) => UserID.ContainsKey(input));
            while (newUser.username == "register")
            {
                Console.WriteLine("Sorry, you can't use 'register' as a username.");
                newUser.username = TakeUsername();
            }

            TakeUserData(ref newUser);
            newUser.sex = ValidateInput(TakeSex, "Invalid entry, please check sex again", (string input) => input != "male" && input != "female");
            newUser.email = ValidateInput(TakeEmail, "Invalid entry, please check email again", (string input) => !input.EndsWith("@gmail.com"));
            newUser.type = ValidateInput(TakeType, "Invalid entry, please check the type again", (string input) => input != "admin" && input != "customer");

            newUser.password = TakePassword();
            repassword = TakeRepeatedPassword();
            while (newUser.password != repassword)
            {
                Console.WriteLine("Two passwords are not the same!");
                newUser.password = TakePassword();
                repassword = TakeRepeatedPassword();
            }

            Console.WriteLine("Congratulations, your account has been successfully registered.");
            AddUser(ref newUser);
            lastUser = newUser;
        }

        string LogInApp()
        {
            string request;
            Console.Write("Please enter if you want to register or log in : ");
            request = Console.ReadLine().ToLower();
            Console.WriteLine();

            while (request != "register" && request != "log in")
            {
                Console.WriteLine("Sorry, there is a problem with your request. Make sure you have written the request correctly, knowing that it does not matter if the letters are capital or small");
                Console.Write("Please enter if you want to register or log in : ");
                request = Console.ReadLine().ToLower();
                Console.WriteLine();
            }

            return request;
        }

        void RegisterInApp()
        {
            Console.WriteLine("Ok now enter your data :)");
            RegisterSystem();
        }

        public void StartApp()
        {
            Console.WriteLine("Welcome to Online Book Reader\n");
            Console.WriteLine("If you already have an account, please request a login.\n");
            Console.WriteLine("Or you can request to register with us\n");

            while (true)
            {
                if (LogInApp() == "log in")
                {
                    short logintype = LogInSystem();
                    while (logintype == 0)
                        logintype = LogInSystem();
                    if (logintype == 2)
                        RegisterInApp();
                }
                else
                {
                    RegisterInApp();
                }


                if (lastUser.type == "admin")
                {
                    AdminUserView userView = new AdminUserView(lastUser);
                    userView.Display();
                }
                else
                {
                    CustomerUserView userView = new CustomerUserView(lastUser);
                    userView.Display();
                }
            }
        }
    }

}
