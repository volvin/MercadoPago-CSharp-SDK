/*
 * Copyright 2012 MercadoLibre, Inc.
 *
 * Changed to retrieve a well-formed json string running .ToString() method.
 * Allows to serialize scalar data at CreateFromString method.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

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
    /// <summary>
    /// A representation of the Report Writter Factory resource. 
    /// </summary>
    public class ReportWritterFactory
    {
        /// <summary>
        /// Selects a Report Writter.
        /// </summary>
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
