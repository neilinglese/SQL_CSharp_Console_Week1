using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WeekOne
{
    class Program
    {
        static void Main(string[] args)
        {
            setUp();
            Console.Read();
            
        }
        private static void setUp()
        {
            string q1 = "select monthNumber, YearNumber from ztblMonths";
            string q2 = "select datename(dw, MonthStart),  datename(month,MonthStart), datepart(wk,MonthStart) from ztblMonths";
            string q3 = "select CustFirstName, CustLastName, CustAreaCode, CustPhoneNumber from Customers";
            string q4 = "select CustFirstName, CustLastName, CustAreaCode, CustPhoneNumber from Customers order by CustAreaCode, CustPhoneNumber asc";
            string q5 = "select ProductName, RetailPrice, QuantityOnHand from Products order by RetailPrice * QuantityOnHand desc";
            string q6 = "select VendName,VendWebPage, VendEmailAddress from Vendors where VendWebPage not like 'NULL' and VendEMailAddress not like 'NULL'";
            string q7 = "select CustomerID, CustFirstName, CustLastName, CustStreetAddress from Customers where CustCity = 'Redmond' and CustState = 'WA'";
            string q8 = "select EmployeeID, EmpFirstName, EmpLastName, EmpStreetAddress from Employees where EmpCity = 'Redmond' and EmpState = 'WA'";
            string q9 = "select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where DaysToDeliver <= 5";
            string q10 = "select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where DaysToDeliver <= 5 order by DaysToDeliver, WholesalePrice desc";
            string q11 = "select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where WholesalePrice > 1000 order by WholesalePrice desc";
            string q13 = "select OrderNumber, ProductNumber, QuotedPrice, QuantityOrdered from Order_Details order by (QuotedPrice * QuantityOrdered)";
            string q14 = "select OrderNumber, ProductNumber, QuotedPrice, QuantityOrdered from Order_Details order by QuotedPrice * QuantityOrdered desc";
            string q15 = "select OrderNumber, ProductNumber, QuotedPrice, QuantityOrdered from Order_Details where QuotedPrice * QuantityOrdered > 10000 order by QuotedPrice * QuantityOrdered, OrderNumber asc";



           string connStr_num1 = ConfigurationManager.ConnectionStrings["WeekOne.Properties.Settings.SalesOrdersExampleConnectionString"].ConnectionString;

           using (SqlConnection conn = new SqlConnection(connStr_num1))
           {

               conn.Open();

               if (conn.State != System.Data.ConnectionState.Open)
               {
                   Console.WriteLine("Error in opening database connection!");
                   return;
               }
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("1. Get month and year as numbers from ztblMonths\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question1(q1,conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n2.Get the starting day of each month found in ztblmonths,\nthe name of the month and the week in the year that contains the starting day\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question2(q2,conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n3.Get the first and last name, along with the area code and\n phone# of all customers\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question3(q3,conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n4.Same as above but sort by Area Code and then by phone number\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question4(q4,conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n5.Arrange the products from highest gross revenue to lowest.\n Gross Revenue is the Retail Price times the QuantityOnHand\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question5(q5, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n6.Display Vendor Name, Web Page and Email Address from Vendors\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question6(q6, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n7.Display Customer ID, the First and Last Name and Address for those Customers\n living in Redmond WA\n ");
               Console.ForegroundColor = ConsoleColor.White;
               Question7(q7, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n8.Display Employee ID, the First and Last Name and Address for those Employees\n living in Redmond WA\n ");
               Console.ForegroundColor = ConsoleColor.White;
               Question8(q8, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n9.Find the Vendor Id, the Product Number, Wholesale Price and Days To Deliver\n for those vendors expected to deliver within 5 days\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question9(q9, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n10.Take the above query and order it by DaysToDeliver (earliest to latest),\n then by Wholesale Price (highest value to least value)\n ");
               Console.ForegroundColor = ConsoleColor.White;
               Question10(q10, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n11. Find the Vendor Id, the Product Number, Wholesale Price and Days To Deliver\n for those records where the wholesale price is higher than 1000 \n sort by Wholesale Price (highest value to least value).\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question11(q11, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\nQuestion 12 is in the SQLQuery2.sql file \nQuestions 13 and 14 are to long to display, therefore commented out\n");
               /*
                 12.What is the result if you raise the amount to compare from 1000 to 2000
                  in the previous query?
                  displays the table with no results

                  Do you get a result set from the DBMS?
                  no

                  Explain your answer.
                  Since the highest price return is 1477 if we change 1000 to 2000 we get the table but no results are displayed. Therefore no result from the DBMS.
                 */
              //Console.WriteLine("\n13. Show the total value of each order in order_details\n along with the OrderNumber, ProductNumber information \n");
              //Question13(q13, conn);
              //Console.WriteLine("\n14.Show the total value of each order in order_details\n along with the OrderNumber, ProductNumber information\n and order this from highest to least Total Value\n");
              //Question14(q14, conn);
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("\n15. Show the total value of each order in order_details\n along with the OrderNumber, ProductNumber information\n and order this by Total Value and then by order number\n for those orders with a Total Value greater than $10000\n");
               Console.ForegroundColor = ConsoleColor.White;
               Question15(q15, conn);
           }

        }

        private static void Question1(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int monthNumber = rdr.GetInt16(0);
                        int yearNumber = rdr.GetInt16(1);
                        message = String.Format("Month Number: {0}, Month Year: {1}", monthNumber, yearNumber);
                        Console.WriteLine(message);

                    }
                }

            }

            
        }
        private static void Question2(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
             {
                 using (SqlDataReader rdr = cmd.ExecuteReader())
                 {
                     // Read the next record while not at the end
                     string message = "";
                     while (rdr.Read())
                     {
                         string day = rdr.GetString(0).Trim();
                         string month = rdr.GetString(1).Trim();
                         int weekNumber = rdr.GetInt32(2);
                         message = String.Format("Day: {0},\t Month: {1},\t Week Number: {2}", day, month,weekNumber);
                         Console.WriteLine(message);

                     }
                 }

             }
        }
        private static void Question3(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        string cFirst = rdr.GetString(0).Trim();
                        string cLast = rdr.GetString(1).Trim();
                        int areaCode = rdr.GetInt16(2);
                        string phoneNumber = rdr.GetString(3).Trim();
                        message = String.Format("First: {0},\t Last: {1},\t Area Coder: {2}, \tPhone: {3}", cFirst, cLast, areaCode, phoneNumber);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question4(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        string cFirst = rdr.GetString(0).Trim();
                        string cLast = rdr.GetString(1).Trim();
                        int areaCode = rdr.GetInt16(2);
                        string phoneNumber = rdr.GetString(3).Trim();
                        message = String.Format("First: {0},\t Last: {1},\t Area Coder: {2}, \tPhone: {3}", cFirst, cLast, areaCode, phoneNumber);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question5(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        string productName = rdr.GetString(0).Trim();
                        decimal retailPrice = Convert.ToDecimal(rdr["RetailPrice"]);
                        int quantity = rdr.GetInt16(2);
                        message = String.Format("Product Name: {0},\t Price: {1},\t Quantity: {2}", productName, retailPrice, quantity);
                        Console.WriteLine(message);

                    }
                }

            }
        }
        private static void Question6(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        string vendName = rdr.GetString(0).Trim();
                        string vendWeb = rdr.GetString(1).Trim();
                        string vendEmail = rdr.GetString(2).Trim();
                        message = String.Format("Vendor Name: {0},\t Website: {1},\t Email: {2}", vendName, vendWeb, vendEmail);
                        Console.WriteLine(message);

                    }
                }

            }


        }
        private static void Question7(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int cID = rdr.GetInt32(0);
                        string cFirst = rdr.GetString(1).Trim();
                        string cLast = rdr.GetString(2).Trim();
                        string cAddress = rdr.GetString(3).Trim();
                        message = String.Format("ID: {0},\t First: {1},\t Last: {2},\t Address: {3}", cID, cFirst, cLast, cAddress);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question8(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int eID = rdr.GetInt32(0);
                        string eFirst = rdr.GetString(1).Trim();
                        string eLast = rdr.GetString(2).Trim();
                        string eAddress = rdr.GetString(3).Trim();
                        message = String.Format("ID: {0},\t First: {1},\t Last: {2},\t Address: {3}", eID, eFirst, eLast, eAddress);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question9(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int vID = rdr.GetInt32(0);
                        int pNumber = rdr.GetInt32(1);
                        decimal wPrice = Convert.ToDecimal(rdr["WholesalePrice"]);
                        int dtd = rdr.GetInt16(3);
                        message = String.Format("ID: {0},\t Product Number: {1},\t Price: {2},\t Days to Deliver: {3}", vID, pNumber, wPrice, dtd);
                        Console.WriteLine(message);

                    }
                }

            }
        }
        private static void Question10(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int vID = rdr.GetInt32(0);
                        int pNumber = rdr.GetInt32(1);
                        decimal wPrice = Convert.ToDecimal(rdr["WholesalePrice"]);
                        int dtd = rdr.GetInt16(3);
                        message = String.Format("ID: {0},\t Product Number: {1},\t Price: {2},\t Days to Deliver: {3}", vID, pNumber, wPrice, dtd);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question11(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int vID = rdr.GetInt32(0);
                        int pNumber = rdr.GetInt32(1);
                        decimal wPrice = Convert.ToDecimal(rdr["WholesalePrice"]);
                        int dtd = rdr.GetInt16(3);
                        message = String.Format("ID: {0},\t Product Number: {1},\t Price: {2},\t Days to Deliver: {3}", vID, pNumber, wPrice, dtd);
                        Console.WriteLine(message);

                    }
                }

            }

        }
        private static void Question13(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int orderNum = rdr.GetInt32(0);
                        int prodNum = rdr.GetInt32(1);
                        decimal qPrice = Convert.ToDecimal(rdr["QuotedPrice"]);
                        int qOrdered = rdr.GetInt16(3);
                        string final = (qPrice * qOrdered).ToString();
                        message = String.Format("Order Number: {0}, Product Number: {1}, Quote Per: {2}, Quantity: {3}, Final:{4}", orderNum, prodNum, qPrice, qOrdered, final);
                        Console.WriteLine(message);


                    }
                }

            }

        }
        private static void Question14(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int orderNum = rdr.GetInt32(0);
                        int prodNum = rdr.GetInt32(1);
                        decimal qPrice = Convert.ToDecimal(rdr["QuotedPrice"]);
                        int qOrdered = rdr.GetInt16(3);
                        string final = (qPrice * qOrdered).ToString();
                        message = String.Format("Order Number: {0}, Product Number: {1}, Quote Per: {2}, Quantity: {3}, Final:{4}", orderNum, prodNum, qPrice, qOrdered, final);
                        Console.WriteLine(message);


                    }
                }

            }

        }
        private static void Question15(string selectStatement,SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Read the next record while not at the end
                    string message = "";
                    while (rdr.Read())
                    {
                        int orderNum = rdr.GetInt32(0);
                        int prodNum = rdr.GetInt32(1);
                        decimal qPrice = Convert.ToDecimal(rdr["QuotedPrice"]);
                        int qOrdered = rdr.GetInt16(3);
                        string final = (qPrice * qOrdered).ToString();
                        message = String.Format("Order Number: {0}, Product Number: {1}, Quote Per: {2}, Quantity: {3}, Final:{4}", orderNum, prodNum, qPrice, qOrdered, final);
                        Console.WriteLine(message);


                    }
                }

            }

        }


    }
}
