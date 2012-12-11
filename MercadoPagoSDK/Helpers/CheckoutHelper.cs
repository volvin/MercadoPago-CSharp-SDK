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
using MercadoPagoSDK.Helpers;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A helper for Checkout operations. 
    /// </summary>
    public class CheckoutHelper : BaseHelper
    {
        /// <summary>
        /// Creates a checkout preference. 
        /// </summary>
        public Preference CreatePreference(Preference preference)
        {
            JSONObject json = _api.Post(SettingsHelper.PreferencesUri, preference.ToJSON(), ContentType.JSON);
            preference = new Preference(json);

            return preference;
		}

        /// <summary>
        /// Updates a checkout preference. 
        /// </summary>		
		public Preference UpdatePreference(Preference preference)
		{
		    return null;
		}

        /// <summary>
        /// Gets a checkout preference. 
        /// </summary>
		public Preference GetPreference(string preferenceId)
		{
			return null;
		}
    }
}
