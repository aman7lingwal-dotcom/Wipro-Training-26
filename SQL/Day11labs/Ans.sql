

-- Write your query below
SELECT 
    g.book_title,
    o.customer_id
FROM goodreads g
JOIN orders o 
    ON g.book_id = o.book_id
WHERE g.price >= 10;

-- Write your query below
SELECT 
    SUM(Quantity) AS TotalQuantity
FROM spareparts
WHERE Model = 'four';