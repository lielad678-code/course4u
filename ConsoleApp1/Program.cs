using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting Test...");
                ViewModel.StudentDB db = new ViewModel.StudentDB();
                Model.Student s = new Model.Student();
                s.FirstName = "TestFirst";
                s.LastName = "TestLast";
                s.Email = "test" + DateTime.Now.Ticks + "@test.com"; 
                s.Password = "123";
                s.BirthDate = DateTime.Now;
                s.Gender = "Male";
                s.PhoneNumber = "0501234567"; // UserTbl column
                s.ParentPhoneNumber = "0509876543"; // StudentTbl column

                db.Insert(s);
                db.SaveChanges();
                Console.WriteLine("SUCCESS: Student inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAILURE: " + ex.ToString());
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
