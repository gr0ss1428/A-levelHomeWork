USE OfficeStruct

-- Отсортированный в обратном порядке список отделов с количеством сотрудников
SELECT d.Name,(SELECT COUNT(e.ID) FROM Employee e WHERE e.DepartmentId=d.ID) AS Workers FROM dbo.Department d  ORDER BY d.Name DESC;

--Вывести список сотрудников, получающих заработную плату большую чем у непосредственного руководителя
SELECT e.Name, e.ChiefId,e.Salary FROM Employee e WHERE  e.Salary>(SELECT e1.Salary FROM Employee e1 WHERE e1.ID= e.ChiefId) ORDER BY e.ChiefId;

--Вывести список отделов, количество сотрудников в которых не превышает 3 человек
SELECT d.Name, COUNT(e.Id) AS Worker FROM dbo.Department d
LEFT JOIN  Employee e ON d.ID = e.DepartmentId GROUP BY d.Name, d.ID HAVING COUNT(e.ID)<=3 ORDER BY Worker;

--Вывести список сотрудников, получающих максимальную заработную плату в своем отделе
SELECT e.Name, e.DepartmentId,e.Salary FROM Employee e
WHERE e.Salary=(SELECT MAX(e1.Salary) FROM Employee e1 WHERE e1.DepartmentId= e.DepartmentId) GROUP BY e.Name, e.DepartmentId, e.Salary ORDER BY e.Name;

--Найти список отделов с максимальной суммарной зарплатой сотрудников
    --Просто списов с средней зарплатой
SELECT d.Name ,(SELECT SUM(e1.Salary) FROM Employee e1 WHERE e1.DepartmentId=e.DepartmentId) AS Sum_salary FROM Employee e 
JOIN Department d ON d.ID=e.DepartmentId
GROUP BY d.Name, e.DepartmentId
ORDER BY Sum_salary DESC;

SELECT d.Name,SUM(e.Salary) AS Sum_salary FROM Employee e 
JOIN Department d ON d.ID=e.DepartmentId
GROUP BY e.DepartmentId,d.Name
HAVING SUM(e.Salary)=(SELECT TOP 1 SUM(e1.Salary) AS ssum FROM Employee e1 GROUP BY e1.DepartmentId ORDER BY ssum DESC )

--SQL-запрос, чтобы найти вторую самую высокую зарплату работника
INSERT INTO dbo.Employee(Name,DepartmentId,ChiefId,Salary) VALUES('Rita',3,2,1486.66);
SELECT e.Name, e.Salary  FROM Employee e GROUP BY e.Name,e.Salary  ORDER BY  e.Salary  DESC OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY; 

SELECT e.Name, e.Salary FROM Employee e
WHERE 2= (SELECT COUNT(DISTINCT(e1.Salary)) FROM Employee e1 WHERE e.Salary<=e1.Salary) ORDER BY e.Name;

--Вывести список сотрудников, не имеющих назначенного руководителя, работающего в том-же отделе
SELECT  e.ID, e.Name, e.DepartmentId, e.ChiefId FROM dbo.Employee e
JOIN dbo.Employee e1 ON e.DepartmentId!=e1.DepartmentId AND e.ChiefId=e1.ID OR e.ChiefId IS NULL GROUP BY e.ID,e.Name,e.DepartmentId,e.ChiefId 
 

