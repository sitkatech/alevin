-- These are now causing crashes after a merge from develop, just commenting out for now.

--exec sp_rename 'FK_ProjectContact_PersonID_ContactID_PersonID', 'FK_ProjectContact_Person_ContactID_PersonID', 'OBJECT'
--exec sp_rename 'FK_ProjectContact_Person_ContactID_PersonID_TenantID', 'FK_ProjectContact_Person_ContactID_TenantID_PersonID_TenantID', 'OBJECT'
--exec sp_rename 'FK_ProjectContactUpdate_Person_ContactID_PersonID_TenantID', 'FK_ProjectContactUpdate_Person_ContactID_TenantID_PersonID_TenantID', 'OBJECT'

