
-- View to get all tickets with customer, agent, category, and status details
CREATE VIEW TicketServiceView
AS

SELECT
t.TicketId,
c.Name AS CustomerName,
a.Name AS AgentName,
cat.CategoryName,
s.StatusName,
t.Description,
t.CreatedAt

FROM Tickets t

JOIN Customers c
ON t.CustomerId = c.CustomerId

JOIN TicketCategories cat
ON t.CategoryId = cat.CategoryId

JOIN TicketStatus s
ON t.StatusId = s.StatusId

LEFT JOIN Agents a
ON t.AgentId = a.AgentId;