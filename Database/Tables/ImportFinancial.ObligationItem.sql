SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ObligationItem](
	[ObligationItemID] [int] IDENTITY(1,1) NOT NULL,
	[ObligationItemKey] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ObligationNumberID] [int] NOT NULL,
 CONSTRAINT [PK_ObligationItem_ObligationItemID] PRIMARY KEY CLUSTERED 
(
	[ObligationItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ObligationItem_ObligationItemKey_ObligationNumberID] UNIQUE NONCLUSTERED 
(
	[ObligationItemKey] ASC,
	[ObligationNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[ObligationItem]  WITH CHECK ADD  CONSTRAINT [FK_ObligationItem_ObligationNumber_ObligationNumberID] FOREIGN KEY([ObligationNumberID])
REFERENCES [ImportFinancial].[ObligationNumber] ([ObligationNumberID])
GO
ALTER TABLE [ImportFinancial].[ObligationItem] CHECK CONSTRAINT [FK_ObligationItem_ObligationNumber_ObligationNumberID]