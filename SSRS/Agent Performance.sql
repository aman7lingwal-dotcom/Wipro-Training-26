SELECT 
    a.Name AS AgentName,
    COUNT(t.TicketId) AS TicketsHandled
FROM Tickets t
JOIN Agents a
ON t.AgentId = a.AgentId
GROUP BY a.Name
ORDER BY TicketsHandled DESC;
-- Total Tickets handled by the agents