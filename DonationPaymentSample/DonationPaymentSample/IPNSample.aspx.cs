/*
 * Copyright 2011 MercadoLibre, Inc.
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DonationPaymentSample
{
    public partial class IPNSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get collection id
            Int32 id = Convert.ToInt32(Request["id"]);

            if (id != 0)
            {
                try
                {
                    // Create Payments helper
                    PaymentsHelper ph = new PaymentsHelper();

                    // Create a token for the API's calls
                    Token token = ph.CreateAccessToken(Properties.Settings.Default.ClientId, Properties.Settings.Default.ClientSecret);
                    ph.AccessToken = token.AccessToken;

                    // Get Collection Notification
                    CollectionNotification cn = ph.GetCollectionNotification(id);

                    // Here goes your code: do something with the notification!
                    // Remember: IPN system waits for your reply about 500ms. If this method times out that threshold it will retry the
                    // notification again. So prepare your code to be fast enough and/or to support retries (ask if the collection was
                    // already processed!).
                    // In this example: Show collection's json
                    Response.Write(cn.ToJSON().ToString());
                }
                catch (Exception ex)
                { }
            }
        }
    }
}