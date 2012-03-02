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
    /// A representation of the token resource. 
    /// </summary>
    public class Token
    {
        /// <summary>
        /// The token as a json.
        /// </summary>
        private JSONObject _json;

        /// <summary>
        /// Create a new token instance with empty values.
        /// </summary>
        public Token()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new token instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the token data</param>
        public Token(JSONObject json) 
        {
            _json = json;
        }

        /// <summary>
        /// AccessToken field.
        /// </summary>
        public String AccessToken
        {
            get
            {
                return _json.GetJSONStringAttribute("access_token");
            }
            set
            {
                _json.SetJSONStringAttribute("access_token", value);
            }
        }

        /// <summary>
        /// ExpiresIn field.
        /// </summary>
        public Int16? ExpiresIn
        {
            get
            {
                return _json.GetJSONInt16Attribute("expires_in");
            }
            set
            {
                _json.SetJSONInt16Attribute("expires_in", value);
            }
        }

        /// <summary>
        /// RefreshToken field.
        /// </summary>
        public String RefreshToken
        {
            get
            {
                return _json.GetJSONStringAttribute("refresh_token");
            }
            set
            {
                _json.SetJSONStringAttribute("refresh_token", value);
            }
        }

        /// <summary>
        /// Scope field.
        /// </summary>
        public String Scope
        {
            get
            {
                return _json.GetJSONStringAttribute("scope");
            }
            set
            {
                _json.SetJSONStringAttribute("scope", value);
            }
        }

        /// <summary>
        /// TokenType field.
        /// </summary>
        public String TokenType
        {
            get
            {
                return _json.GetJSONStringAttribute("token_type");
            }
            set
            {
                _json.SetJSONStringAttribute("token_type", value);
            }
        }

        /// <summary>
        /// Returns the token as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
