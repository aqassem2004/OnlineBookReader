using System;

namespace project_1
{
    public class ReadingSession
    {
        Book book;
        static short Lastpage ;
        DateTime CurrentTime ;
       // DateTime CurrentDate ;
        public ReadingSession(Book book)
        {
            this.book = book;
            Lastpage = 1;
            CurrentTime = DateTime.Now;
         //   CurrentDate = DateTime.Today;
        }
        public Book MyBook
        {
            get { return this.book; }
        }
        public short lastpage
        {
            get { return Lastpage; }
            set { Lastpage = value; }
        }
        public DateTime currentTime
        {
            get { return this.CurrentTime; }
            set { CurrentTime = value; }
        }
       // public DateTime currentDate
       // {
       //     get { return this.CurrentDate; }
       //     set { CurrentDate = value; }
       // }
        public void PreviousPage(ref ReadingSession session)
        {
            session.lastpage =Convert.ToInt16(session.lastpage - 1);
        }
        public void NextPage(ref ReadingSession session)
        {
            session.lastpage = Convert.ToInt16(session.lastpage + 1);
        }

    }
}