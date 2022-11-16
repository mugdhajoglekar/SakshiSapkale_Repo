
namespace EmployeeList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Employee
    {
        int ID;
        string Name;
        int Salary;
        string Department;

        public override string ToString()
        {
            return ID + " " + Name + " " + Salary + " " + Department;
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
        {
             new Employee {ID=101,   Name="Sakshi  "    , Salary=4000,Department="ABC"},
             new Employee {ID=102,   Name="Aadeelh"    , Salary=6000,Department="XYZ"},
             new Employee {ID=103,   Name="Aniket"    , Salary=3000,Department="ABC"},
             new Employee {ID=104,   Name="Nandani"    , Salary=2000,Department="XYZ"},
             new Employee {ID=105,   Name="Yashodhan "    , Salary=7000,Department="ABC"},
             new Employee {ID=106,   Name="Rohan"    , Salary=5000,Department="XYZ"},
        };


            var result = employees.Where(emp => emp.Department == "XYZ").OrderByDescending(sal => sal.Salary);


            Console.WriteLine("ID  Name  Salary  Department");
            Console.WriteLine("============================");
            foreach (Employee emp in result)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.WriteLine("============================");
            Console.ReadLine(); 
        }
    }
}
