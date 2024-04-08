# Write your MySQL query statement below
SELECT DISTINCT num AS ConsecutiveNums
FROM (
    SELECT num,
           LEAD(num) OVER (ORDER BY id) AS next_num,
           LEAD(num, 2) OVER (ORDER BY id) AS next_2_num
    FROM Logs
) AS subquery
WHERE num = next_num AND num = next_2_num;
