
  
  --Ticket volume by status

CREATE PROCEDURE GetTicketVolumeByStatus
AS
BEGIN

SELECT
s.StatusName,
COUNT(*) AS TicketCount

FROM Tickets t

JOIN TicketStatus s
ON t.StatusId = s.StatusId

GROUP BY s.StatusName;

END;