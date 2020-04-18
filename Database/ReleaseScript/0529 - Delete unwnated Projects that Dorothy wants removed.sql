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

--ROLLBACK tran