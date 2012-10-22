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
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
{
    // Remember 1st!
    // Change the property settings (Web.config) for the following variables:
    // Your ClientId, Your ClientSecret
    // Your Item id, title, description, image and amount's currency id
    // Site's return urls

    protected String returnValue;

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = Page.ClientScript;
        String cbReference = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "");
        String callbackScript = "function CallServer(arg, context) {" + cbReference + "; }";
        cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);

        DonationTitle.Text = ConfigurationManager.AppSettings["Title"];
        DonationDescription.Text = ConfigurationManager.AppSettings["Description"];
        DonationImage.ImageUrl = ConfigurationManager.AppSettings["ImageUrl"];
    }

    #region Standard Checkout sample
    // Using a standard ASP.NET button creates a preference and navigates checkout
    protected void RunStandardButton_Click(object sender, EventArgs e)
    {
        // Set amount and email
        Int16 amount;
        if (Radio10.Checked)
        {
            amount = Convert.ToInt16(Radio10.Text);
        }
        else
        {
            amount = Convert.ToInt16(Radio20.Text);
        }
        string email = Email.Text;

        // Create checkout preference
        Preference preference = CreatePreference(amount, email);

        // Navigate payment checkout
        Response.Redirect(preference.InitPoint);
    }
    #endregion

    #region Checkout Lightbox sample

    // Javascript "CallServer" funtion
    public void RaiseCallbackEvent(String eventArgument)
    {
        // Set amount and email
        JSONObject json = JSONObject.CreateFromString(eventArgument);
        Int16 amount = Convert.ToInt16(json.Dictionary["amount"].ToString());
        string email = json.Dictionary["email"].ToString();

        // Create checkout preference
        Preference preference = CreatePreference(amount, email);

        // Return checkout init point
        returnValue = preference.InitPoint;
    }

    // Return callback result
    public string GetCallbackResult()
    {
        return returnValue;
    }
    #endregion

    #region Private
    // Create a checkout preference
    private Preference CreatePreference(Int16 amount, string email)
    {
        // Set Checkout Helper
        CheckoutHelper ch = new CheckoutHelper();

        // Create token
        Token token = AuthHelper.CreateAccessToken(ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["ClientSecret"]);
        ch.AccessToken = token.AccessToken;

        // Set item
        Item item = new Item();
        item.CurrencyId = ConfigurationManager.AppSettings["CurrencyId"];
        item.Description = ConfigurationManager.AppSettings["Description"];
        item.Id = ConfigurationManager.AppSettings["ItemId"];
        item.PictureUrl = ConfigurationManager.AppSettings["ImageUrl"];
        item.Quantity = 1;
        item.Title = ConfigurationManager.AppSettings["Title"];
        item.UnitPrice = amount;

        // Set preference
        Preference preference = new Preference();
        preference.BackUrls = new ResponseUrls();
        preference.BackUrls.Failure = ConfigurationManager.AppSettings["FailureUrl"];
        preference.BackUrls.Pending = ConfigurationManager.AppSettings["PendingUrl"];
        preference.BackUrls.Success = ConfigurationManager.AppSettings["SuccessUrl"];
        preference.ExternalReference = "my id";  // your id for this transaction
        preference.Items = new ItemList();
        preference.Items.Add(item);
        preference.Payer = new UserEx();
        preference.Payer.Email = email;

        // Create preference
        preference = ch.CreatePreference(preference);

        return preference;
    }
    #endregion
}
