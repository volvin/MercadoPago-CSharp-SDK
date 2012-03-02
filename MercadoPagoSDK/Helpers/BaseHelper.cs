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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Script.Serialization;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A base helper for MercadoPago helpers. 
    /// </summary>
    public abstract class BaseHelper
    {	
        public static string API_BASE_URL = "https://api.mercadolibre.com";
        public static string APP_SECURITY_PATH = "/oauth/token";
        public static string PREFERENCE_PATH = "/checkout/preferences";
        public static string COLLECTION_NOTIFICATION_PATH = "/collections/notifications";

        /// <summary>
        /// A RESTAPI object for api calls.
        /// </summary>
        protected RESTAPI api;

        /// <summary>
        /// AccessToken field.
        /// </summary>
        public string AccessToken 
        {
            get
            {
                return api.AccessToken;
            }
            set
            {
                api.AccessToken = value;
            }
        }

        /// <summary>
        /// Create a BaseHelper instance.
        /// </summary>
        public BaseHelper()
        {
            api = new RESTAPI(new Uri(API_BASE_URL));
        }

        /// <summary>
        /// Creates an access token to use in API calls.
        /// </summary>
        public Token CreateAccessToken(string clientId, string clientSecret)
		{
		    // Set client credential
            Credential credential = new Credential();
			credential.ClientId = clientId;
			credential.ClientSecret = clientSecret;
			credential.GrantType = "client_credentials";

            // Create token
            JSONObject json = api.Post(APP_SECURITY_PATH, credential.ToJSON(), ContentType.HTTP);
            Token token = new Token(json);

            return token;
        }
    }
}
