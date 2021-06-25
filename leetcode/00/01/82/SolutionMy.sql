-- https://leetcode.com/problems/duplicate-emails/

-- My own solution

select email from Person group by email having count(id) > 1
