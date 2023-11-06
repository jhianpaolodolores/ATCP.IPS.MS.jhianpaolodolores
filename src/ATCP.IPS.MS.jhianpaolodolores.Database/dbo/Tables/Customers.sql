CREATE TABLE [dbo].[Customers](
[CustomerID] [int] IDENTITY(1,1) NOT NULL,
[FirstName] [nvarchar](50) NOT NULL,
[MiddleName] [nvarchar](50) NOT NULL,
[LastName] [nvarchar](50) NULL,
[Address] [nvarchar](250) NOT NULL,
[Age] [int] NOT NULL,
[Gender] [nvarchar](10) NULL,
[CreatedBy] [nvarchar](50) NOT NULL,
[CreatedDttm] [datetime] NOT NULL,
[UpdatedBy] [nvarchar](50) NULL,
[UpdatedDttm] [datetime] NULL,
[IsActive] [bit] NOT NULL,
CONSTRAINT [PK_Customer_CustomerID] PRIMARY KEY CLUSTERED
(
[CustomerID] ASC
) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
