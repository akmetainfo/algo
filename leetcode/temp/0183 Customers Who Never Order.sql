-- https://leetcode.com/problems/customers-who-never-order/

/* Task

Suppose that a website contains two tables, the Customers table and the Orders table. Write a SQL query to find all customers who never order anything.

Table: Customers.

+----+-------+
| Id | Name  |
+----+-------+
| 1  | Joe   |
| 2  | Henry |
| 3  | Sam   |
| 4  | Max   |
+----+-------+

Table: Orders.

+----+------------+
| Id | CustomerId |
+----+------------+
| 1  | 3          |
| 2  | 1          |
+----+------------+

Using the above tables as example, return the following:

+-----------+
| Customers |
+-----------+
| Henry     |
| Max       |
+-----------+

*/

/* Prepare data

Create table If Not Exists Customers (Id int, Name varchar(255))
Create table If Not Exists Orders (Id int, CustomerId int)
Truncate table Customers
insert into Customers (Id, Name) values ('1', 'Joe')
insert into Customers (Id, Name) values ('2', 'Henry')
insert into Customers (Id, Name) values ('3', 'Sam')
insert into Customers (Id, Name) values ('4', 'Max')
Truncate table Orders
insert into Orders (Id, CustomerId) values ('1', '3')
insert into Orders (Id, CustomerId) values ('2', '1')

*/

/* My solution

-- via 'Not Exists'
SELECT c.Name AS Customers
FROM dbo.Customers c
WHERE 1 = 1
AND NOT EXISTS (SELECT Id FROM dbo.Orders o WHERE o.CustomerId = c.Id)

-- via 'left join'
SELECT c.Name AS Customers
FROM dbo.Customers c
LEFT JOIN dbo.Orders o ON c.Id = o.CustomerId
WHERE 1 = 1
AND o.CustomerId IS NULL

*/



/* Solution

Approach: Using sub-query and NOT IN clause [Accepted]

Algorithm

If we have a list of customers who have ever ordered, it will be easy to know who never ordered.

We can use the following code to get such list.

select customerid from orders;

Then, we can use NOT IN to query the customers who are not in this list.

MySQL

select customers.name as 'Customers'
from customers
where customers.id not in
(
    select customerid from orders
);

*/