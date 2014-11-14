/*
NOTE: All of the queries (SELECT statements) use the SalesOrdersExample.mdf database.

Your first step is to create a console project that uses SalesOrdersExample.mdf as a local database.
*/

--1. Get month and year as numbers from ztblMonths
select monthNumber, YearNumber from ztblMonths

/*
2.Get the starting day of each month found in ztblmonths,
 the name of the month and the week in the year that contains the starting day
 */
select datename(dw, MonthStart),  datename(month,MonthStart), datepart(wk,MonthStart) from ztblMonths
/*
3.Get the first and last name, along with the area code and phone# of all customers
*/
select CustFirstName, CustLastName, CustAreaCode, CustPhoneNumber from Customers
/*
4.Same as above but sort by Area Code and then by phone number
*/
select CustFirstName, CustLastName, CustAreaCode, CustPhoneNumber from Customers order by CustAreaCode, CustPhoneNumber asc

/*
5.Arrange the products from highest gross revenue to lowest.
 Gross Revenue is the Retail Price times the QuantityOnHand
*/
select ProductName, RetailPrice, QuantityOnHand from Products order by RetailPrice * QuantityOnHand desc

--6.Display Vendor Name, Web Page and Email Address from Vendors
select VendName,VendWebPage, VendEmailAddress from Vendors where VendWebPage not like 'NULL' and VendEMailAddress not like 'NULL'
--7.Display Customer ID, the First and Last Name and Address for those Customers living in Redmond WA 
select CustomerID, CustFirstName, CustLastName, CustStreetAddress from Customers where CustCity = 'Redmond' and CustState = 'WA'
--8.Display Employee ID, the First and Last Name and Address for those Employees living in Redmond WA 
select EmployeeID, EmpFirstName, EmpLastName, EmpStreetAddress from Employees where EmpCity = 'Redmond' and EmpState = 'WA'


/*
9.Find the Vendor Id, the Product Number, Wholesale Price and Days To Deliver 
 for those vendors expected to deliver within 5 days
*/
select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where DaysToDeliver <= 5
/*
10.Take the above query and order it by DaysToDeliver (earliest to latest),
 then by Wholesale Price (highest value to least value) 
 */
select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where DaysToDeliver <= 5 order by DaysToDeliver, WholesalePrice desc

/*
11. Find the Vendor Id, the Product Number, Wholesale Price and Days To Deliver 
 for those records where the wholesale price is higher than 1000 
 sort by Wholesale Price (highest value to least value).  Data is in Product_Vendors table.
 */
select VendorID, ProductNumber, WholesalePrice, DaysToDeliver from Product_Vendors where WholesalePrice > 1000 order by WholesalePrice desc

/*
12.What is the result if you raise the amount to compare from 1000 to 2000
 in the previous query?
 displays the table with no results

 Do you get a result set from the DBMS?
 no

 Explain your answer.
 Since the highest price return is 1477 if we change 1000 to 2000 we get the table but no results are displayed. Therefore no result from the DBMS.
*/

/*
13. Show the total value of each order in order_details 
 along with the OrderNumber, ProductNumber information 
 */
select QuotedPrice * QuantityOrdered, OrderNumber, ProductNumber from Order_Details
/*
14.Show the total value of each order in order_details 
 along with the OrderNumber, ProductNumber information 
 and order this from highest to least Total Value
 */
select QuotedPrice * QuantityOrdered, OrderNumber, ProductNumber from Order_Details order by QuotedPrice * QuantityOrdered desc

/*
15. Show the total value of each order in order_details 
 along with the OrderNumber, ProductNumber information 
 and order this by Total Value and then by order number
 for those orders with a Total Value greater than $10000
 */

select QuotedPrice * QuantityOrdered, OrderNumber, ProductNumber from Order_Details where QuotedPrice * QuantityOrdered > 10000 order by QuotedPrice * QuantityOrdered, OrderNumber asc

