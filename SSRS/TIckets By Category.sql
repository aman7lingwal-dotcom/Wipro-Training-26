SELECT 
    tc.CategoryName,
    COUNT(t.TicketId) AS TotalTickets
FROM Tickets t
JOIN TicketCategories tc 
ON t.CategoryId = tc.CategoryId
GROUP BY tc.CategoryName
ORDER BY TotalTickets DESC;
-- Tickets By Category