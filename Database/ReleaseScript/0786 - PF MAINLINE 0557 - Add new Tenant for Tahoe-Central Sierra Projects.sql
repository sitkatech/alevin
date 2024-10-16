
--insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, FiscalYearStartDate, UseFiscalYears, ArePerformanceMeasuresExternallySourced, AreOrganizationsExternallySourced, AreFundingSourcesExternallySourced, TenantEnabled)
--values 
--(14, 'TCSProjectTracker', 'tcsprojecttracker.localhost.projectfirma.com', 'tcsprojecttracker.qa.projectfirma.com', 'tcsprojecttracker.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 1)


--	alter table dbo.FileResourceInfo add LogoFileResourceInfoIDFromTenant int null
--	alter table dbo.FileResourceInfo add ProjectImageIDFromTenant int null
--	GO

--	declare @TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime, @primaryContactPersonID int
--	select @TenantIDFrom = 5, @TenantIDTo = 14, @TenantName = 'TCS Project Tracker', @ToolDisplayName = 'Tahoe-Central Sierra Project Tracker', @createDate = CURRENT_TIMESTAMP

--	insert into dbo.TenantAttribute(TenantID, DefaultBoundingBox, 
--	MinimumYear, PrimaryContactPersonID, TenantShortDisplayName, ToolDisplayName,
--	KeystoneOpenIDClientIdentifier, KeystoneOpenIDClientSecret, GeoServerNamespace, 
--	BudgetTypeID, TaxonomyLevelID, AssociatePerfomanceMeasureTaxonomyLevelID, AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardIncludeReportingOrganizationType, 
--	ShowProposalsToThePublic,  IsActive, ProjectExternalDataSourceEnabled, ShowLeadImplementerLogoOnFactSheet, EnableAccomplishmentsDashboard, EnableSecondaryProjectTaxonomyLeaf, 

--	CanManageCustomAttributes, ExcludeTargetedFundingOrganizations, UseProjectTimeline, EnableEvaluations, EnableProjectCategories, EnableReports, EnableMatchmaker, MatchmakerAlgorithmIncludesProjectGeospatialAreas, AreGeospatialAreasExternallySourced, 
--	ShowPhotoCreditOnFactSheet, TrackAccomplishments, ShowExpectedPerformanceMeasuresOnFactSheet, EnableStatusUpdates, EnableSolicitations, EnableSimpleAccomplishmentsDashboard, SetTargetsByGeospatialArea, ReportFinancialsAtProjectLevel)
--	values
--	(@TenantIDTo, 0xE61000000104050000000100D33FF3535EC0B9B6B271B9E343400100D33FF3535EC05B2B37C4854F43400100F73F67F85DC05B2B37C4854F43400100F73F67F85DC0B9B6B271B9E343400100D33FF3535EC0B9B6B271B9E3434001000000020000000001000000FFFFFFFF0000000003, 
--	2010, @primaryContactPersonID, @TenantName, @ToolDisplayName,
--	'TCSProjectTracker', 'CE6730FE-D0BD-405D-8026-FB4F25B3124D', 'TCSProjectTracker', 
--	2, 1, 1, 1, 1,
--	0, 1, 0, 0, 0, 0, 
--	1, 0, 0, 0, 0, 0, 0, 0, 0,
--	0, 1, 0, 0, 0, 0, 0, 1)

--	declare @newTaxonomyTrunkID int

--	insert into dbo.TaxonomyTrunk(TenantID, TaxonomyTrunkName)
--	values(@TenantIDTo, 'Default')

--	select @newTaxonomyTrunkID = SCOPE_IDENTITY()

--	insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName)
--	values(@TenantIDTo, @newTaxonomyTrunkID, 'Default')

--	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
--	select FirmaPageTypeID, @TenantIDTo as TenantID
--	from dbo.FirmaPage fp
--	where fp.TenantID = @TenantIDFrom

--	insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID)
--	select FieldDefinitionID, @TenantIDTo as TenantID
--	from dbo.FieldDefinitionData fdd
--	where fdd.TenantID = @TenantIDFrom

--	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType, LayerOnByDefault)
--	values
--	(@TenantIDTo, 'Federal', 'FED', '#1f77b4', 0, 0, 1, 0),
--	(@TenantIDTo, 'Local', 'LOC', '#aec7e8', 0, 0, 1, 0),
--	(@TenantIDTo, 'Private', 'PRI', '#ff7f0e', 0, 1, 1, 0),
--	(@TenantIDTo, 'State', 'ST', '#ffbb78', 0, 0, 1, 0)

