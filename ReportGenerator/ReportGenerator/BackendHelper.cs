using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPagoSDK;
using System.Web;
using System.Windows.Forms;

namespace ReportGenerator
{
    public class BackendHelper
    {
        private const int MAX_RETRIES = 5;

        // Recursively tries to get a collections page from the MP API
        public static SearchPage<Collection> GetCollectionsPage(Int32 offset, Int32 limit, OAuthResponse authorization, DateTime dateFrom, DateTime dateTo, int retryNumber = 0)
        {
            PaymentsHelper ph = new PaymentsHelper();

            // Set access token and hook API call event
            ph.AccessToken = authorization.AccessToken;
            //ah.APICall += new APICallEventHandler(OnAPICall);

            // Prepare API call arguments
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            if (authorization.IsAdmin)
            {
                args.Add(new KeyValuePair<string, string>("collector_id", authorization.UserId.ToString()));
            }
            // Try optimize the query by site id, taking advantage of the search sharding
            if (authorization.SiteId != null)
            {
                args.Add(new KeyValuePair<string, string>("site_id", authorization.SiteId));            
            }
            args.Add(new KeyValuePair<string, string>("sort", "date_created"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            args.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
            args.Add(new KeyValuePair<string, string>("range", "date_created"));
            args.Add(new KeyValuePair<string, string>("begin_date", HttpUtility.UrlEncode(dateFrom.GetDateTimeFormats('s')[0].ToString() + ".000Z")));
            args.Add(new KeyValuePair<string, string>("end_date", HttpUtility.UrlEncode(dateTo.GetDateTimeFormats('s')[0].ToString() + ".000Z")));

            SearchPage<Collection> searchPage = null;
            try
            {
                // Search the API
                searchPage = ph.SearchCollections(args);
            }
            catch (RESTAPIException raex)
            {
                // Retries the same call until max is reached
                if (retryNumber <= MAX_RETRIES)
                {
                    LogHelper.WriteLine("SearchCollections breaks. Retry num: " + retryNumber.ToString()); 
                    BackendHelper.GetCollectionsPage(offset, limit, authorization, dateFrom, dateTo, retryNumber + 1);
                }
                else
                {
                    // then breaks
                    throw raex;
                }
            }

            return searchPage;
        }

        public static SearchPage<Movement> GetMovementsPage(Int32 offset, Int32 limit, OAuthResponse authorization, DateTime dateFrom, DateTime dateTo)
        {
            AccountsHelper ah = new AccountsHelper();

            // Set access token and hook API call event
            ah.AccessToken = authorization.AccessToken;
            //ah.APICall += new APICallEventHandler(OnAPICall);

            // Prepare API call arguments
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            if (authorization.IsAdmin)
            {
                args.Add(new KeyValuePair<string, string>("user_id", authorization.UserId.ToString()));
            }
            // Try optimize the query by site id, taking advantage of the search sharding
            if (authorization.SiteId != null)
            {
                args.Add(new KeyValuePair<string, string>("site_id", authorization.SiteId));
            }
            args.Add(new KeyValuePair<string, string>("sort", "date_created"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", offset.ToString()));
            args.Add(new KeyValuePair<string, string>("limit", limit.ToString()));
            args.Add(new KeyValuePair<string, string>("range", "date_created"));
            args.Add(new KeyValuePair<string, string>("begin_date", HttpUtility.UrlEncode(dateFrom.GetDateTimeFormats('s')[0].ToString() + ".000Z")));
            args.Add(new KeyValuePair<string, string>("end_date", HttpUtility.UrlEncode(dateTo.GetDateTimeFormats('s')[0].ToString() + ".000Z")));

            // Call API
            SearchPage<Movement> searchPage = null;
            try
            {
                searchPage = ah.SearchMovements(args);
            }
            catch (RESTAPIException raex)
            {
                throw raex;
            }

            return searchPage;
        }
    }
}
