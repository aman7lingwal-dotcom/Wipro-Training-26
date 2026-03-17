SELECT 
    c.Name AS CustomerName,
    COUNT(t.TicketId) AS TotalTickets
FROM Tickets t
JOIN Customers c
ON t.CustomerId = c.CustomerId
GROUP BY c.Name
ORDER BY TotalTickets DESC;
-- customers with most support requests