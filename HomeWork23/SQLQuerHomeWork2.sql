USE OfficeStruct

-- ��������������� � �������� ������� ������ ������� � ����������� �����������
SELECT d.Name,(SELECT COUNT(e.ID) FROM Employee e WHERE e.DepartmentId=d.ID) AS Workers FROM dbo.Department d  ORDER BY d.Name DESC;

--������� ������ �����������, ���������� ���������� ����� ������� ��� � ����������������� ������������
SELECT e.Name, e.ChiefId,e.Salary FROM Employee e WHERE  e.Salary>(SELECT e1.Salary FROM Employee e1 WHERE e1.ID= e.ChiefId) ORDER BY e.ChiefId;

--������� ������ �������, ���������� ����������� � ������� �� ��������� 3 �������
SELECT d.Name, COUNT(e.Id) AS Worker FROM dbo.Department d
LEFT JOIN  Employee e ON d.ID = e.DepartmentId GROUP BY d.Name, d.ID HAVING COUNT(e.ID)<=3 ORDER BY Worker;

--������� ������ �����������, ���������� ������������ ���������� ����� � ����� ������
SELECT e.Name, e.DepartmentId,e.Salary FROM Employee e
WHERE e.Salary=(SELECT MAX(e1.Salary) FROM Employee e1 WHERE e1.DepartmentId= e.DepartmentId) GROUP BY e.Name, e.DepartmentId, e.Salary ORDER BY e.Name;

--����� ������ ������� � ������������ ��������� ��������� �����������
    --������ ������ � ������� ���������
SELECT d.Name ,(SELECT AVG(e1.Salary) FROM Employee e1 WHERE e1.DepartmentId=e.DepartmentId) AS asdsd FROM Employee e 
JOIN Department d ON d.ID=e.DepartmentId
GROUP BY d.Name, e.DepartmentId;

SELECT TOP 1  d.Name , AVG(e1.Salary) AS Max_average FROM Employee e 
JOIN Department d ON d.ID=e.DepartmentId
JOIN Employee e1 ON e.DepartmentId = e1.DepartmentId
GROUP BY d.Name, e.DepartmentId ORDER BY Max_average DESC;

SELECT X.Name,X.Average  FROM( 
	SELECT d.Name, AVG(e1.Salary) AS Average FROM Employee e 
	JOIN Department d ON d.ID=e.DepartmentId
	JOIN Employee e1 ON e.DepartmentId = e1.DepartmentId
	GROUP BY d.Name, e.DepartmentId
)X 
JOIN (
	SELECT MAX(X.Average) AS max_Average FROM( 
	SELECT d.Name, AVG(e1.Salary) AS Average FROM Employee e 
	JOIN Department d ON d.ID=e.DepartmentId
	JOIN Employee e1 ON e.DepartmentId = e1.DepartmentId
	GROUP BY d.Name, e.DepartmentId)X
)Y ON X.Average=Y.max_Average;

--SQL-������, ����� ����� ������ ����� ������� �������� ���������
SELECT e.Name, MAX(e.Salary) AS Max_Salary FROM Employee e GROUP BY e.Name  ORDER BY  Max_Salary DESC OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY; 

SELECT e.Name, e.Salary FROM Employee e
WHERE 2= (SELECT COUNT(DISTINCT(e1.Salary)) FROM Employee e1 WHERE e.Salary<=e1.Salary) ORDER BY e.Name;

