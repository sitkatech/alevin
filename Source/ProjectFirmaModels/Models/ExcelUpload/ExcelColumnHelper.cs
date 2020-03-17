using System;
using System.Collections.Generic;
using System.Data;

namespace ProjectFirmaModels.Models.ExcelUpload
{
    public static class ExcelColumnHelper
    {

        public static string GetStringDataValueForColumnName(DataRow dr, int rowIndex, Dictionary<string, string> columnNameToLetterDict, string humanReadableNameOfColumn)
        {
            string columnKeyLetterName = columnNameToLetterDict[humanReadableNameOfColumn];

            string dataValue;
            try
            {
                dataValue = string.IsNullOrWhiteSpace(dr[columnKeyLetterName].ToString())
                    ? null
                    : dr[columnKeyLetterName].ToString();
            }
            catch (Exception e)
            {
                throw new ExcelImportBadCellException(columnKeyLetterName, rowIndex,
                    dr[columnKeyLetterName].ToString(),
                    $"Problem parsing Source {humanReadableNameOfColumn}", e);
            }

            return dataValue;
        }

        public static double? GetDoubleDataValueForColumnName(DataRow dr, int rowIndex, Dictionary<string, string> columnNameToLetterDict, string humanReadableNameOfColumn)
        {
            string columnKeyLetterName = columnNameToLetterDict[humanReadableNameOfColumn];
            double? returnValue = null;
            try
            {
                if (double.TryParse(dr[columnKeyLetterName].ToString(), out double dataValueAsDouble))
                {
                    returnValue = dataValueAsDouble;
                }

            }
            catch (Exception e)
            {
                throw new ExcelImportBadCellException(columnKeyLetterName, rowIndex, dr[columnKeyLetterName].ToString(), $"Problem parsing {humanReadableNameOfColumn}", e);
            }

            return returnValue;
        }

        public static DateTime? GetDateTimeDataValueForColumnName(DataRow dr, int rowIndex, Dictionary<string, string> columnNameToLetterDict, string humanReadableNameOfColumn)
        {
            string columnKeyLetterName = columnNameToLetterDict[humanReadableNameOfColumn];
            DateTime? returnValue = null;
            try
            {
                if (DateTime.TryParse(dr[columnKeyLetterName].ToString(), out DateTime dataValueAsDateTime))
                {
                    returnValue = dataValueAsDateTime;
                }

            }
            catch (Exception e)
            {
                throw new ExcelImportBadCellException(columnKeyLetterName, rowIndex, dr[columnKeyLetterName].ToString(), $"Problem parsing {humanReadableNameOfColumn}", e);
            }

            return returnValue;
        }
    }
}