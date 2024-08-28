using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    public class User
    {
        string UserName;
        string Password;
        string FirstName;
        string LastName;
        string Email;
        string Type;
        string Sex;
        short Age;
        int NumSessions;
        List<ReadingSession> readingSessions;
        public User()
        {
            NumSessions = 0;
            readingSessions = new List<ReadingSession>();
        }
        public string username
        {
            get { return UserName; }
            set { this.UserName = value; }
        }
        public string password
        {
            get
            {
                return Password;
            }
            set
            {
                this.Password = value;
            }
        }
        public string type
        {
            get
            {
                return Type;
            }
            set
            {
                this.Type = value;
            }
        }
        public string sex
        {
            get
            {
                return this.Sex;
            }
            set
            {
                this.Sex = value;
            }
        }
        public string email
        {
            set
            {
                this.Email = value;
            }
            get
            {
                return Email;
            }
        }
        public string firstname
        {
            get
            {
                return FirstName;
            }
            set
            {
                this.FirstName = value;
            }
        }
        public string lastname
        {
            get
            {
                return LastName;
            }
            set
            {
                this.LastName = value;
            }
        }
        public short age
        {
            get
            {
                return Age;
            }
            set
            {
                this.Age = value;
            }
        }
        public int numSessions
        {
            set { NumSessions = value; }
            get { return NumSessions; }
        }
      
        public void PrintProfile(User user)
        {
            Console.WriteLine($"\tName: {user.firstname} {user.lastname}");
            Console.WriteLine($"\tAge: {user.age}");
            Console.WriteLine($"\tSex: {user.sex}");
            Console.WriteLine($"\tAcount type: {user.type}");
            Console.WriteLine($"\tUsername: {user.username}");
            Console.WriteLine($"\tEmail: {user.email}");
        }
        public List<ReadingSession> GetReadingSession(User user)
        {
            return user.readingSessions;
        }
        public void AddReadingSession(ReadingSession session , User user)
        {
            user.readingSessions.Add(session);
            user.numSessions = user.numSessions + 1;
        }
       
    }

}
