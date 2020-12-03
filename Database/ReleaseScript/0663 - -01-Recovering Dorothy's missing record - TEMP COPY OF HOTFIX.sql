--select * from dbo.Project where ProjectID = 14202

SET IDENTITY_INSERT dbo.Project ON

INSERT [dbo].[Project] ([ProjectID], [TenantID], [OverrideTaxonomyLeafID], [ProjectStageID], [ProjectName], [ProjectDescription], [ImplementationStartYear], [CompletionYear], [EstimatedTotalCostDeprecated], [ProjectLocationPoint], [PerformanceMeasureActualYearsExemptionExplanation], [IsFeatured], [ProjectLocationNotes], [PlanningDesignStartYear], [ProjectLocationSimpleTypeID], [EstimatedAnnualOperatingCostDeprecated], [FundingTypeID], [PrimaryContactPersonID], [ProjectApprovalStatusID], [ProposingPersonID], [ProposingDate], [PerformanceMeasureNotes], [SubmissionDate], [ApprovalDate], [ReviewedByPersonID], [DefaultBoundingBox], [ExpendituresNote], [ExpectedFundingUpdateNote], [LastUpdatedDate], [ProjectCategoryID], [BasicsComment], [CustomAttributesComment], [LocationSimpleComment], [LocationDetailedComment], [OrganizationsComment], [ContactsComment], [ExpectedAccomplishmentsComment], [ReportedAccomplishmentsComment], [BudgetComment], [ExpendituresComment], [ProposalClassificationsComment], [AttachmentsNotesComment], [PhotosComment], [SubmittedByPersonID]) 
VALUES (14202, 12, 2344, 2, N'Grande Ronde Buffalo Flats CC-40', N'Buffalo Peak Land & Livestock (BPL&L) is project''s major landowner. BPL&L has expressed interest in improving habitat conditions for fish & wildlife on property. Historic agricultural practices on the ranches in the valley along with State highway/County road construction have detrimentally impacted the existing Catherine Creek & Little Creek channels and adjacent floodplain. Working with BPL&L, ODOT & adjacent landowners the USWCD is proposing to enhance streamfow,  relocate/rehabilitate the Catherine Creek and Little Creek stream channels/floodplain and improve habitat conditions for chinook salmon & steelhead. The USWCD is requesting technical assistance from USBR''s CSRO Habitat Program.', 2019, 2024, NULL, 0xE6100000010CA5315A4755755DC0AA656B7D91984640, NULL, 0, N'Start point', 2019, 2, NULL, 1, 5750, 3, 5750, CAST(N'2020-04-24T14:28:33.360' AS DateTime), NULL, CAST(N'2020-05-07T12:37:53.453' AS DateTime), CAST(N'2020-08-18T11:55:52.403' AS DateTime), 5750, NULL, N'NA', NULL, CAST(N'2020-08-18T11:55:53.533' AS DateTime), 1, N'PIF was approved 1/28/2019...df', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6027)

SET IDENTITY_INSERT dbo.Project OFF


-- dbo.ProjectRelevantCostType
--select * from dbo.ProjectRelevantCostType where ProjectID = 14202

SET IDENTITY_INSERT dbo.ProjectRelevantCostType ON

insert dbo.ProjectRelevantCostType(ProjectRelevantCostTypeID, TenantID, ProjectID, CostTypeID, ProjectRelevantCostTypeGroupID)
values
(365, 12, 14202, 13, 2),
(366, 12, 14202, 14, 2),
(367, 12, 14202, 15, 2),
(368, 12, 14202, 11, 2),
(369, 12, 14202, 12, 2)

SET IDENTITY_INSERT dbo.ProjectRelevantCostType OFF



-- dbo.ProjectOrganization
--select * from dbo.ProjectOrganization where ProjectID = 14202
--delete from dbo.ProjectOrganization where ProjectID = 14202

SET IDENTITY_INSERT dbo.ProjectOrganization ON

