--BEGIN tran
DELETE from dbo.Project
WHERE ProjectName in (
'Grande Ronde General Proposed BPA Atlas',
'Imnaha General Subbasin Service Contracts',
'Lemhi General Canyon McFarland PHABSIM',
'MFJD Phipps Meadow',
'N F J D General Subbasin Serv Cont',
'N F J D General Technical Site Visit',
'Upper Salmon General YF Technical Site Visit',
'Wenatchee Geo Proposed Peshastin BRG Side Chnl',
'x Coordination and Admin - Col/Snk R',
'x Habitat Program - Col/Snk River FCRPS',
'x Hatchery Actions - Col/Snk River FCRPS',
'x Hydro Mgmt & Implementation - Col/Snk FCRPS',
'x Research, Monitoring & Evaluation - Col/Snk FCRP'
)

-- Left column ("field1" in the reference spreadsheet) deletes
DELETE from dbo.Project
WHERE ProjectName in (
'General Habitat Colville Water Acq Proposed Proj',
'Methow General Technical Assistance USGS Proposed',
'R M E John Day Basin Pilot Detailed Needs Asment'
)

-- This one needs a little extra elbow grease.
delete from Reclamation.CostAuthorityProject
where ProjectID = (select ProjectID from dbo.Project where ProjectName = '3248 READY TO USE')

delete from dbo.Project
where ProjectName = '3248 READY TO USE'


--rollback tran

--ROLLBACK tran