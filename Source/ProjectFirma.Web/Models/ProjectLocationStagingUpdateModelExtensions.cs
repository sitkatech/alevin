﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.GdalOgr;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectLocationStagingUpdateModelExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gdbFile"></param>
        /// <param name="originalFilename">This is the original name of the file as it appeared on the users file system. It is provided just for error messaging purposes.</param>
        /// <param name="projectUpdateBatch"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public static List<ProjectLocationStagingUpdate> CreateProjectLocationStagingUpdateListFromGdb(FileInfo gdbFile, string originalFilename, ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gdbFile, originalFilename,Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStagingUpdate(projectUpdateBatch, currentPerson, x, ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gdbFile, x, true), true)).ToList();
            return projectLocationStagings;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gdbFile"></param>
        /// <param name="originalFilename">This is the original name of the file as it appeared on the users file system. It is provided just for error messaging purposes.</param>
        /// <param name="projectUpdateBatch"></param>
        /// <param name="currentPerson"></param>
        /// <returns></returns>
        public static List<ProjectLocationStagingUpdate> CreateProjectLocationStagingUpdateListFromKml(FileInfo kmlFile, string originalFilename, ProjectUpdateBatch projectUpdateBatch, Person currentPerson)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileKml(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), kmlFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStagingUpdate(projectUpdateBatch, currentPerson, "", ogr2OgrCommandLineRunner.ImportFileKmlToGeoJson(kmlFile, true), true)).ToList();
            return projectLocationStagings;
        }

        public static List<ProjectLocationStagingUpdate> CreateProjectLocationStagingUpdateListFromKmz(FileInfo disposableTempFileFileInfo, string fileName, ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var featureClassNames = OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileKmz(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), disposableTempFileFileInfo, fileName, Ogr2OgrCommandLineRunner.DefaultTimeOut);

            var projectLocationStagings =
                featureClassNames.Select(x => new ProjectLocationStagingUpdate(projectUpdateBatch, currentFirmaSession.Person, "", ogr2OgrCommandLineRunner.ImportFileKmzToGeoJson(disposableTempFileFileInfo, true), true)).ToList();
            return projectLocationStagings;
        }
    }
}