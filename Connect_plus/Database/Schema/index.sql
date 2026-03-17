
  
  -- Ticket Status indexes
  CREATE INDEX IDX_Ticket_Status ON Tickets(StatusId);

  -- Ticket creation date index
  CREATE INDEX IDX_Ticket_CreatedDate ON Tickets(CreatedAt);

  --Customer email index
  CREATE INDEX IDX_Customer_Email ON Customers(Email);