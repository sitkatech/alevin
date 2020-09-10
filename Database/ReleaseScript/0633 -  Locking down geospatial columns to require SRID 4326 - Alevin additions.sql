
-- Lock all the tables down so they MUST be 4326.
ALTER TABLE dbo.NpccProvince
WITH CHECK ADD  CONSTRAINT [CK_NpccProvince_NpccProvinceFeature_SpatialReferenceID_Must_Be_4326] 
CHECK  (NpccProvinceFeature  is null or NpccProvinceFeature .STSrid = 4326)
GO
