-- https://leetcode.com/problems/duplicate-emails/

-- Approach I: Using GROUP BY and a temporary table


/* Algorithm

Duplicated emails existed more than one time. To count the times each email exists, we can use the following code.

select Email, count(Email) as num
from Person
group by Email;

| Email   | num |
|---------|-----|
| a@b.com | 2   |
| c@d.com | 1   |

Taking this as a temporary table, we can get a solution as below.

*/

select Email from
(
  select Email, count(Email) as num
  from Person
  group by Email
) as statistic
where num > 1
;
