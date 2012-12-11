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

                reportLine += EncodeString(collection.DateCreated.ToString()) + ",";
                reportLine += EncodeString(collection.Id.ToString()) + ",";
                reportLine += EncodeString(collection.ExternalReference) + ",";
                reportLine += EncodeString(collection.Status) + ",";
                reportLine += EncodeString(collection.StatusDetail) + ",";
                reportLine += EncodeString(collection.OperationType) + ",";
                reportLine += EncodeString(collection.PaymentType) + ",";
                reportLine += EncodeString(collection.LastModified.ToString()) + ",";
                reportLine += EncodeString(collection.Reason) + ",";
                reportLine += EncodeString(collection.TransactionAmount.ToString().Replace(",", ".")) + ",";
                reportLine += EncodeString(collection.ShippingCost.ToString().Replace(",", ".")) + ",";
                reportLine += EncodeString(collection.TotalPaidAmount.ToString().Replace(",", ".")) + ",";
                reportLine += EncodeString(collection.Payer.Nickname) + ",";
                reportLine += EncodeString(collection.Payer.Email);

                _file.WriteLine(reportLine);
                try
                {
                    if (_progressBar != null)
                    {
                        _progressBar.Value += 1;
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

                reportLine += movement.DateCreated.ToString() + ",";
                reportLine += movement.Detail + ",";
                reportLine += movement.Amount.ToString().Replace(",", ".") + ",";
                reportLine += movement.BalancedAmount.ToString().Replace(",", ".");

                _file.WriteLine(reportLine);
                try
                {
                    if (_progressBar != null)
                    {
                        _progressBar.Value += 1;
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
            // Do nothing
        }

        private string EncodeString(string text)
        {
            string result = "";
            if (text != null)
            {
                result = text.Replace(",", "#");
            }
            else
            {
                result = "";
            }
            return result;
        }
    }
}
