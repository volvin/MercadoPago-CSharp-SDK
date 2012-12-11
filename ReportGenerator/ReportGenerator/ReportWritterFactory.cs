using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    public enum ReportTypes
    { 
        CollectionsReport,
        MovementsReport
    }

    public enum ReportFormats
    { 
        CSVReport,
        ExcelReport
    }

    public class ReportWritterFactory
    {
        public static ReportWritter GetReportWritter(System.IO.StreamWriter file, ReportFormats reportFormat = ReportFormats.ExcelReport)
        {
            ReportWritter reportWritter;
            if (reportFormat == ReportFormats.ExcelReport)
            {
                reportWritter = new ExcelWritter(file);
            }
            else
            {
                reportWritter = new CSVWritter(file);            
            }
            return reportWritter;
        }
    }
}
