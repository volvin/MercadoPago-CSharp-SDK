using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPagoSDK;
using System.Windows.Forms;

namespace ReportGenerator
{
    public class CSVWritter : ReportWritter
    {
        public CSVWritter()
        { }

        public CSVWritter(System.IO.StreamWriter file)
        {
            _file = file;
        }

        public override void WriteCollections(List<Collection> collections)
        {
            foreach (Collection collection in collections)
            {
                string reportLine = "";

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

                _file.WriteLine(reportLine);
                try
                {
                    if (_progressBar != null)
                    {
                        _progressBar.Invoke(new IncreaseProgressBarValueCallback(this.IncreaseProgressBarValue), null);
                        _progressBar.Invoke(new UpdateProgressTextValueCallback(this.UpdateProgressTextValue), new object[] { _progressBar.Value.ToString() + " of " + _progressBar.Maximum.ToString() });
                    }
                }
                catch
                {
                }
            }
        }

        public override void WriteMovements(List<Movement> movements)
        {
            foreach (Movement movement in movements)
            {
                string reportLine = "";

                reportLine += EncodeString(movement.DateCreated) + ",";
                reportLine += EncodeString(movement.Detail) + ",";
                reportLine += EncodeString(movement.Id) + ",";
                reportLine += EncodeString(movement.ReferenceId) + ",";
                reportLine += EncodeString(movement.Amount) + ",";
                reportLine += EncodeString(movement.BalancedAmount);

                _file.WriteLine(reportLine);
                try
                {
                    if (_progressBar != null)
                    {
                        _progressBar.Invoke(new IncreaseProgressBarValueCallback(this.IncreaseProgressBarValue), null);
                        _progressBar.Invoke(new UpdateProgressTextValueCallback(this.UpdateProgressTextValue), new object[] { _progressBar.Value.ToString() + " of " + _progressBar.Maximum.ToString() });
                    }
                }
                catch
                {
                }
            }
        }

        public override void WriteFooter()
        { 
            // Do nothing
        }

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
    }
}
