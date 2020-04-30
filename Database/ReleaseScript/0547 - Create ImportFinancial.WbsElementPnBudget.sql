
/*
Following the same pattern set where:

Staging.StageImpApGenSheet => ImportFinancial.WbsElementObligationItemInvoice
and
Staging.StageImpPayRecV3 => ImportFinancial.WbsElementObligationItemBudget

Now we do

Staging.StagePnBudget => ImportFinancial.WbsElementPnBudget

*/

-- ImportFinancial.PnBudgetFundType

CREATE TABLE ImportFinancial.PnBudgetFundType
(
    PnBudgetFundTypeID [int] NOT NULL,
    PnBudgetFundTypeName [varchar](100) NOT NULL,
    PnBudgetFundTypeDisplayName [varchar](100) NOT NULL
 CONSTRAINT [PK_PnBudgetFundType_PnBudgetFundTypeID] PRIMARY KEY CLUSTERED 
(
    PnBudgetFundTypeID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


delete from ImportFinancial.PnBudgetFundType

insert ImportFinancial.PnBudgetFundType (PnBudgetFundTypeID, PnBudgetFundTypeName, PnBudgetFundTypeDisplayName) values 
(1, 'GeneralAppropriated', 'General/Appropriated'),
(2, 'Reimbursable', 'Reimbursable')

/*
This is **NOT** a generalized, Tenant-configurable Fiscal Quarter. This is just for Reclamation.
If such a concept goes mainline, it could replace this hard-coded idea.
*/
-- ImportFinancial.FiscalQuarter
-----------------------------------
CREATE TABLE ImportFinancial.FiscalQuarter
(
    FiscalQuarterID [int] NOT NULL,
    FiscalQuarterNumber [int] not null,
    FiscalQuarterName [varchar](100) NOT NULL,
    FiscalQuarterDisplayName [varchar](100) NOT NULL,
    FiscalQuarterStartMonth int not null,
    FiscalQuarterStartDay int not null,
 CONSTRAINT [PK_FiscalQuarter_FiscalQuarterID] PRIMARY KEY CLUSTERED 
(
    FiscalQuarterID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

delete from ImportFinancial.FiscalQuarter

/*
Dorothy:

FY begins October 1 and ends Sept 30.

So FY 2020 began 10/1/2019 and ends 9/30/2020.

*/

-- In our import, 000/2020 => 'QuarterOne'
insert ImportFinancial.FiscalQuarter (FiscalQuarterID, FiscalQuarterNumber, FiscalQuarterName, FiscalQuarterDisplayName, FiscalQuarterStartMonth,FiscalQuarterStartDay) values 
(1, 1, 'QuarterOne', 'Quarter Four (October - December)', 10, 1),
(2, 2, 'QuarterTwo', 'Quarter Two (January - March)', 1, 1),
(3, 3, 'QuarterThree', 'Quarter Three (Apr - June)', 4, 1),
(4, 4, 'QuarterFour', 'Quarter Four (July - September)', 7, 1)
GO
/*

ImportFinancial.CommitmentItem

*/
CREATE TABLE ImportFinancial.CommitmentItem
(
    CommitmentItemID [int] IDENTITY(1,1) NOT NULL,
    CommitmentItem [varchar](100) NOT NULL
 CONSTRAINT [PK_CommitmentItem_CommitmentItemID] PRIMARY KEY CLUSTERED 
(
    CommitmentItemID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

insert ImportFinancial.CommitmentItem(CommitmentItem)
values
('211P00'),
('ALLOBJ'),
('261A00'),
('251UA0'),
('121200'),
('257P00'),
('253L00'),
('233U00'),
('121D00'),
('411C00'),
('111G00'),
('BUDRES'),
('211T00'),
('121K00'),
('253D00'),
('111T00'),
('312J00'),
('252U00'),
('269F00'),
('252R00'),
('233T00'),
('121J00'),
('253J00'),
('312W00'),
('121T00'),
('312E00'),
('312D00'),
('121500'),
('121EL0'),
('115F00'),
('264A00'),
('115A00'),
('252T00'),
('413A00'),
('253U00'),
('224F00'),
('213P00'),
('121A00'),
('233K00'),
('251A00'),
('211C00'),
('211E00'),
('121E00'),
('262A00'),
('121300'),
('233C00'),
('213W00'),
('REIMA0'),
('121W00'),
('211I00'),
('233L00'),
('9ACCR0'),
('310UN0'),
('231A00'),
('211R00'),
('233G00'),
('252K00'),
('213D00'),
('REIMB0'),
('257I00'),
('211A00'),
('233LA0'),
('121FL0'),
('253Z00'),
('213V00'),
('312B00'),
('252A00'),
('232A00'),
('253F00'),
('254A00'),
('113G00'),
('265F00'),
('252UA0'),
('253H00'),
('312V00'),
('211B00'),
('253G00'),
('121G00'),
('121B00'),
('211D00'),
('241A00'),
('121F00'),
('253S00'),
('312F00'),
('251B00'),
('253I00'),
('233Q00'),
('111A00'),
('261M00'),
('212C00'),
('252Z00'),
('251V00'),
('410UA0'),
('312C00'),
('113A00')

/*

ImportFinancial.WbsElementPnBudget

*/

CREATE TABLE ImportFinancial.WbsElementPnBudget
(
    WbsElementPnBudgetID int IDENTITY(1,1) NOT NULL,
    WbsElementID int NOT NULL,
    PnBudgetFundTypeID int NOT NULL,
    FundingSourceID int not null,
    FundsCenter varchar(10) not null,
    FiscalQuarterID int not null,
    FiscalYear int not null,
    CommitmentItemID int not null,
    FIDocNumber varchar(200) not null,
    Recoveries float null,
    CommittedButNotObligated float null,
    TotalObligations float null,
    TotalExpenditures float null,
    UndeliveredOrders float null
CONSTRAINT [PK_WbsElementPnBudget_WbsElementPnBudgetID] PRIMARY KEY CLUSTERED 
(
    WbsElementPnBudgetID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

-- FK -- WbsElementID
ALTER TABLE [ImportFinancial].WbsElementPnBudget  WITH CHECK ADD  
CONSTRAINT [FK_WbsElementPnBudget_WbsElement_WbsElementID] FOREIGN KEY([WbsElementID])
REFERENCES [ImportFinancial].[WbsElement] ([WbsElementID])
GO

-- FK -- PnBudgetFundTypeID
ALTER TABLE [ImportFinancial].WbsElementPnBudget  WITH CHECK ADD  
CONSTRAINT [FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID] FOREIGN KEY(PnBudgetFundTypeID)
REFERENCES [ImportFinancial].PnBudgetFundType (PnBudgetFundTypeID)
GO

-- FK -- FundingSourceID
ALTER TABLE [ImportFinancial].WbsElementPnBudget  WITH CHECK ADD  
CONSTRAINT [FK_WbsElementPnBudget_FundingSource_FundingSourceID] FOREIGN KEY(FundingSourceID)
REFERENCES dbo.FundingSource (FundingSourceID)
GO

-- FK -- FiscalQuarterID
ALTER TABLE [ImportFinancial].WbsElementPnBudget  WITH CHECK ADD  
CONSTRAINT [FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID] FOREIGN KEY(FiscalQuarterID)
REFERENCES ImportFinancial.FiscalQuarter (FiscalQuarterID)
GO

-- FK -- CommitmentItemID
ALTER TABLE [ImportFinancial].WbsElementPnBudget  WITH CHECK ADD  
CONSTRAINT [FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID] FOREIGN KEY(CommitmentItemID)
REFERENCES ImportFinancial.CommitmentItem (CommitmentItemID)
GO
