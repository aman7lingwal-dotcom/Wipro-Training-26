

-- Customers table

CREATE TABLE Customers(
CustomerId INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Email VARCHAR(150) NOT NULL UNIQUE,
Phone VARCHAR(20),
CreatedAt DATETIME DEFAULT GETDATE()
);

-- Agents table

CREATE TABLE Agents
(
AgentId INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(100),
Department VARCHAR(100),
Email VARCHAR(150));

-- Ticket Categories

CREATE TABLE TicketCategories(
CategoryId INT IDENTITY(1,1) PRIMARY KEY,
CategoryName VARCHAR(100)
);

-- Ticket Status

CREATE TABLE TicketStatus(
StatusId INT IDENTITY(1,1) PRIMARY KEY,
StatusName VARCHAR(50)
);

-- Tickets table

CREATE TABLE Tickets(
TicketId INT IDENTITY(1,1) PRIMARY KEY,
CustomerId INT NOT NULL,
CategoryId INT NOT NULL,
AgentId INT NULL,
StatusId INT NOT NULL,
Description VARCHAR(500),
CreatedAt DATETIME DEFAULT GETDATE(),
UpdatedAt DATETIME NULL,
ResolutionNotes VARCHAR(500),
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
FOREIGN KEY (CategoryId) REFERENCES TicketCategories(CategoryId),
FOREIGN KEY (AgentId) REFERENCES Agents(AgentId),
FOREIGN KEY (StatusId) REFERENCES TicketStatus(StatusId));