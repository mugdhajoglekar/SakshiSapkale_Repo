

namespace StudentDetail
{
    // C# program to print the list of students
    // details using select clause

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Student
    {

        // Declare 4 variables - id, age, department and semester
        int stu_id;
        string stu_dept;
        string stu_name;
        int stu_semester;

        // Get the to string method that returns
        // id, age, department and semester
        public override string ToString()
        {
            return stu_id + " " + stu_name + " " +
                stu_dept + " " + stu_semester;
        }

        // Driver code
        static void Main(string[] args)
        {

            // Declare a list variable
            List<Student> stu = new List<Student>()
            {
		
		        // Create 3 Student details
		        new Student{ stu_id = 101, stu_name = "Sakshi",
                            stu_dept = "CSE", stu_semester = 2 },
                new Student{ stu_id = 102, stu_name = "Aadeelh",
                            stu_dept = "ECE", stu_semester = 1 },
                new Student{ stu_id = 103, stu_name = "Aniket",
                            stu_dept = "EEE", stu_semester = 4},
            };

            // Iterate the Employee
            // using select function
            IEnumerable<Student> Query = from student in stu select student;

            // Display student details
            Console.WriteLine("ID Name Department Semester");
            Console.WriteLine("+++++++++++++++++++++++++++");
            foreach (Student e in Query)
            {

                // Call the to string method
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }

}
