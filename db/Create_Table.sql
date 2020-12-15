
USE Examples;
GO

CREATE TABLE [dbo].[DailySalesStats](
    [Date] [smalldatetime] NOT NULL,
    [SalesPersonId] [int] NOT NULL,
    [TotalSales] [int] NOT NULL,
 CONSTRAINT [PK_DailySalesStats] PRIMARY KEY CLUSTERED 
(
    [Date] ASC,
    [SalesPersonId] ASC
)) ON [PRIMARY]
GO


