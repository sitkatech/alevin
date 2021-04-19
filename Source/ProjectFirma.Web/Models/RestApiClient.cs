﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class SyncResult
    {
        public string Message { get; }
        public bool IsError { get; }
        public bool IsWarning { get; }

        public SyncResult(string message, bool isError, bool isWarning)
        {
            Message = message;
            IsError = isError;
            IsWarning = isWarning;
        }
    }
    public class RestApiClient
    {
        public static SyncResult SyncGeospatialAreaTypeFromService(GeospatialAreaType geospatialAreaType)
        {
            SitkaHttpApplication.Logger.Info($"Syncing data for Geospatial Area Type {geospatialAreaType.GeospatialAreaTypeName} from {geospatialAreaType.ServiceUrl}");
            string statusMessage;
            try
            {
                var responseData = MakeApiRequest("Geospatial Area Type", geospatialAreaType.ServiceUrl);
                var lastSucessfulResponse = HttpRequestStorage.DatabaseEntities.GeospatialAreaRawDatas.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);

                var optionalSkippedDeletionWarning = GeospatialAreaTypeModelExtensions.ProcessApiResponse(geospatialAreaType, responseData, HttpRequestStorage.DatabaseEntities, SitkaWebConfiguration.DatabaseConnectionString);
                // Record this response as the latest response for next time
                if (lastSucessfulResponse == null)
                {
                    lastSucessfulResponse = new GeospatialAreaRawData(geospatialAreaType.GeospatialAreaTypeID);
                    HttpRequestStorage.DatabaseEntities.AllGeospatialAreaRawDatas.Add(lastSucessfulResponse);
                }
                lastSucessfulResponse.ResultJson = responseData;

                if (optionalSkippedDeletionWarning != null)
                {
                    return new SyncResult(optionalSkippedDeletionWarning, false, true);
                }
                statusMessage = $"Geospatial area sync for {geospatialAreaType.GeospatialAreaTypeName} successful";
                return new SyncResult(statusMessage, false, false);

            }
            catch (Exception e)
            {
                statusMessage = $"Geospatial area sync for {geospatialAreaType.GeospatialAreaTypeName} failed";
                SitkaLogger.Instance.LogDetailedErrorMessage(statusMessage + " with an exception", e);
                return new SyncResult(statusMessage, true, false);
            }
        }

        public static string MakeApiRequest(string serviceName, string serviceUrl)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            Check.Assert(webResponse.StatusCode == HttpStatusCode.OK,
                $"Request to {serviceName} Data Source {serviceUrl} should resolve 200.");
            var responseStream = webResponse.GetResponseStream();
            Check.RequireNotNull(responseStream, $"{serviceName} - Response stream cannot be null");
            // ReSharper disable once AssignNullToNotNullAttribute
            var responseReader = new StreamReader(responseStream);
            return responseReader.ReadToEnd();
        }
    }
}
