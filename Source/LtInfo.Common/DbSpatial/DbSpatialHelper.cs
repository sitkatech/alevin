﻿/*-----------------------------------------------------------------------
<copyright file="DbSpatialHelper.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using Microsoft.SqlServer.Types;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using System.Linq;

namespace LtInfo.Common.DbSpatial
{
    public static class DbSpatialHelper
    {
        private const double MetersPerFoot = 0.3048;

        public static double FeetToAverageLatLonDegree(DbGeometry geometry, double feet)
        {            
            return 2 / ((1 / FeetToLonDegree(geometry, feet)) + (1 / FeetToLatDegree(geometry, feet))); //Harmonic mean
        }

        public static double FeetToLatDegree(DbGeometry geometry, double feet)
        {
            var longitude = GetRepresentativeXCoordinate(geometry);
            var latitude = GetRepresentativeYCoordinate(geometry);
            var coordinateSystemId = geometry.CoordinateSystemId == 0 ? LtInfoGeometryConfiguration.DefaultCoordinateSystemId : geometry.CoordinateSystemId;

            var geography = MakeDbGeographyFromLatLon(longitude, latitude - 0.5, coordinateSystemId);

            var dbGeographyOneDegreeLatitude = MakeDbGeographyFromLatLon(longitude, latitude + 0.5, coordinateSystemId);
            var degreesLatitudePerMeter =
                geography.Distance(dbGeographyOneDegreeLatitude).Value;

            return (feet * MetersPerFoot) / degreesLatitudePerMeter;
        }

        public static double FeetToLonDegree(DbGeometry geometry, double feet)
        {
            var longitude = GetRepresentativeXCoordinate(geometry);
            var latitude = GetRepresentativeYCoordinate(geometry);
            var coordinateSystemId = geometry.CoordinateSystemId == 0 ? LtInfoGeometryConfiguration.DefaultCoordinateSystemId : geometry.CoordinateSystemId;

            var geography = MakeDbGeographyFromLatLon(longitude - 0.5, latitude, coordinateSystemId);

            var dbGeographyOneDegreeLongitude = MakeDbGeographyFromLatLon(longitude + 0.5, latitude, coordinateSystemId);
            var degreesLongitudePerMeter =
                geography.Distance(dbGeographyOneDegreeLongitude).Value;

            return (feet * MetersPerFoot) / degreesLongitudePerMeter;
        }

        private static double GetRepresentativeYCoordinate(DbGeometry geometry)
        {
            return geometry.Centroid?.YCoordinate ?? geometry.YCoordinate ?? geometry.Envelope.Centroid.YCoordinate.Value;
        }

        private static double GetRepresentativeXCoordinate(DbGeometry geometry)
        {
            return geometry.Centroid?.XCoordinate ?? geometry.XCoordinate ?? geometry.Envelope.Centroid.XCoordinate.Value;
        }

        public static DbGeometry MakeDbGeometryFromCoordinates(double xCoordinate, double yCoordinate, int coordinateSystemId)
        {
            var geometry = DbGeometry.PointFromText($"POINT({xCoordinate} {yCoordinate})", coordinateSystemId);
            return geometry;
        }

        public static DbGeography MakeDbGeographyFromLatLon(double longitude, double latitude, int coordinateSystemId)
        {
            var geography = DbGeography.PointFromText($"POINT({longitude} {latitude})",
                coordinateSystemId);
            return geography;
        }

        public static DbGeography GeographyFromGeometry(DbGeometry ogrGeometry)
        {
            // Not enforcing 4326 here, but am explicitly passing through relevant starting CoordinateSystemId.
            return DbGeography.FromBinary(ogrGeometry.AsBinary(), ogrGeometry.CoordinateSystemId);
        }

        public static DbGeometry ToDbGeometry(this SqlGeometry sqlGeometry, int coordinateSystemIDToUse)
        {
            return DbGeometry.FromBinary(sqlGeometry.STAsBinary().Buffer, coordinateSystemIDToUse);
        }

        public static SqlGeometry ToSqlGeometry(this DbGeometry dbGeometry)
        {
            // Not enforcing 4326 here, but am explicitly passing through relevant starting CoordinateSystemId.
            return SqlGeometry.STGeomFromWKB(new SqlBytes(dbGeometry.AsBinary()), dbGeometry.CoordinateSystemId);
        }

        public static void Reduce(List<IHaveSqlGeometry> iHaveSqlGeometries)
        {
            const int thresholdInFeet = 1;
            var thresholdInDegrees = FeetToAverageLatLonDegree(iHaveSqlGeometries.First().GetDbGeometry(), thresholdInFeet);
            iHaveSqlGeometries.ForEach(x =>
            {
                // SqlGeometries are in a "Euclidean (flat) coordinate system", so forcing our resulting DbGeometry to 4326 (LtInfoGeometryConfiguration.DefaultCoordinateSystemId)
                // should be entirely appropriate. -- SLG 9/22/2020
                SqlGeometry validSqlGeometry = x.GetSqlGeometry().MakeValid().Reduce(thresholdInDegrees);
                DbGeometry newValidDbGeometry = validSqlGeometry.ToDbGeometry(LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                x.SetDbGeometry(newValidDbGeometry);
            });
        }

        /// <summary>
        /// As part of the GIS upload workflow we eventually Reduce the geometries, but this only happens after the import has been completed.
        /// In some scenarios, you can provide invalid geometries that make it past the upload step only to fail due to not being able
        /// to reduce them later in the workflow. At that point in the workflow we don't have access to the HttpPostedFileBase anymore to be able
        /// to save it off an investigate later. I'm certain that try-catching this isn't the most efficient way to test if the upload
        /// will be reducible in further steps, but for now it will let us prevent users from successfully getting to a step that they will
        /// be doomed to fail. -- 1/28/2021 SMG [PF-1219]
        /// </summary>
        /// <param name="geometries"></param>
        /// <returns></returns>
        public static bool CanReduce(List<SqlGeometry> geometries)
        {
            try
            {
                const int thresholdInFeet = 1;
                var thresholdInDegrees = FeetToAverageLatLonDegree(
                    geometries.First().ToDbGeometry(LtInfoGeometryConfiguration.DefaultCoordinateSystemId),
                    thresholdInFeet);
                geometries.ForEach(x =>
                {
                    SqlGeometry validSqlGeometry = x.MakeValid().Reduce(thresholdInDegrees);
                    validSqlGeometry.ToDbGeometry(LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                });
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
