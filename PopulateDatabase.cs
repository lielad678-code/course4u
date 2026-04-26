using System;
using System.Data.OleDb;

namespace PopulateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                     @"Data Source=c:\Users\310\Downloads\19.12.25 COURSE4U\2.11.25\ViewModel\Database\Course4U.accdb;" +
                                     "Persist Security Info=True";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("✓ Database connection successful!");

                    // Clear existing data (optional)
                    Console.WriteLine("\nDo you want to clear existing users? (y/n)");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        ExecuteNonQuery(conn, "DELETE FROM StudentTbl");
                        ExecuteNonQuery(conn, "DELETE FROM TeacherTbl");
                        ExecuteNonQuery(conn, "DELETE FROM UserTbl");
                        Console.WriteLine("✓ Cleared existing users");
                    }

                    // Add Student 1 (John)
                    Console.WriteLine("\n--- Adding Student 1: John Doe ---");
                    string sql1 = @"INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
                                   VALUES ('John', 'Doe', 'student@test.com', '123', #1/1/2005#, 'Male', '0501234567')";
                    ExecuteNonQuery(conn, sql1);
                    int johnId = GetLastInsertId(conn);
                    Console.WriteLine($"✓ Created user with ID: {johnId}");

                    string sql2 = $"INSERT INTO StudentTbl (ID, ParentPhoneNumber) VALUES ({johnId}, '0509876543')";
                    ExecuteNonQuery(conn, sql2);
                    Console.WriteLine("✓ Added student record");

                    // Add Student 2 (Liel)
                    Console.WriteLine("\n--- Adding Student 2: Liel Cohen ---");
                    string sql3 = @"INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
                                   VALUES ('Liel', 'Cohen', 'liel', '123', #1/1/2006#, 'Female', '0505555555')";
                    ExecuteNonQuery(conn, sql3);
                    int lielId = GetLastInsertId(conn);
                    Console.WriteLine($"✓ Created user with ID: {lielId}");

                    string sql4 = $"INSERT INTO StudentTbl (ID, ParentPhoneNumber) VALUES ({lielId}, '0501111111')";
                    ExecuteNonQuery(conn, sql4);
                    Console.WriteLine("✓ Added student record");

                    // Add Teacher (Sarah)
                    Console.WriteLine("\n--- Adding Teacher: Sarah Williams ---");
                    string sql5 = @"INSERT INTO UserTbl (FirstName, LastName, Email, Password, BirthDate, Gender, PhoneNumber)
                                   VALUES ('Sarah', 'Williams', 'teacher@test.com', '123', #5/15/1985#, 'Female', '0507777777')";
                    ExecuteNonQuery(conn, sql5);
                    int sarahId = GetLastInsertId(conn);
                    Console.WriteLine($"✓ Created user with ID: {sarahId}");

                    string sql6 = $"INSERT INTO TeacherTbl (ID, Salary, TeachingCourseID) VALUES ({sarahId}, 10000, NULL)";
                    ExecuteNonQuery(conn, sql6);
                    Console.WriteLine("✓ Added teacher record");

                    // Verify
                    Console.WriteLine("\n=== VERIFICATION ===");
                    VerifyUsers(conn);

                    Console.WriteLine("\n✓✓✓ DATABASE POPULATED SUCCESSFULLY! ✓✓✓");
                    Console.WriteLine("\nYou can now login with:");
                    Console.WriteLine("  Student: student@test.com / 123");
                    Console.WriteLine("  Student: liel / 123");
                    Console.WriteLine("  Teacher: teacher@test.com / 123");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ ERROR: {ex.Message}");
                    Console.WriteLine($"\nDetails: {ex.ToString()}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ExecuteNonQuery(OleDbConnection conn, string sql)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        static int GetLastInsertId(OleDbConnection conn)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        static void VerifyUsers(OleDbConnection conn)
        {
            string sql = "SELECT COUNT(*) FROM UserTbl";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"Total users in database: {count}");
            }

            sql = "SELECT COUNT(*) FROM StudentTbl";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"Total students: {count}");
            }

            sql = "SELECT COUNT(*) FROM TeacherTbl";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"Total teachers: {count}");
            }
        }
    }
}
