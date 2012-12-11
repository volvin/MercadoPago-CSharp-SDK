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
using System.Web;
using System.Web.Script.Serialization;
using MercadoPagoSDK.Helpers;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A helper for Authentication and Authorization operations. 
    /// </summary>
    public class AuthHelper
    {
        /// <summary>
        /// Creates an access token to use in API calls.
        /// </summary>
        public static Token CreateAccessToken(string clientId, string clientSecret)
        {
            // Set client credential
            Credential credential = new Credential();
            credential.ClientId = clientId;
            credential.ClientSecret = clientSecret;
            credential.GrantType = "client_credentials";

            // Create token
            RESTAPI api = new RESTAPI(new Uri(SettingsHelper.ApiBaseUrl));
            JSONObject json = api.Post(SettingsHelper.AppSecurityUri, credential.ToJSON(), ContentType.HTTP);
            Token token = new Token(json);

            return token;
        }
    }
}
