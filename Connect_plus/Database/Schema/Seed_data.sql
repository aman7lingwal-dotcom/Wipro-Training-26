
-- Customers

INSERT INTO Customers (Name, Email, Phone)
VALUES
('Aman Lingwal','aman@gmail.com','9991112222'),
('Rohit Singh','rohit@gmail.com','9991113333');


-- Tickets

INSERT INTO Tickets
(CustomerId,CategoryId,AgentId,StatusId,Description)

VALUES
(1,1,1,1,'Internet not working'),
(2,2,2,1,'Billing amount incorrect');