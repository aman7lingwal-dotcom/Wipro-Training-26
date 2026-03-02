--_________________Question 1______________________

-- Write your query below
SELECT
    c.category_id,
    c.name,
    SUM(p.amount) AS total_revenue,
    (AVG(p.amount) / overall.overall_avg_revenue) * 100
        AS percentage_of_overall_avg_revenue
FROM category c
JOIN film_category fc
    ON c.category_id = fc.category_id
JOIN inventory i
    ON fc.film_id = i.film_id
JOIN rental r
    ON i.inventory_id = r.inventory_id
JOIN payment p
    ON r.rental_id = p.rental_id
CROSS JOIN (
    SELECT
        AVG(film_revenue) AS overall_avg_revenue
    FROM (
        SELECT
            f.film_id,
            SUM(p.amount) AS film_revenue
        FROM film f
        JOIN inventory i ON f.film_id = i.film_id
        JOIN rental r ON i.inventory_id = r.inventory_id
        JOIN payment p ON r.rental_id = p.rental_id
        GROUP BY f.film_id
    )
) overall
GROUP BY c.category_id, c.name
ORDER BY total_revenue DESC
LIMIT 5;

--_________________Question 2______________________


-- Write your query below
SELECT
    e.DeptID,
    AVG(s.Salary) AS AvgSalary
FROM Employees e
JOIN Salaries s
    ON e.EmpID = s.EmpID
GROUP BY e.DeptID
HAVING AVG(s.Salary) > 50000;
--_________________Question 3______________________

-- Write your query below
SELECT
    store_id,
    film_id,
    title,
    rental_count
FROM (
    SELECT
        i.store_id,
        f.film_id,
        f.title,
        COUNT(r.rental_id) AS rental_count,
        ROW_NUMBER() OVER (
            PARTITION BY i.store_id
            ORDER BY COUNT(r.rental_id) DESC, f.film_id
        ) AS rn
    FROM inventory i
    JOIN rental r
        ON i.inventory_id = r.inventory_id
    JOIN film f
        ON i.film_id = f.film_id
    GROUP BY
        i.store_id,
        f.film_id,
        f.title
)
WHERE rn <= 3
ORDER BY
    store_id,
    rental_count DESC,
    film_id;