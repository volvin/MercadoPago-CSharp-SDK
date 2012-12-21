using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MercadoPagoSDK;

namespace ReportGenerator
{
    public class ExcelWritter : ReportWritter
    {
        private const int API_QUERY_PAGE_SIZE = 50;
        private const int MAX_REPORT_SIZE = 60000;

        public ExcelWritter()
        { }

        public ExcelWritter(System.IO.StreamWriter file)
        {
            _file = file;
        }

        public override void WriteCollections(List<Collection> collections)
        {
            foreach (Collection collection in collections)
            {
                string reportLine = "";

                reportLine += "<Row ss:AutoFitHeight=\"0\">";
                reportLine += "    <Cell ss:Index=\"2\" ss:StyleID=\"s67\"><Data ss:Type=\"String\">" + StringOrNull(collection.DateCreated) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s67\"><Data ss:Type=\"String\">" + StringOrNull(collection.LastModified) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"String\">" + StringOrNull(collection.OperationType) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s79\"><Data ss:Type=\"String\">" + StringOrNull(collection.Payer.Email) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s75\"><Data ss:Type=\"String\">" + StringOrNull(collection.Payer.Nickname) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s75\"><Data ss:Type=\"String\">" + StringOrNull(collection.Payer.FirstName) + " " + StringOrNull(collection.Payer.LastName)  + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s75\"><Data ss:Type=\"String\">" + StringOrNull(collection.Reason) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(collection.TotalPaidAmount) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(collection.ShippingCost) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(collection.TransactionAmount) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(collection.MercadoPagoFee) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"String\">" + StringOrNull(collection.Status) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"String\">" + StringOrNull(collection.StatusDetail) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s68\"><Data ss:Type=\"Number\">" + StringOrNull(collection.Id) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"Default\"><Data ss:Type=\"String\">" + StringOrNull(collection.ExternalReference) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s67\"><Data ss:Type=\"String\">" + StringOrNull(collection.MoneyReleaseDate) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"String\">" + StringOrNull(collection.PaymentType) + "</Data></Cell>";
                reportLine += "</Row>";

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
                reportLine += "<Row ss:AutoFitHeight=\"0\">";
                reportLine += "    <Cell ss:Index=\"2\" ss:StyleID=\"s65\"><Data ss:Type=\"String\">" + StringOrNull(movement.DateCreated) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"String\">" + StringOrNull(movement.Detail) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s69\"><Data ss:Type=\"String\">" + StringOrNull(movement.Id) + "</Data></Cell>";
                reportLine += "    <Cell ss:StyleID=\"s69\"><Data ss:Type=\"String\">" + StringOrNull(movement.ReferenceId) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(movement.Amount) + "</Data></Cell>";
                reportLine += "    <Cell><Data ss:Type=\"Number\">" + StringOrNull(movement.BalancedAmount) + "</Data></Cell>";
                reportLine += "</Row>";

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
            _file.WriteLine(GetReportFooter());
        }

        public override void WriteHeader(ReportTypes reportType, int numberOfRows = 0)
        {
            if (reportType == ReportTypes.CollectionsReport)
            {
                _file.WriteLine(GetCollectionReportHeader(numberOfRows));
            }
            else
            {
                _file.WriteLine(GetMovementReportHeader(numberOfRows));            
            }
        }

        private string GetCollectionReportHeader(int rowCount)
        {
            string fileHeader = "";
            fileHeader += "<?xml version=\"1.0\"?>";
            fileHeader += "<?mso-application progid=\"Excel.Sheet\"?>";
            fileHeader += "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"";
            fileHeader += " xmlns:o=\"urn:schemas-microsoft-com:office:office\"";
            fileHeader += " xmlns:x=\"urn:schemas-microsoft-com:office:excel\"";
            fileHeader += " xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"";
            fileHeader += " xmlns:html=\"http://www.w3.org/TR/REC-html40\">";
            fileHeader += "<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">";
            fileHeader += "  <Author>MercadoPago</Author>";
            fileHeader += "  <LastAuthor>MercadoPago</LastAuthor>";
            fileHeader += "  <Version>1.00</Version>";
            fileHeader += " </DocumentProperties>";
            fileHeader += " <OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\">";
            fileHeader += "  <AllowPNG/>";
            fileHeader += " </OfficeDocumentSettings>";
            fileHeader += " <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">";
            fileHeader += "  <WindowHeight>7995</WindowHeight>";
            fileHeader += "  <WindowWidth>20115</WindowWidth>";
            fileHeader += "  <WindowTopX>240</WindowTopX>";
            fileHeader += "  <WindowTopY>75</WindowTopY>";
            fileHeader += "  <ProtectStructure>False</ProtectStructure>";
            fileHeader += "  <ProtectWindows>False</ProtectWindows>";
            fileHeader += " </ExcelWorkbook>";
            fileHeader += " <Styles>";
            fileHeader += "  <Style ss:ID=\"Default\" ss:Name=\"Normal\">";
            fileHeader += "   <Alignment ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Borders/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>";
            fileHeader += "   <Interior/>";
            fileHeader += "   <NumberFormat/>";
            fileHeader += "   <Protection/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s78\" ss:Name=\"Hipervínculo\">";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#0000FF\"";
            fileHeader += "    ss:Underline=\"Single\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s62\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s63\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"Fixed\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s64\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"";
            fileHeader += "    ss:Bold=\"1\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s66\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"";
            fileHeader += "    ss:Bold=\"1\"/>";
            fileHeader += "   <Interior ss:Color=\"#C5D9F1\" ss:Pattern=\"Solid\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s67\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"General Date\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s68\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Dialog\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s70\">";
            fileHeader += "   <Alignment ss:Vertical=\"Bottom\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s73\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s75\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"General Date\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s77\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s79\" ss:Parent=\"s78\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Left\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"General Date\"/>";
            fileHeader += "  </Style>";
            fileHeader += " </Styles>";
            fileHeader += " <Worksheet ss:Name=\"Report\">";
            fileHeader += "  <Table ss:ExpandedColumnCount=\"18\" ss:ExpandedRowCount=\"" + (rowCount + 2).ToString() + "\" x:FullColumns=\"1\"";
            fileHeader += "   x:FullRows=\"1\" ss:DefaultColumnWidth=\"60\" ss:DefaultRowHeight=\"15\">";
            fileHeader += "   <Column ss:Index=\"2\" ss:StyleID=\"s62\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s62\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s70\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s73\" ss:AutoFitWidth=\"0\" ss:Width=\"213.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s73\" ss:AutoFitWidth=\"0\" ss:Width=\"213.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s73\" ss:AutoFitWidth=\"0\" ss:Width=\"213.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s73\" ss:AutoFitWidth=\"0\" ss:Width=\"213.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s63\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s63\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s63\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s63\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s70\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s70\" ss:AutoFitWidth=\"0\" ss:Width=\"213.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s77\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s62\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s62\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s70\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Row ss:AutoFitHeight=\"0\"/>";
            fileHeader += "   <Row ss:AutoFitHeight=\"0\" ss:StyleID=\"s64\">";
            fileHeader += "    <Cell ss:Index=\"2\" ss:StyleID=\"s66\"><Data ss:Type=\"String\">Date</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Last Modified Date</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Operation Type</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Buyer Email</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Buyer Nickname</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Buyer Name</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Description</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Total Paid Amount</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Shipping Cost</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Transaction Amount</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">MercadoPago Fee</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Status</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Status Detail</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Payment Id</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">External Reference</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Money Release Date</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s66\"><Data ss:Type=\"String\">Payment Type</Data></Cell>";
            fileHeader += "   </Row>";

            return fileHeader;
        }

        private string GetMovementReportHeader(int rowCount)
        {
            string fileHeader = "";
            fileHeader += "<?xml version=\"1.0\"?>";
            fileHeader += "<?mso-application progid=\"Excel.Sheet\"?>";
            fileHeader += "<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"";
            fileHeader += " xmlns:o=\"urn:schemas-microsoft-com:office:office\"";
            fileHeader += " xmlns:x=\"urn:schemas-microsoft-com:office:excel\"";
            fileHeader += " xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"";
            fileHeader += " xmlns:html=\"http://www.w3.org/TR/REC-html40\">";
            fileHeader += "<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">";
            fileHeader += "  <Author>MercadoPago</Author>";
            fileHeader += "  <LastAuthor>MercadoPago</LastAuthor>";
            fileHeader += "  <Version>1.00</Version>";
            fileHeader += " </DocumentProperties>";
            fileHeader += " <OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\">";
            fileHeader += "  <AllowPNG/>";
            fileHeader += " </OfficeDocumentSettings>";
            fileHeader += " <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">";
            fileHeader += "  <WindowHeight>7995</WindowHeight>";
            fileHeader += "  <WindowWidth>20115</WindowWidth>";
            fileHeader += "  <WindowTopX>240</WindowTopX>";
            fileHeader += "  <WindowTopY>75</WindowTopY>";
            fileHeader += "  <ProtectStructure>False</ProtectStructure>";
            fileHeader += "  <ProtectWindows>False</ProtectWindows>";
            fileHeader += " </ExcelWorkbook>";
            fileHeader += " <Styles>";
            fileHeader += "  <Style ss:ID=\"Default\" ss:Name=\"Normal\">";
            fileHeader += "   <Alignment ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Borders/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>";
            fileHeader += "   <Interior/>";
            fileHeader += "   <NumberFormat/>";
            fileHeader += "   <Protection/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s62\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"";
            fileHeader += "    ss:Bold=\"1\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s63\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"";
            fileHeader += "    ss:Bold=\"1\"/>";
            fileHeader += "   <Interior ss:Color=\"#C5D9F1\" ss:Pattern=\"Solid\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s65\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"General Date\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s66\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "  </Style>";
            fileHeader += "  <Style ss:ID=\"s69\">";
            fileHeader += "   <Alignment ss:Horizontal=\"Right\" ss:Vertical=\"Bottom\"/>";
            fileHeader += "   <Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"";
            fileHeader += "    ss:Bold=\"0\"/>";
            fileHeader += "   <NumberFormat ss:Format=\"0.00\"/>";
            fileHeader += "  </Style>";
            fileHeader += " </Styles>";
            fileHeader += " <Worksheet ss:Name=\"Report\">";
            fileHeader += "  <Table ss:ExpandedColumnCount=\"7\" ss:ExpandedRowCount=\"" + (rowCount + 2).ToString() + "\" x:FullColumns=\"1\"";
            fileHeader += "   x:FullRows=\"1\" ss:DefaultColumnWidth=\"60\" ss:DefaultRowHeight=\"15\">";
            fileHeader += "   <Column ss:Index=\"2\" ss:StyleID=\"s66\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:AutoFitWidth=\"0\" ss:Width=\"266.25\"/>";
            fileHeader += "   <Column ss:StyleID=\"s69\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s69\" ss:AutoFitWidth=\"0\" ss:Width=\"135\"/>";
            fileHeader += "   <Column ss:StyleID=\"s69\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Column ss:StyleID=\"s69\" ss:AutoFitWidth=\"0\" ss:Width=\"108.75\"/>";
            fileHeader += "   <Row ss:AutoFitHeight=\"0\"/>";
            fileHeader += "   <Row ss:AutoFitHeight=\"0\" ss:StyleID=\"s62\">";
            fileHeader += "    <Cell ss:Index=\"2\" ss:StyleID=\"s63\"><Data ss:Type=\"String\">Date</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">Detail</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">Movement Id</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">Reference Id</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">Amount</Data></Cell>";
            fileHeader += "    <Cell ss:StyleID=\"s63\"><Data ss:Type=\"String\">Balanced Amount</Data></Cell>";
            fileHeader += "   </Row>";

            return fileHeader;
        }

        private string GetReportFooter()
        {
            string reportFooter = "";

            reportFooter += "  </Table>";
            reportFooter += "  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">";
            reportFooter += "   <PageSetup>";
            reportFooter += "    <Header x:Margin=\"0.3\"/>";
            reportFooter += "    <Footer x:Margin=\"0.3\"/>";
            reportFooter += "    <PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>";
            reportFooter += "   </PageSetup>";
            reportFooter += "   <Unsynced/>";
            reportFooter += "   <Print>";
            reportFooter += "    <ValidPrinterInfo/>";
            reportFooter += "    <HorizontalResolution>600</HorizontalResolution>";
            reportFooter += "    <VerticalResolution>600</VerticalResolution>";
            reportFooter += "   </Print>";
            reportFooter += "   <Selected/>";
            reportFooter += "   <Panes>";
            reportFooter += "    <Pane>";
            reportFooter += "     <Number>3</Number>";
            reportFooter += "     <ActiveRow>3</ActiveRow>";
            reportFooter += "    </Pane>";
            reportFooter += "   </Panes>";
            reportFooter += "   <ProtectObjects>False</ProtectObjects>";
            reportFooter += "   <ProtectScenarios>False</ProtectScenarios>";
            reportFooter += "  </WorksheetOptions>";
            reportFooter += " </Worksheet>";
            reportFooter += "</Workbook>";

            return reportFooter;
        }

        private string StringOrNull(String text)
        {
            if (text != null)
            {
                return text;
            }
            else
            {
                return String.Empty;
            }
        }

        private string StringOrNull(DateTime? date)
        {
            if (date != null)
            {
                return date.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        private string StringOrNull(Int32? number)
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

        private string StringOrNull(float? number)
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
