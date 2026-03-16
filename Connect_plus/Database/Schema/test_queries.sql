-- SELECT * FROM Customers;

--SELECT * FROM Agents;

--SELECT * FROM Tickets;

SELECT
c.Name AS Customer,
a.Name AS Agent,
t.Description,
t.CreatedAt
FROM Tickets t
JOIN Customers c ON t.CustomerId = c.CustomerId
LEFT JOIN Agents a ON t.AgentId = a.AgentId;