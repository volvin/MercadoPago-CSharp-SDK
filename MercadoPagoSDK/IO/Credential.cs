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

namespace MercadoPagoSDK
{
    /// <summary>
    /// A representation of the credential resource. 
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Create a credential instance with empty values.
        /// </summary>
        public Credential()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new credential instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the credential data</param>
        public Credential(JSONObject json)
        {
            _json = json;
        }

        /// <summary>
        /// ClientId field.
        /// </summary>
        public String ClientId
        {
            get 
            {
                return _json.GetJSONStringAttribute("client_id");
            }
            set 
            {
                _json.SetJSONStringAttribute("client_id", value);
            }
        }

        /// <summary>
        /// ClientSecret field.
        /// </summary>
        public String ClientSecret
        {
            get 
            {
                return _json.GetJSONStringAttribute("client_secret");
            }
            set 
            {
                _json.SetJSONStringAttribute("client_secret", value);
            }
        }

        /// <summary>
        /// GrantType field.
        /// </summary>
        public String GrantType 
        {
            get 
            {
                return _json.GetJSONStringAttribute("grant_type");
            }
            set 
            {
                _json.SetJSONStringAttribute("grant_type", value);
            }
        }

        /// <summary>
        /// Returns the credential as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The credential as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
