/*
 * Copyright 2013 MercadoLibre, Inc.
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

using MercadoPagoSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace LocalIPNSimulator
{
    public class MercadoPagoHelper : BaseHelper
    {
        public MercadoPagoSDK.Environment.Scopes EnvironmentScope
        {
            get
            {
                return _environmentScope;
            }

            set
            {
                _environmentScope = value;
            }
        }

        public List<Int32> GetPendingCollections(Int32? lastProcessedCollectionId)
        {
            // Set payments helper
            PaymentsHelper ph = new PaymentsHelper();
            ph.AccessToken = this.AccessToken;
            
            // Prepare API call arguments
            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>();
            args.Add(new KeyValuePair<string, string>("sort", "id"));
            args.Add(new KeyValuePair<string, string>("criteria", "desc"));
            args.Add(new KeyValuePair<string, string>("offset", "0"));
            args.Add(new KeyValuePair<string, string>("limit", "5"));

            // Set environment
            MercadoPagoSDK.Environment.Scope = _environmentScope;

            // Call API
            SearchPage<Collection> searchPage = ph.SearchCollections(args);
            List<Collection> collections = searchPage.Results;

            // Populate pending ids
            List<Int32> pendingIds = new List<int>();
            foreach (Collection collection in collections)
            {
                if (lastProcessedCollectionId != null)
                {
                    if (lastProcessedCollectionId == collection.Id)
                    {
                        break;
                    }
                }
                pendingIds.Add(collection.Id.Value);
            }
            return pendingIds;
        }

        public void PostIPNMessage(string endPoint, Int32 notificationId)
        {
            // Prepare HTTP url
            Uri url = new Uri(endPoint + "?topic=payment&id=" + notificationId.ToString());

            // Set request
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.Timeout = 50;

            // Prepare HTTP body
            string postData = String.Empty;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] postDataBytes = encoding.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = postDataBytes.Length;

            // Call API
            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postDataBytes, 0, postDataBytes.Length);
                requestStream.Close();

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException e)
            {
                // Do nothing
            }
        }

        private MercadoPagoSDK.Environment.Scopes _environmentScope = MercadoPagoSDK.Environment.Scopes.Default;
    }
}
