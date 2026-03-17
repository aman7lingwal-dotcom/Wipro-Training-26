CREATE VIEW vw_TicketSummary AS
SELECT 
    t.TicketId,
    c.Name AS CustomerName,
    tc.CategoryName,
    a.Name AS AgentName,
    ts.StatusName,
    t.CreatedAt
FROM Tickets t
JOIN Customers c ON t.CustomerId = c.CustomerId
JOIN TicketCategories tc ON t.CategoryId = tc.CategoryId
JOIN Agents a ON t.AgentId = a.AgentId
JOIN TicketStatus ts ON t.StatusId = ts.StatusId;
-- Create view summary for easy information