insert dbo.ProjectOrganization(ProjectOrganizationID, TenantID, ProjectID, OrganizationID, OrganizationRelationshipTypeID)
values
(16551, 12, 14202, 6345, 42),
(16552, 12, 14202, 6410, 42),
(16553, 12, 14202, 6160, 42),
(16554, 12, 14202, 6413, 40),
(16555, 12, 14202, 6318, 40),
(16556, 12, 14202, 6345, 40),
(16557, 12, 14202, 6308, 40),
(16558, 12, 14202, 6413, 39)

SET IDENTITY_INSERT dbo.ProjectOrganization OFF

--select * from dbo.TechnicalAssistanceRequest where ProjectID = 14202
--select * from dbo.ProjectFundingSourceExpenditure where ProjectID = 14202
--select * from dbo.ProjectUpdateBatch where ProjectID = 14202
--select * from dbo.ProjectProjectStatus where ProjectID = 14202
--select * from dbo.ProjectExternalLink where ProjectID = 14202
--select * from dbo.ProjectLocationStaging where ProjectID = 14202


--select * from dbo.NotificationProject where ProjectID = 14202
--delete from dbo.NotificationProject where ProjectID = 14202

SET IDENTITY_INSERT dbo.NotificationProject ON

insert dbo.NotificationProject(NotificationProjectID, TenantID, NotificationID, ProjectID)
values
(15366, 12, 15733, 14202),
(15367, 12, 15734, 14202),
(15474, 12, 15762, 14202),
(15475, 12, 15763, 14202),
(15482, 12, 15770, 14202),
(15483, 12, 15771, 14202),
(15809, 12, 15860, 14202)

SET IDENTITY_INSERT dbo.NotificationProject OFF

--select * from dbo.PerformanceMeasureExpected where ProjectID = 14202
--delete from dbo.PerformanceMeasureExpected where ProjectID =14202
SET IDENTITY_INSERT dbo.PerformanceMeasureExpected ON

insert dbo.PerformanceMeasureExpected(PerformanceMeasureExpectedID, TenantID, ProjectID, PerformanceMeasureID, ExpectedValue)
values

(11035, 12, 14202, 3473, null)
SET IDENTITY_INSERT dbo.PerformanceMeasureExpected OFF


--select * from  PerformanceMeasureExpectedSubcategoryOption where PerformanceMeasureExpectedID = 11035





--select * from dbo.ProjectAssessmentQuestion  where ProjectID =14202
--delete from dbo.ProjectNoFundingSourceIdentified where ProjectID =14202

SET IDENTITY_INSERT dbo.ProjectNoFundingSourceIdentified ON

insert dbo.ProjectNoFundingSourceIdentified(ProjectNoFundingSourceIdentifiedID, TenantID, ProjectID, CalendarYear,NoFundingSourceIdentifiedYet,CostTypeID)
values

(765, 12, 14202, 2024, 0.00, 11),
(766, 12, 14202, 2023, 0.00, 11),
(767, 12, 14202, 2022, 500000.00, 11),
(768, 12, 14202, 2021, 1100000.00, 11),
(769, 12, 14202, 2020, 2000000.00, 11),
(770, 12, 14202, 2019, 700000.00, 11)

SET IDENTITY_INSERT dbo.ProjectNoFundingSourceIdentified OFF

--select * from dbo.SecondaryProjectTaxonomyLeaf where ProjectID =14202



--select * from dbo.ProjectContact where ProjectID =14202
--delete from dbo.ProjectContact where ProjectID =14202
SET IDENTITY_INSERT dbo.ProjectContact ON

insert dbo.ProjectContact(ProjectContactID, TenantID, ProjectID, ContactID, ContactRelationshipTypeID)
values

(963, 12, 14202, 6016, 5),
(965, 12, 14202, 6010, 7),
(966, 12, 14202, 6012, 6)

SET IDENTITY_INSERT dbo.ProjectContact OFF

--select * from dbo.ProjectExemptReportingYear where ProjectID =14202
--select * from dbo.ProjectLocation where ProjectID =14202


--select * from dbo.ProjectClassification where ProjectID =14202
--delete from dbo.ProjectClassification where ProjectID =14202
SET IDENTITY_INSERT dbo.ProjectClassification ON

