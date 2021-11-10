IF OBJECT_ID (N'Jobs', N'U') IS NOT NULL 
BEGIn
	DROP TABLE Jobs
END
GO

CREATE TABLE Jobs (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name nvarchar(50) NOT NULL,
    ChangedDate DATE NOT NULL,
    Type int NOT NULL,
	IsProcessed bit Default 0 ,
	Reason nvarchar(100) Default 'no reason'
)
GO

