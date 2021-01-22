-- https://leetcode.com/problems/employees-earning-more-than-their-managers/

/* Task

The Employee table holds all employees including their managers. Every employee has an Id, and there is also a column for the manager Id.

+----+-------+--------+-----------+
| Id | Name  | Salary | ManagerId |
+----+-------+--------+-----------+
| 1  | Joe   | 70000  | 3         |
| 2  | Henry | 80000  | 4         |
| 3  | Sam   | 60000  | NULL      |
| 4  | Max   | 90000  | NULL      |
+----+-------+--------+-----------+

Given the Employee table, write a SQL query that finds out employees who earn more than their managers. For the above table, Joe is the only employee who earns more than his manager.

+----------+
| Employee |
+----------+
| Joe      |
+----------+


*/

/* Prepare data

Create table If Not Exists Employee (Id int, Name varchar(255), Salary int, ManagerId int)
Truncate table Employee
insert into Employee (Id, Name, Salary, ManagerId) values ('1', 'Joe', '70000', '3')
insert into Employee (Id, Name, Salary, ManagerId) values ('2', 'Henry', '80000', '4')
insert into Employee (Id, Name, Salary, ManagerId) values ('3', 'Sam', '60000', 'None')
insert into Employee (Id, Name, Salary, ManagerId) values ('4', 'Max', '90000', 'None')

*/

/* Prepare data - my version

CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Name] [varchar](255) NULL,
	[Salary] [int] NULL,
	[ManagerId] [int] NULL,
CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC) 
)

create unique index IX_ManagerId on Employee (ManagerId) where ManagerId is not null

Truncate table Employee
insert into Employee (Id, Name, Salary, ManagerId) values ('1', 'Joe', '70000', '3')
insert into Employee (Id, Name, Salary, ManagerId) values ('2', 'Henry', '80000', '4')
insert into Employee (Id, Name, Salary, ManagerId) values ('3', 'Sam', '60000', null)
insert into Employee (Id, Name, Salary, ManagerId) values ('4', 'Max', '90000', null)


*/

/* My solution

SELECT
	E.Name Employee
FROM Employee E
INNER JOIN Employee M ON E.ManagerId = M.Id
WHERE 1 = 1
AND E.ManagerId IS NOT NULL
AND E.Salary > M.Salary

Мне кажется, что условие E.ManagerId IS NOT NULL не особо нужно, оно работает по факту относится к области моих допущений, о которых не сказано в задаче. Поэтому я его вычеркнул в anki.
Разницы писать второе условие WHERE или в ON по плану запроса нет, поэтому хоть я и привык делать это в WHERE напишу в anki в ON.

*/



/* Solution

Approach I: Using WHERE clause [Accepted]

Algorithm

As this table has the employee's manager information, we probably need to select information from it twice.

SELECT *
FROM Employee AS a, Employee AS b
;

    Note: The keyword 'AS' is optional.

Id 	Name 	Salary 	ManagerId 	Id 	Name 	Salary 	ManagerId
1 	Joe 	70000 	3 	1 	Joe 	70000 	3
2 	Henry 	80000 	4 	1 	Joe 	70000 	3
3 	Sam 	60000 		1 	Joe 	70000 	3
4 	Max 	90000 		1 	Joe 	70000 	3
1 	Joe 	70000 	3 	2 	Henry 	80000 	4
2 	Henry 	80000 	4 	2 	Henry 	80000 	4
3 	Sam 	60000 		2 	Henry 	80000 	4
4 	Max 	90000 		2 	Henry 	80000 	4
1 	Joe 	70000 	3 	3 	Sam 	60000 	
2 	Henry 	80000 	4 	3 	Sam 	60000 	
3 	Sam 	60000 		3 	Sam 	60000 	
4 	Max 	90000 		3 	Sam 	60000 	
1 	Joe 	70000 	3 	4 	Max 	90000 	
2 	Henry 	80000 	4 	4 	Max 	90000 	
3 	Sam 	60000 		4 	Max 	90000 	
4 	Max 	90000 		4 	Max 	90000 	

    The first 3 columns are from a and the last 3 ones are from b.

Select from two tables will get the Cartesian product of these two tables. In this case, the output will be 4*4 = 16 records. However, what we interest is the employee's salary higher than his/her manager. So we should add two conditions in a WHERE clause like below.

SELECT
    *
FROM
    Employee AS a,
    Employee AS b
WHERE
    a.ManagerId = b.Id
        AND a.Salary > b.Salary
;

Id 	Name 	Salary 	ManagerId 	Id 	Name 	Salary 	ManagerId
1 	Joe 	70000 	3 	3 	Sam 	60000 	

As we only need to output the employee's name, so we modify the above code a little to get a solution.

MySQL

SELECT
    a.Name AS 'Employee'
FROM
    Employee AS a,
    Employee AS b
WHERE
    a.ManagerId = b.Id
        AND a.Salary > b.Salary
;

Approach I: Using JOIN clause [Accepted]

Algorithm

Actually, JOIN is a more common and efficient way to link tables together, and we can use ON to specify some conditions.

SELECT
     a.NAME AS Employee
FROM Employee AS a JOIN Employee AS b
     ON a.ManagerId = b.Id
     AND a.Salary > b.Salary
;

*/