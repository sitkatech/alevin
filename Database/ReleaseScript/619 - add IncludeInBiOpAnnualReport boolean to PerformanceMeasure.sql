alter table dbo.PerformanceMeasure
add IncludeInBiOpAnnualReport bit null

go


update dbo.PerformanceMeasure
set IncludeInBiOpAnnualReport = 1 where PerformanceMeasureID in (3473,3479,3480,3484,3515);
go

update dbo.PerformanceMeasure
set IncludeInBiOpAnnualReport = 0 where PerformanceMeasureID not in (3473,3479,3480,3484,3515);
go




alter table dbo.PerformanceMeasure
alter column IncludeInBiOpAnnualReport bit not null
go