--	declare @privateOrgTypeIDForTenant int
--	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'

--	insert into dbo.Organization(TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl, IsUnknownOrUnspecified, UseOrganizationBoundaryForMatchmaker)
--	select @TenantIDTo as TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl, IsUnknownOrUnspecified, UseOrganizationBoundaryForMatchmaker
--	from dbo.Organization
--	where OrganizationID in (1421, 1422) -- ESA Sitka, Unknown Org

--	declare @federalOrgTypeIDForTenant int
--	select @federalOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Federal'

--	-- TODO create an Salton Sea org in keystone?
--	--insert into dbo.Organization(TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
--	--values (@TenantIDTo, 'C57B7361-2426-4FE2-9AFF-B1DD743D4058', 'Washington State Department of Natural Resources', 'WA DNR', @federalOrgTypeIDForTenant, 1, 'http://www.dnr.wa.gov')

--	declare @sitkaOrgIDForTenant int
--	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'ESA Sitka'

--	-- copy users from SSMP because the emails are updated (e.g. Liz uses ESA email). Make everyone here an ESA Admin
--	insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
--	select @TenantIDTo as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, 8, @createDate, @createDate, @createDate
--		from dbo.Person p
--	where TenantID = 13
--	and email in (
--	'jrodrigues@esassoc.com',
--	'shannon.bulloch@sitkatech.com',
--	'lchristeleit@esassoc.com',
--	'matt@sitkatech.com',
--	'mauricio.herrera@sitkatech.com')


--	select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'jrodrigues@esassoc.com' and TenantID = @TenantIDTo

--	insert into dbo.FileResourceInfo(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, CreatePersonID, CreateDate, LogoFileResourceInfoIDFromTenant)
--	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), @primaryContactPersonID as CreatePersonID, fr.CreateDate, fr.FileResourceInfoID as LogoFileResourceInfoIDFromTenant
--	from dbo.Organization o
--	join dbo.FileResourceInfo fr on o.LogoFileResourceInfoID = fr.FileResourceInfoID
--	where o.OrganizationID = 1421 -- ESA Sitka

--	-- file resource data for the above file resource info
--	insert into dbo.FileResourceData(TenantID, FileResourceInfoID, [Data])
--	select @TenantIDTo as TenantID, fr.FileResourceInfoID, frd.[Data]
--	from dbo.FileResourceInfo fr
--	join dbo.FileResourceData frd on frd.FileResourceInfoID = fr.LogoFileResourceInfoIDFromTenant
--	where fr.LogoFileResourceInfoIDFromTenant is not null

--	update dbo.Organization set LogoFileResourceInfoID = (select FileResourceInfoID from FileResourceInfo fr where fr.TenantID = @TenantIDTo and fr.LogoFileResourceInfoIDFromTenant is not null) where TenantID = @TenantIDTo and OrganizationName = 'ESA Sitka'
	
--	insert into dbo.OrganizationRelationshipType(TenantID, OrganizationRelationshipTypeName, CanStewardProjects, IsPrimaryContact, IsOrganizationRelationshipTypeRequired, ShowOnFactSheet, ReportInAccomplishmentsDashboard)
--	values
--	(@TenantIDTo, 'Lead Implementer', 0, 1, 1, 1, 0),
--	(@TenantIDTo, 'Funder', 0, 0, 0, 1, 0),
--	(@TenantIDTo, 'Partner', 0, 0, 0, 1, 0)

--	insert into dbo.OrganizationTypeOrganizationRelationshipType(OrganizationTypeID, OrganizationRelationshipTypeID, TenantID)
--	select OrganizationTypeID, OrganizationRelationshipTypeID, @TenantIDTo as TenantID
--	from dbo.OrganizationType ot
--	cross join dbo.OrganizationRelationshipType rt
--	where ot.TenantID = @TenantIDTo and rt.TenantID = @TenantIDTo

--	update dbo.TenantAttribute
--	set PrimaryContactPersonID = @primaryContactPersonID
--	where TenantID = @TenantIDTo


--	insert into dbo.OrganizationRelationshipType(TenantID, OrganizationRelationshipTypeName, CanStewardProjects, IsPrimaryContact, IsOrganizationRelationshipTypeRequired, OrganizationRelationshipTypeDescription)
--	select @TenantIDTo as TenantID, rt.OrganizationRelationshipTypeName, rt.CanStewardProjects, rt.IsPrimaryContact, rt.IsOrganizationRelationshipTypeRequired, rt.OrganizationRelationshipTypeDescription
--	from dbo.OrganizationRelationshipType rt
--	left join dbo.OrganizationRelationshipType rt2 on rt.OrganizationRelationshipTypeName = rt2.OrganizationRelationshipTypeName
--	where rt.TenantID = @TenantIDFrom and rt2.OrganizationRelationshipTypeID is null

