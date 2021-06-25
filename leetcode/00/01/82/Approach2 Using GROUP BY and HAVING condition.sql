-- https://leetcode.com/problems/duplicate-emails/

-- Approach II: Using GROUP BY and HAVING condition

/* Solution 

MySQL

A more common used way to add a condition to a GROUP BY is to use the HAVING clause, which is much simpler and more efficient.

So we can rewrite the above solution to this one.

*/

select Email
from Person
group by Email
having count(Email) > 1;
