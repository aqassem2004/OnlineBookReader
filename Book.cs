using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class Book
    {
        System UseSystem = new System();
        string BookId;
        string Title;
        string Author;
        List<string> Pages;
        public string bookid
        {
            set { this.BookId = value; }
            get { return BookId; }
        }
        public string title
        {
            set { this.Title = value; }
            get { return Title; }
        }
        public string author
        {
            set { this.Author = value; }
            get { return Author; }
        }
        public List<string> pages
        {
            set { this.Pages = value; }
            get { return Pages; }
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
        short TakeNumPages()
        {
            Console.Write("\tNumber of pages: ");
            short numpages;
            while (!short.TryParse(Console.ReadLine(), out numpages))
            {
                Console.WriteLine("Invalid entry, please enter decimal number");
                Console.Write("\tNumber of pages: ");
            }
            return numpages;
        }
        string TakeBookId()
        {
            Console.Write("\tBook Id: ");
            return Console.ReadLine();
        }
        void TakeBookData2(ref Book book)
        {
            Console.Write("\tTitle: ");
            book.title = Console.ReadLine();

            Console.Write("\tAuthor: ");
            book.author = Console.ReadLine();
        }
        List<string> ReadBookPages(short NumPages)
        {
            List<string> pages = new List<string>();
            for (int i = 0; i < NumPages; i++)
            {

                Console.Write($"\tEnter page{i + 1}: ");
                string PageTitel = Console.ReadLine();
                pages.Add(PageTitel);
                Console.WriteLine();
            }
            return pages;
        }
        public void TakeBookData(ref Book book)
        {

            Console.WriteLine("Enter Book data\n");
            book.bookid = ValidateInput(TakeBookId, "This ID is already in use.", (string input) => UseSystem.CheckedBookId(input));
            TakeBookData2(ref book);
            short NumPages = TakeNumPages();
            book.pages = ReadBookPages(NumPages);

        }
        void Read(Book book , ref ReadingSession session)
        {

            Console.WriteLine("***\tRead Mode\t***\nNow if you want to go to the next page, request next.");
            Console.WriteLine("If you want to go back to the previous page, request previous.\nIf you want to exit reading mode, request exit.");
            Console.WriteLine($"\tReading {book.title}");
            string input = null;
            bool print = true;
            while(input != "exit")
            {
                if(print)
                Console.WriteLine($"\t\tPage {session.lastpage} : {book.pages[session.lastpage-1]}");
                Console.Write("Your request :");print = true;
                input = Console.ReadLine().ToLower();
                if (input == "previous" && session.lastpage == 1)
                {
                    Console.WriteLine("This is first page");
                    print = false;
                }
                else if (input == "previous")
                    session.PreviousPage(ref session);
                else if (input != "next" && input != "previous")
                    print = false;
                if(input == "next" && session.lastpage == book.pages.Count)
                {
                    Console.WriteLine("This is last page");
                    print = false;
                }
                else if (input == "next")
                    session.NextPage(ref session);
            }
            
        }
        public ReadingSession ContinueRead(ReadingSession session , Book book)
        {
            book.Read(book, ref session);
            session.currentTime = DateTime.Now; 
          // session.currentDate = DateTime.Today;
            return session;
        }
        public ReadingSession ReadBook(Book book)
        {
            ReadingSession session = new ReadingSession(book);
            book.Read(book, ref session);
            return session;
        }
    }
}
