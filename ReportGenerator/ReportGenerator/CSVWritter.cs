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
using MercadoPagoSDK;
using System.Windows.Forms;

namespace ReportGenerator
{
    /// <summary>
    /// A representation of the CSV Writter resource. 
    /// </summary>
    public class CSVWritter : ReportWritter
    {
        /// <summary>
        /// Create a new CSV Writter instance.
        /// </summary>
        public CSVWritter()
        { }

        /// <summary>
        /// Create a new CSV Writter instance.
        /// </summary>
        /// <param name="file">The destination file
        /// </param>
        public CSVWritter(System.IO.StreamWriter file)
        {
            _file = file;
        }

        /// <summary>
        /// Writes a collections set to file.
        /// </summary>
        public override void WriteCollections(List<Collection> collections)
        {
            foreach (Collection collection in collections)
            {
                string reportLine = "";

                // Prepare line
                reportLine += EncodeString(collection.DateCreated) + ",";
                reportLine += EncodeString(collection.LastModified) + ",";
                reportLine += EncodeString(collection.OperationType) + ",";
                reportLine += EncodeString(collection.Payer.Email) + ",";
                reportLine += EncodeString(collection.Payer.Nickname) + ",";
                reportLine += EncodeString(collection.Payer.FirstName) + " " + EncodeString(collection.Payer.LastName) + ",";
                reportLine += EncodeString(collection.Reason) + ",";
                reportLine += EncodeString(collection.TotalPaidAmount) + ",";
                reportLine += EncodeString(collection.ShippingCost) + ",";
                reportLine += EncodeString(collection.TransactionAmount) + ",";
                reportLine += EncodeString(collection.MercadoPagoFee) + ",";
                reportLine += EncodeString(collection.Status) + ",";
                reportLine += EncodeString(collection.StatusDetail) + ",";
                reportLine += EncodeString(collection.Id) + ",";
                reportLine += EncodeString(collection.ExternalReference) + ",";
                reportLine += EncodeString(collection.MoneyReleaseDate) + ",";
                reportLine += EncodeString(collection.PaymentType);

                // Write report line
                _file.WriteLine(reportLine);

                // Update progress bar & text 
                if (_progressBar != null)
                {
                    _progressBar.Invoke(new IncreaseProgressBarValueCallback(this.IncreaseProgressBarValue), null);
                    _progressBar.Invoke(new UpdateProgressTextValueCallback(this.UpdateProgressTextValue), new object[] { _progressBar.Value.ToString() + " of " + _progressBar.Maximum.ToString() });
                }
            }
        }

        /// <summary>
        /// Writes the file footer.
        /// </summary>
        public override void WriteFooter()
        {
            // Do nothing
        }

        /// <summary>
        /// Writes the file header.
        /// </summary>
        public override void WriteHeader(ReportTypes reportType, int numberOfRows = 0)
        {
            if (reportType == ReportTypes.CollectionsReport)
            {
                _file.WriteLine(GetCollectionReportHeader());
            }
            else
            {
                _file.WriteLine(GetMovementReportHeader());
            }
        }

        /// <summary>
        /// Writes a movements set to file.
        /// </summary>
        public override void WriteMovements(List<Movement> movements)
        {
            foreach (Movement movement in movements)
            {
                string reportLine = "";

                // Prepare line
                reportLine += EncodeString(movement.DateCreated) + ",";
                reportLine += EncodeString(movement.Detail) + ",";
                reportLine += EncodeString(movement.Id) + ",";
                reportLine += EncodeString(movement.ReferenceId) + ",";
                reportLine += EncodeString(movement.Amount) + ",";
                reportLine += EncodeString(movement.BalancedAmount);

                // Write report line
                _file.WriteLine(reportLine);

                // Update progress bar & text 
                if (_progressBar != null)
                {
                    _progressBar.Invoke(new IncreaseProgressBarValueCallback(this.IncreaseProgressBarValue), null);
                    _progressBar.Invoke(new UpdateProgressTextValueCallback(this.UpdateProgressTextValue), new object[] { _progressBar.Value.ToString() + " of " + _progressBar.Maximum.ToString() });
                }
            }
        }

        #region "Private Members"

        /// <summary>
        /// Encodes a CSV string.
        /// </summary>
        private string EncodeString(String text)
        {
            if (text != null)
            {
                return text.Replace(",", "#");
            }
            else
            {
                return String.Empty;
            }
        }

        private string EncodeString(DateTime? date)
        {
            if (date != null)
            {
                return date.ToString().Replace(",", "#");
            }
            else
            {
                return String.Empty;
            }
        }

        private string EncodeString(Int32? number)
        {
            if (number != null)
            {
                return number.ToString().Replace(",", ".");
            }
            else
            {
                return String.Empty;
            }
        }

        private string EncodeString(float? number)
        {
            if (number != null)
            {
                return number.ToString().Replace(",", ".");
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Sets a collections report header.
        /// </summary>
        private string GetCollectionReportHeader()
        {
            string fileHeader = "";
            fileHeader += "Date,";
            fileHeader += "Last Modified Date,";
            fileHeader += "Operation Type,";
            fileHeader += "Buyer Email,";
            fileHeader += "Buyer Nickname,";
            fileHeader += "Buyer Name,";
            fileHeader += "Description,";
            fileHeader += "Total Paid Amount,";
            fileHeader += "Shipping Cost,";
            fileHeader += "Transaction Amount,";
            fileHeader += "MercadoPago Fee,";
            fileHeader += "Status,";
            fileHeader += "Status Detail,";
            fileHeader += "Payment Id,";
            fileHeader += "External Reference,";
            fileHeader += "Money Release Date,";
            fileHeader += "Payment Type";

            return fileHeader;
        }

        /// <summary>
        /// Sets a movements report header.
        /// </summary>
        private string GetMovementReportHeader()
        {
            string fileHeader = "";
            fileHeader += "Date,";
            fileHeader += "Detail,";
            fileHeader += "Movement Id,";
            fileHeader += "Reference Id,";
            fileHeader += "Amount,";
            fileHeader += "Balanced Amount";

            return fileHeader;
        }

        #endregion
    }
}