insert dbo.ProjectClassification(ProjectClassificationID, TenantID, ProjectID, ClassificationID, ProjectClassificationNotes)
values

(9248, 12, 14202, 2096, NULL),
(9249, 12, 14202, 2098, NULL),
(9250, 12, 14202, 2105, 'Relocate/rehabilitate the Catherine Creek and Little Cream stream channels/floodplain.')

SET IDENTITY_INSERT dbo.ProjectClassification OFF

--select * from dbo.ProjectTag where ProjectID =14202
--select * from Reclamation.ProjectFundingSourceBudget where ProjectID =14202
--select * from dbo.ProjectNote where ProjectID =14202



--select * from dbo.ProjectGeospatialArea where ProjectID =14202
--delete from dbo.ProjectGeospatialArea where ProjectID =14202
SET IDENTITY_INSERT dbo.ProjectGeospatialArea ON

insert dbo.ProjectGeospatialArea(ProjectGeospatialAreaID, TenantID, ProjectID, GeospatialAreaID)
values

(52961, 12, 14202, 9796),
(52965, 12, 14202, 16644),
(52963, 12, 14202, 16652),
(52964, 12, 14202, 16713),
(52962, 12, 14202, 16825),
(52988, 12, 14202, 16886)

SET IDENTITY_INSERT dbo.ProjectGeospatialArea OFF

--select * from dbo.PerformanceMeasureActual where ProjectID =14202


--select * from dbo.ProjectImage where ProjectID =14202
--delete from dbo.ProjectImage where ProjectID =14202

SET IDENTITY_INSERT dbo.ProjectImage ON

insert dbo.ProjectImage(ProjectImageID, TenantID, FileResourceInfoID, ProjectID, ProjectImageTimingID, Caption, Credit, IsKeyPhoto, ExcludeFromFactSheet)
values

(4223, 12, 14175, 14202, 2, 'BF Overview', 'PIF', 1, 1)

SET IDENTITY_INSERT dbo.ProjectImage OFF





--select * from dbo.ProjectCustomAttribute where ProjectID =14202
--delete from dbo.ProjectCustomAttribute where ProjectID =14202

SET IDENTITY_INSERT dbo.ProjectCustomAttribute ON

insert dbo.ProjectCustomAttribute(ProjectCustomAttributeID, TenantID, ProjectID, ProjectCustomAttributeTypeID)
values

(19758,12, 14202, 52)

SET IDENTITY_INSERT dbo.ProjectCustomAttribute OFF


--select * from dbo.ProjectCustomAttributeValue where ProjectCustomAttributeID = 19758
--delete from dbo.ProjectCustomAttributeValue where ProjectCustomAttributeID = 19758

SET IDENTITY_INSERT dbo.ProjectCustomAttributeValue ON

insert dbo.ProjectCustomAttributeValue(ProjectCustomAttributeValueID, TenantID, ProjectCustomAttributeID, AttributeValue)
values

(23609, 12, 19758, 'Complex')

SET IDENTITY_INSERT dbo.ProjectCustomAttributeValue OFF

--select * from dbo.ActionItem where ProjectID =14202
--select * from dbo.ProjectInternalNote where ProjectID =14202
--select * from Reclamation.CostAuthorityProject where ProjectID =14202
--select * from dbo.ProjectEvaluation where ProjectID =14202
--select * from dbo.ProjectAttachment where ProjectID =14202

--select * from dbo.ProjectGeospatialAreaTypeNote where ProjectID =14202
--delete from dbo.ProjectGeospatialAreaTypeNote where ProjectID =14202

SET IDENTITY_INSERT dbo.ProjectGeospatialAreaTypeNote ON

insert dbo.ProjectGeospatialAreaTypeNote(ProjectGeospatialAreaTypeNoteID, TenantID, ProjectID, GeospatialAreaTypeID, Notes)
values

(404, 12, 14202, 21, 'Spring/Summer')

SET IDENTITY_INSERT dbo.ProjectGeospatialAreaTypeNote OFF
