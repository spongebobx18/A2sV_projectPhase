SELECT sub.name AS Employee
FROM Employee AS sub
JOIN Employee AS manager ON sub.managerId = manager.id
WHERE sub.salary > manager.salary;
