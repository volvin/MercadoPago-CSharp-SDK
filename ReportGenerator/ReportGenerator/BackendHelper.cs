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
using System.Web;
using System.Windows.Forms;

namespace ReportGenerator
{
    /// <summary>
    /// A representation of the Backend Helper resource. 
    /// </summary>
    public class BackendHelper
    {
        /// <summary>
        /// Recursively tries to get a collections page from the MP API.
        /// </summary>
        public static SearchPage<Collection> GetCollectionsPage(Int32 offset, Int32 limit, OAuthResponse authorization, DateTime dateFrom, DateTime dateTo, int retryNumber = 0)
        {
            PaymentsHelper ph = new PaymentsHelper();

            // Set access token
            ph.AccessToken = GetAccessToken(authorization);

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

        /// <summary>
        /// Recursively tries to get a movements page from the MP API.
        /// </summary>
        public static SearchPage<Movement> GetMovementsPage(Int32 offset, Int32 limit, OAuthResponse authorization, DateTime dateFrom, DateTime dateTo, int retryNumber = 0)
        {
            AccountsHelper ah = new AccountsHelper();

            // Set access token
            ah.AccessToken = GetAccessToken(authorization);

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
                // Retries the same call until max is reached
                if (retryNumber <= MAX_RETRIES)
                {
                    LogHelper.WriteLine("SearchMovements breaks. Retry num: " + retryNumber.ToString());
                    BackendHelper.GetMovementsPage(offset, limit, authorization, dateFrom, dateTo, retryNumber + 1);
                }
                else
                {
                    // then breaks
                    throw raex;
                }
            }

            if (searchPage != null)
            {
                return searchPage;
            }
            else
            {
                LogHelper.WriteLine("null");
                return null;
            }
        }

        #region "Private Members"

        private const int MAX_RETRIES = 5;

        /// <summary>
        /// Get OAuth response access token validating expiration date.
        /// </summary>
        private static string GetAccessToken(OAuthResponse authorization)
        {
            // Validate access token expiration date
            if (DateTime.Now.CompareTo(authorization.ExpirationDate) < 0)
            {
                return authorization.AccessToken;
            }
            else
            {
                throw new RESTAPIException(400, "", "Session expired", "Access token timed out");
            }
        }

        #endregion
    }
}
