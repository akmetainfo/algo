-- https://leetcode.com/problems/delete-duplicate-emails/

/* Prepare data

CREATE TABLE Person (
	Id INT NOT NULL
   ,Email NVARCHAR(100) NOT NULL
   ,CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
)

INSERT INTO Person (id, Email) VALUES (1, 'john@example.com')
INSERT INTO Person (id, Email) VALUES (2, 'bob@example.com')
INSERT INTO Person (id, Email) VALUES (3, 'john@example.com')

SELECT	* FROM Person

-- drop table Person

*/

/* My solution

-- Тривиальное решение для SQL Server
-- Не работает в mysql, выдаст ошибку You can't specify target table 'Person' for update in FROM clause
-- Поэтому для mysql надо обернуть в дополнительный запрос https://stackoverflow.com/q/4429319/5752652

DELETE FROM Person
WHERE id NOT IN
(
	SELECT MIN(id) FROM Person GROUP BY email
)

-- Вот это рабочий вариант для mysql:

DELETE FROM Person
WHERE id NOT IN
(
	SELECT Id FROM (SELECT MIN(id) AS Id FROM Person GROUP BY email) as t
)


*/

/* Solution

Approach: Using DELETE and WHERE clause [Accepted]

Algorithm

By joining this table with itself on the Email column, we can get the following code.

SELECT p1.*
FROM Person p1,
    Person p2
WHERE
    p1.Email = p2.Email
;

Then we need to find the bigger id having same email address with other records. So we can add a new condition to the WHERE clause like this.

SELECT p1.*
FROM Person p1,
    Person p2
WHERE
    p1.Email = p2.Email AND p1.Id > p2.Id
;

As we already get the records to be deleted, we can alter this statement to DELETE in the end.

MySQL

DELETE p1 FROM Person p1,
    Person p2
WHERE
    p1.Email = p2.Email AND p1.Id > p2.Id



*/