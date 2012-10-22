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

namespace IPNClientSample
{
    public partial class _Default : System.Web.UI.Page
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
                    // Remember 1st!
                    // Change the property settings (Settings.settings) for the following variables:
                    // Your ClientId, Your ClientSecret
                    Token token = AuthHelper.CreateAccessToken(Properties.Settings.Default.ClientId, Properties.Settings.Default.ClientSecret);
                    ph.AccessToken = token.AccessToken;

                    // Get Collection Notification
                    CollectionNotification cn = ph.GetCollectionNotification(id);

                    // Here goes your code: do something with the notification!
                    // Remember: IPN system waits for your reply about 500ms. If this method times out that threshold it will retry the
                    // notification again. So prepare your code to be fast enough and/or to support retries (eg., ask if the collection was
                    // already processed!).
                    // This example just shows collection's attribute values
                    Label1.Text = "<b>currency id:</b> " + cn.Collection.CurrencyId + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector id:</b> " + cn.Collection.Collector.Id.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector first name:</b> " + cn.Collection.Collector.FirstName + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector last name:</b> " + cn.Collection.Collector.LastName + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector nickname:</b> " + cn.Collection.Collector.Nickname + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector email:</b> " + cn.Collection.Collector.Email + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector phone areacode:</b> " + cn.Collection.Collector.Phone.AreaCode + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector phone number:</b> " + cn.Collection.Collector.Phone.Number + "<br/>";
                    Label1.Text = Label1.Text + "<b>collector phone extension:</b> " + cn.Collection.Collector.Phone.Extension + "<br/>";
                    Label1.Text = Label1.Text + "<b>date approved:</b> " + cn.Collection.DateApproved.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>date created:</b> " + cn.Collection.DateCreated.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>external reference:</b> " + cn.Collection.ExternalReference + "<br/>";
                    Label1.Text = Label1.Text + "<b>finance charge:</b> " + cn.Collection.FinanceCharge.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>id:</b> " + cn.Collection.Id.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>installments:</b> " + cn.Collection.Installments.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>last modified:</b> " + cn.Collection.LastModified.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>marketplace:</b> " + cn.Collection.Marketplace.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>mercadopago fee:</b> " + cn.Collection.MercadoPagoFee.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>money release date:</b> " + cn.Collection.MoneyReleaseDate.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>net received amount:</b> " + cn.Collection.NetReceivedAmount.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>operation type:</b> " + cn.Collection.OperationType + "<br/>";
                    Label1.Text = Label1.Text + "<b>order id:</b> " + cn.Collection.OrderId + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer id:</b> " + cn.Collection.Payer.Id.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer first name:</b> " + cn.Collection.Payer.FirstName + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer last name:</b> " + cn.Collection.Payer.LastName + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer nickname:</b> " + cn.Collection.Payer.Nickname + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer email:</b> " + cn.Collection.Payer.Email + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer phone areacode:</b> " + cn.Collection.Payer.Phone.AreaCode + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer phone number:</b> " + cn.Collection.Payer.Phone.Number + "<br/>";
                    Label1.Text = Label1.Text + "<b>payer phone extension:</b> " + cn.Collection.Payer.Phone.Extension + "<br/>";
                    Label1.Text = Label1.Text + "<b>payment type:</b> " + cn.Collection.PaymentType + "<br/>";
                    Label1.Text = Label1.Text + "<b>reason:</b> " + cn.Collection.Reason + "<br/>";
                    Label1.Text = Label1.Text + "<b>released:</b> " + cn.Collection.Released.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>shipping cost:</b> " + cn.Collection.ShippingCost.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>site id:</b> " + cn.Collection.SiteId + "<br/>";
                    Label1.Text = Label1.Text + "<b>status:</b> " + cn.Collection.Status + "<br/>";
                    Label1.Text = Label1.Text + "<b>status detail:</b> " + cn.Collection.StatusDetail + "<br/>";
                    Label1.Text = Label1.Text + "<b>total paid amount:</b> " + cn.Collection.TotalPaidAmount.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>transaction amount:</b> " + cn.Collection.TransactionAmount.ToString() + "<br/>";
                    Label1.Text = Label1.Text + "<b>json:</b> " + cn.ToJSON().ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
