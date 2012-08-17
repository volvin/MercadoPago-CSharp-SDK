using MercadoPagoSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectionUpdateSample
{
    public partial class _Default : System.Web.UI.Page
    {
        private const int COLLECTIONS_PAGE_SIZE = 10;

        PaymentsHelper _ph;
        Token _token;

        protected void CancelCollectionButton_Click(object sender, EventArgs e)
        {
            // Set PaymentHelper
            PaymentsHelper ph = GetPaymentsHelper();

            // Try cancel the collection
            try
            {
                ph.CancelCollection(Convert.ToInt32(ColIdCancelColText.Text));
                ShowLabelMessageOk(CancelCollectionResult);
            }
            catch (Exception ex)
            {
                ShowLabelMessageError(CancelCollectionResult, ex.Message);
            }
        }

        protected void ChangeExternalReferenceButton_Click(object sender, EventArgs e)
        {
            // Set PaymentHelper
            PaymentsHelper ph = GetPaymentsHelper();

            // Try change the collection's external reference
            try
            {
                Collection collection = new Collection();
                collection.Id = Convert.ToInt32(ColIdChangeExtRefText.Text);
                collection.ExternalReference = NewExternalReferenceText.Text;
                ph.UpdateCollection(collection);
                ShowLabelMessageOk(ChangeExternalReferenceResult);
            }
            catch (Exception ex)
            {
                ShowLabelMessageError(ChangeExternalReferenceResult, ex.Message);
            }
        }

        protected void CollectionsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = CollectionsGridView.SelectedRow;
            ColIdChangeExtRefText.Text = row.Cells[1].Text;
            ColIdCancelColText.Text = row.Cells[1].Text;
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            // Activate search grid layer
            SampleMultiView.ActiveViewIndex = 1;

            // Load data grid
            LoadSearchGrid(1, COLLECTIONS_PAGE_SIZE);
        }

        protected void FirstPageButton_Click(object sender, EventArgs e)
        {
            LoadSearchGrid(1, COLLECTIONS_PAGE_SIZE);
        }

        protected void GoToCancelCollectionButton_Click(object sender, EventArgs e)
        {
            SampleMultiView.ActiveViewIndex = 3;
        }

        protected void GoToChangeExtRefButton_Click(object sender, EventArgs e)
        {
            SampleMultiView.ActiveViewIndex = 2;
        }

        protected void LastPageButton_Click(object sender, EventArgs e)
        {
            decimal pages = Convert.ToDecimal(PagerTotal.Text) / COLLECTIONS_PAGE_SIZE;
            int nextOffset = ((int)Math.Truncate(pages) * COLLECTIONS_PAGE_SIZE) + 1;
            LoadSearchGrid(nextOffset, COLLECTIONS_PAGE_SIZE);
        }

        protected void PageDownButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(PagerFrom.Text) - COLLECTIONS_PAGE_SIZE;
            if (nextOffset >= 1)
            {
                LoadSearchGrid(nextOffset, COLLECTIONS_PAGE_SIZE);
            }
        }

        protected void PageUpButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(PagerTo.Text) + 1;
            if (nextOffset <= Convert.ToInt16(PagerTotal.Text))
            {
                LoadSearchGrid(nextOffset, COLLECTIONS_PAGE_SIZE);
            }
        }

        protected void RefreshPageButton_Click(object sender, EventArgs e)
        {
            int nextOffset = Convert.ToInt16(PagerFrom.Text);
            LoadSearchGrid(nextOffset, COLLECTIONS_PAGE_SIZE);
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            // Activate search grid layer
            SampleMultiView.ActiveViewIndex = 1;
        }

        private PaymentsHelper GetPaymentsHelper()
        {
            // Check api token
            if (_token == null)
            {
                // Create new token for api calls
                _token = AuthHelper.CreateAccessToken(ClientIdTxt.Text, ClientSecretTxt.Text);
            }
            else
            { 
                // Check token expiration time
                if (_token.DateExpired.CompareTo(DateTime.Now) <= 0)
                {
                    // Regenerate token
                    _token = AuthHelper.CreateAccessToken(ClientIdTxt.Text, ClientSecretTxt.Text);
                }
            }

            // Set PaymentHelper
            if (_ph == null)
            {
                _ph = new PaymentsHelper();            
            }
            _ph.AccessToken = _token.AccessToken;

            return _ph;
        }

        private void LoadSearchGrid(int offset, int pageSize)
        {
            // Set PaymentHelper
            PaymentsHelper ph = GetPaymentsHelper();

            // Get Collections
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            args.Add(new KeyValuePair<string, string>("sort", "date_created"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", (offset - 1).ToString()));
            args.Add(new KeyValuePair<string, string>("limit", pageSize.ToString()));
            SearchPage<Collection> searchPage = ph.SearchCollections(args);
            List<Collection> collections = searchPage.Results;

            // Bind this info to the grid view
            CollectionsGridView.DataSource = collections;
            CollectionsGridView.DataBind();

            // Set pager info
            PagerFrom.Text = offset.ToString();
            PagerTo.Text = (offset + collections.Count - 1).ToString();
            PagerTotal.Text = searchPage.Total.ToString();
            PagerPanel.Visible = true;
        }

        private void ShowLabelMessageError(Label label, string errorMessage)
        {
            label.Font.Bold = true;
            label.ForeColor = System.Drawing.Color.Red;
            label.Text = "Error: " + errorMessage;
        }

        private void ShowLabelMessageOk(Label label)
        {
            label.Font.Bold = true;
            label.ForeColor = System.Drawing.Color.Green;
            label.Text = "Done!";
        }
    }
}
