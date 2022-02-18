using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    public class AmountExceeded : Exception
    {
        public override string Message
        {
            get
            {
                return "Amount Exceeded for this account type";
            }
        }
    }

    public class EmpDetails
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }       
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public string Mobile { get; set; }
        public int Balance { get; set; }
    }
    public class Program
    {

        static void Main(string[] args)
        {
           
            //Console.WriteLine("How many users you want to add?");
            //nousers = Convert.ToInt32(Console.ReadLine());
            //for (int i=1; i <= nousers; i++)
            //{
              
              
            //}
            
            
            
            
            
            
            bool ATMReq = false;

            Console.WriteLine("Enter ATM is required or not if yes press 1 otherwise press 0:-");
            ATMReq = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            if (ATMReq)
            {

                ATM at1 = new ATM();
                Program.ATM.ATMYes obj1 = new Program.ATM.ATMYes(at1.ATMYesSel);
                obj1();
                
            }
            else
            {
                
            }

        }
      
        public class ATM
        {
           
            bool deposit = false;
            int nooftransactions = 0;
            string Accounttype;
            int balamount;
            int depamnt;
            int withdrwamnt;
            int i = 1;
            public delegate void ATMYes();

            public void ATMYesSel()
            {
                EmpDetails empdat = new EmpDetails();
                int nousers = 1;
                List<EmpDetails> lst1 = new List<EmpDetails>();
                //while (i <= 2)
                //{
                string username, age;

                string userid;
                
                Console.WriteLine("Thanks for choosing ATM");
                Console.WriteLine("Enter User id:-");
                userid = Console.ReadLine();
                Console.WriteLine("Enter User Name:-");
                username = Console.ReadLine();
                Console.WriteLine("Enter Age of user:-");
                age = Console.ReadLine();
                string filepath = "C:\\Employee.txt";
                StreamWriter sw = new StreamWriter(filepath);
                empdat.Name = username;
                empdat.Age = age;
                empdat.id = userid;

                while (i <= 2)
                {
                    Console.WriteLine("for deposit enter 1 and for withdraw enter 0?");
                    deposit = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));

                    if (deposit)
                    {

                        Console.WriteLine("Enter Account Type:-");
                        Accounttype = Console.ReadLine().ToLower();
                        empdat.AccountType = Accounttype;
                        try
                        {

                            switch (Accounttype)
                            {
                                case "savings":

                                    Console.WriteLine("Account type is savings");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = Convert.ToInt32(Console.ReadLine());
                                    if (depamnt > 100000)
                                    {
                                        throw new AmountExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                    }

                                    break;
                                case "current":

                                    Console.WriteLine("Account type is current");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = Convert.ToInt32(Console.ReadLine());
                                    if (depamnt > 200000)
                                    {
                                        throw new AmountExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                    }


                                    break;
                                case "child":

                                    Console.WriteLine("Account type is child");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = Convert.ToInt32(Console.ReadLine());
                                    if (depamnt > 50000)
                                    {
                                        throw new AmountExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                    }

                                    break;
                                default:
                                    Console.WriteLine("Please enter valid account type");
                                    Console.ReadKey();
                                    break;
                            }
                            Console.ReadKey();
                        }
                        catch (AmountExceeded ex1)
                        {
                            Console.WriteLine("Result:-" + ex1.Message);
                            Console.ReadKey();
                        }

                        Console.ReadKey();


                    }
                    else
                    {
                        if (nooftransactions < 3)
                        {
                            Console.WriteLine("Enter amount to withdraw:-");
                            withdrwamnt = Convert.ToInt32(Console.ReadLine());
                            if (balamount >= withdrwamnt)
                            {
                                balamount = balamount - withdrwamnt;
                                Console.WriteLine("amount withdrawn successfully.balance is " + balamount);
                                Console.ReadKey();
                                nooftransactions++;
                            }
                            else
                            {
                                Console.WriteLine("insufficient bal");
                            }
                        }
                        else
                        {
                            Console.WriteLine("maximum exceeded");
                            Console.WriteLine("Enter amount to withdraw:-");
                            withdrwamnt = Convert.ToInt32(Console.ReadLine());
                            if (balamount >= withdrwamnt)
                            {
                                balamount = balamount - withdrwamnt-500;
                                Console.WriteLine("amount withdrawn successfully.balance is " + balamount);
                                Console.ReadKey();
                                nooftransactions++;
                            }
                            else
                            {
                                Console.WriteLine("insufficient bal");
                            }
                        }
                        Console.ReadKey();
                    }
                    i++;
                }
                
            
                Console.ReadKey();
                empdat.Balance = balamount;
                lst1.Add(empdat);

                DataTable dt = new DataTable();
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Columns.Add("age");
               
                dt.Columns.Add("accounttype");
                dt.Columns.Add("balance");
                foreach (EmpDetails e in lst1)
                {
                    dt.Rows.Add(e.id, e.Name, e.Age, e.AccountType, e.Balance);
                }
                Console.WriteLine("{0} || {1} || {2} || {3} || {4}", dt.Columns[0], dt.Columns[1], dt.Columns[2],dt.Columns[3],dt.Columns[4]);
               
                sw.WriteLine("{0} || {1} || {2} || {3} || {4}", dt.Columns[0], dt.Columns[1], dt.Columns[2], dt.Columns[3], dt.Columns[4]);
                Console.WriteLine("-----------------------------------------------------------------");
               

                foreach (DataRow e1 in dt.Rows)
                {
                    Console.WriteLine("{0} || {1} || {2} || {3} ||{4}", e1[0], e1[1], e1[2],e1[3],e1[4]);
                    
                    sw.WriteLine("{0} || {1} || {2} || {3} ||{4}", e1[0], e1[1], e1[2], e1[3], e1[4]);
                   
                }
                sw.Flush();
                sw.Close();
                String[] data=File.ReadAllLines(filepath);
                StreamReader sr = new StreamReader("C:\\Employee.txt");
                Console.WriteLine("content in the file:");
               foreach(string s in data)
                {
                    Console.WriteLine(s);
                }




                //Console.WriteLine(data);
                sr.Close();
                Console.ReadKey();
            }
        }
    }
}


    
    
    
