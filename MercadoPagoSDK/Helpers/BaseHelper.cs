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

namespace MercadoPagoSDK
{
    /// <summary>
    /// A base helper for MercadoPago helpers. 
    /// </summary>
    public abstract class BaseHelper
    {	
        /// <summary>
        /// A RESTAPI object for api calls.
        /// </summary>
        protected RESTAPI _api;

        /// <summary>
        /// AccessToken field.
        /// </summary>
        public string AccessToken 
        {
            get
            {
                return _api.AccessToken;
            }
            set
            {
                _api.AccessToken = value;
            }
        }

        /// <summary>
        /// Create a BaseHelper instance.
        /// </summary>
        public BaseHelper()
        {
            _api = new RESTAPI(new Uri(Properties.Settings.Default.ApiBaseUrl));
        }

        /// <summary>
        /// Creates an access token to use in API calls.
        /// </summary>
        [System.Obsolete("Use static method AuthHelper.CreateAccessToken instead", false)]
        public Token CreateAccessToken(string clientId, string clientSecret)
        {
            return AuthHelper.CreateAccessToken(clientId, clientSecret);
        }
    }
}
