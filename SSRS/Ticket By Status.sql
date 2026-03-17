SELECT 
    ts.StatusName,
    COUNT(t.TicketId) AS TicketCount
FROM Tickets t
JOIN TicketStatus ts
ON t.StatusId = ts.StatusId
GROUP BY ts.StatusName;
-- Tickets By Status