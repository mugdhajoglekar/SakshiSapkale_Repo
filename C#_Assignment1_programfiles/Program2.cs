namespace ConsoleApp2_assign1_Q2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
             
            Customer baseClasObj = new Customer();
            baseClasObj.show();
            baseClasObj.show("I am para Text");

            //// object of derived class
            Customer derivedClassObj = new Customer();
            derivedClassObj.setcustomerDetail("Sakshi", 679.34);
            derivedClassObj.showCustDetails();

            //interest object
            interest interestObj = new interest();
            interestObj.setInterestValues(1,5000,15);
            interestObj.calculateInterest();
            Console.ReadLine();

        }
    }
    
    //base class
    class Account
    {
        public string bName;
        public string bdescription;
        //constructor
        public  Account()
        {
            bName = "SBI";
            bdescription = "Saving";
        }
        public void showAccountDetail()
        {
            Console.Write($"Bank name:{bName} type:{bdescription}"); 
        }
        public void show()
        {
            Console.WriteLine("within account");
        }

    }
    //Derived class
    class Customer : Account
    {
        public string custName;
        public double custBalance;

        public void setcustomerDetail(string name,  double balance)
        {
            custName = name;
            custBalance = balance;
        }
        public void showCustDetails()
        {
            Console.WriteLine($"Bank name:{bName} Type:{bdescription} customer name:{custName} customer balance:{custBalance}");
        }
        //overriding
         public void show()
        {
            Console.WriteLine("Within Customer");
        }
        //overloading
        public void show(string s)
        {
            Console.WriteLine(s);
        }
    }
    class interest
    {
        public float time;
        public float amount;
        public float rate;

        public void setInterestValues(float interestTime, float interestAmount, float interestRate)
        {
            time = interestTime;
            amount =interestAmount;
            rate = interestRate;

        }
        public void calculateInterest()
        {
            float SI;
            SI = ((amount* rate * time) / 100);
            Console.WriteLine($"Interest is {SI}");
        }
    }

 }
