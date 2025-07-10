
--Выборка всех сотрудников
SELECT *
FROM Employees;

--Выборка сотрудников, у которых зарплата выше 10000
SELECT *
FROM Employees
WHERE Salary > 10000;

--Удаление сотрудников старше 70 лет

DELETE FROM Employees
WHERE DATEDIFF(YEAR, DateOfBirth, GETDATE()) > 70;

--Обновление зарплаты до 15000, если она меньше
UPDATE Employees
SET Salary = 15000
WHERE Salary < 15000;
