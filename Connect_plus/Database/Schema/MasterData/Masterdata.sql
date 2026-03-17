 -- Ticket Status

INSERT INTO TicketStatus (StatusName)
VALUES
('Open'),
('In Progress'),
('Resolved'),
('Closed');


-- Categories

INSERT INTO TicketCategories (CategoryName)
VALUES
('Technical Issue'),
('Billing Problem'),
('Account Access');


-- Agents

INSERT INTO Agents (Name, Department, Email)
VALUES
('Rahul Mehta','Technical Support','rahul@connectplus.com'),
('Priya Sharma','Billing Support','priya@connectplus.com');
