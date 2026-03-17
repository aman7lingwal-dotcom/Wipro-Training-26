-- Total Tickets
SELECT COUNT(*) AS TotalTickets
FROM Tickets;

-- Tickets by Status
SELECT s.StatusName, COUNT(*) AS TicketCount
FROM Tickets t
JOIN TicketStatus s ON t.StatusId = s.StatusId
GROUP BY s.StatusName;

-- Tickets by Category
SELECT c.CategoryName, COUNT(*) AS TicketCount
FROM Tickets t
JOIN TicketCategories c ON t.CategoryId = c.CategoryId
GROUP BY c.CategoryName;

--Tickets by Agent
SELECT a.Name AS AgentName, COUNT(*) AS TicketCount
FROM Tickets t
JOIN Agents a ON t.AgentId = a.AgentId
GROUP BY a.Name;

--Resolved Tickets
SELECT COUNT(*) AS ResolvedTickets
FROM Tickets t
JOIN TicketStatus ts ON t.StatusId = ts.StatusId
WHERE ts.StatusName = 'Resolved';

--Stored Procedure: GetTicketVolumeByStatus
EXEC GetTicketVolumeByStatus;

--Average Resolution Time
SELECT 
    AVG(DATEDIFF(MINUTE, CreatedAt, UpdatedAt)) AS AvgResolutionTimeHours
FROM Tickets
WHERE StatusId = (SELECT StatusId FROM TicketStatus WHERE StatusName = 'Resolved');

--Tickets Created in Last 7 Days
SELECT COUNT(*) AS TicketsLast7Days
FROM Tickets
WHERE CreatedAt >= DATEADD(DAY, -7, GETDATE());