--		insert into dbo.ProjectUpdateSetting (TenantID, ProjectUpdateKickOffDate, ProjectUpdateCloseOutDate, ProjectUpdateReminderInterval, EnableProjectUpdateReminders, SendPeriodicReminders, SendCloseOutNotification, ProjectUpdateKickOffIntroContent, ProjectUpdateReminderIntroContent, ProjectUpdateCloseOutIntroContent, DaysBeforeCloseOutDateForReminder)
--    select @TenantIDTo, ProjectUpdateKickOffDate, ProjectUpdateCloseOutDate, ProjectUpdateReminderInterval, EnableProjectUpdateReminders, SendPeriodicReminders, SendCloseOutNotification, ProjectUpdateKickOffIntroContent, ProjectUpdateReminderIntroContent, ProjectUpdateCloseOutIntroContent, DaysBeforeCloseOutDateForReminder from dbo.ProjectUpdateSetting where TenantID = @TenantIDFrom


--	insert into dbo.ProjectCustomGridConfiguration(TenantID, ProjectCustomGridTypeID, ProjectCustomGridColumnID, ProjectCustomAttributeTypeID, GeospatialAreaTypeID, IsEnabled, SortOrder, ClassificationSystemID)
--	select @TenantIDTo as TenantID, pcgc.ProjectCustomGridTypeID, pcgc.ProjectCustomGridColumnID, pcgc.ProjectCustomAttributeTypeID, pcgc.GeospatialAreaTypeID, pcgc.IsEnabled, pcgc.SortOrder, pcgc.ClassificationSystemID
--	from dbo.ProjectCustomGridConfiguration pcgc
--	where pcgc.TenantID = @TenantIDFrom and ProjectCustomAttributeTypeID is null and GeospatialAreaTypeID is null and ClassificationSystemID is null


--	alter table dbo.FileResourceInfo DROP COLUMN LogoFileResourceInfoIDFromTenant
--	alter table dbo.FileResourceInfo DROP COLUMN ProjectImageIDFromTenant


--	update  dbo.FirmaPage set FirmaPageContent =
--	'<table style="border-collapse: collapse; width: 100%; border-width: 0px; border-style: hidden; margin-left: auto; margin-right: auto;" border="1"><colgroup><col style="width: 99.8801%;"></colgroup>
--<tbody>
--<tr>
--<td style="text-align: center; border-width: 0px;"><img title="under-construction.png" src="data:image/png;base64,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" alt="under-construction" width="286" height="250"></td>
--</tr>
--</tbody>
--</table>
--<p>&nbsp;</p>
--<p>Exciting News! The Tahoe-Central Sierra Project Tracker is currently under construction and is anticipated to be up and running by Summer 2024. Currently, the tracker will focus on projects related to forest resilience but hopes to expand to the other nine Pillars of Resilience! Stay tuned for a transformative tool that will enhance project visibility and collaboration in the region! If you would like more information on TCSI, please visit our website at&nbsp;<a class="css-tgpl01" title="https://linkprotect.cudasvc.com/url?a=https%3a%2f%2fwww.tahoecentralsierra.org%2fabout%2f&amp;c=E,1,1Jt5NErWOFZfUf5x5BM7T-H5BzTB-IYr6Z2VHL0nwrUuLD67ixXObpOfnGa_JdcAu5pIMhfXKsNNj3mkWmdksCDWH92_waCJLCK_t93uSrJNd7b1rA,,&amp;typo=1" href="https://linkprotect.cudasvc.com/url?a=https%3a%2f%2fwww.tahoecentralsierra.org%2fabout%2f&amp;c=E,1,1Jt5NErWOFZfUf5x5BM7T-H5BzTB-IYr6Z2VHL0nwrUuLD67ixXObpOfnGa_JdcAu5pIMhfXKsNNj3mkWmdksCDWH92_waCJLCK_t93uSrJNd7b1rA,,&amp;typo=1" data-testid="link-with-safety" data-renderer-mark="true">https://www.tahoecentralsierra.org/about/</a></p>'
-- where TenantID = @TenantIDTo and FirmaPageTypeID = 1