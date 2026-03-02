
-- Write your query below 
CREATE TABLE Employees_new (
    employee_id INTEGER PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50), department_id INTEGER, 
    FOREIGN KEY (department_id) REFERENCES Departments(department_id)
);

INSERT INTO Employees_new (employee_id, first_name, last_name, department_id)
SELECT employee_id, first_name, last_name, department_id FROM Employees;

DROP TABLE Employees;

ALTER TABLE Employees_new RENAME TO Employees;


--_________________Question 2______________________


-- Write your query below
SELECT
    c.country_id,
    c.country,
    COUNT(r.rental_id) AS rental_count
FROM country c
JOIN city ci
    ON c.country_id = ci.country_id
JOIN address a
    ON ci.city_id = a.city_id
JOIN customer cu
    ON a.address_id = cu.address_id
JOIN rental r
    ON cu.customer_id = r.customer_id
GROUP BY
    c.country_id,
    c.country
ORDER BY
    rental_count DESC
LIMIT 3;
--_________________Question 3______________________

-- Write your query below
SELECT d.DishName, d.Price
FROM Dishes d
JOIN Restaurant r
ON d.RestaurantId = r.Id
WHERE r.Name = 'Punjabi Rasoi';