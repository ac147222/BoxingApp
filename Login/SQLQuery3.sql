CREATE TABLE dbo.tblUser (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password CHAR(6) NOT NULL, 
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('admin', 'user'))
);

INSERT INTO dbo.tblUser (Username, Password, Role) VALUES
('admin1', '123456', 'admin'),
('user1', '654321', 'user'),
('user2', '112233', 'user'),  
('admin2', '999888', 'admin');


