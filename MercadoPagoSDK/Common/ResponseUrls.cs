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
    /// A representation of the response urls resource. 
    /// </summary>
    public class ResponseUrls
    {
        /// <summary>
        /// Create a new response urls instance with empty values.
        /// </summary>
        public ResponseUrls()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new response urls instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the response urls data</param>
        public ResponseUrls(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// Failure field.
        /// </summary>
        public String Failure
        {
            get
            {
                return _json.GetJSONStringAttribute("failure");
            }
            set
            {
                _json.SetJSONStringAttribute("failure", value);
            }
        }

        /// <summary>
        /// Pending field.
        /// </summary>
        public String Pending
        {
            get
            {
                return _json.GetJSONStringAttribute("pending");
            }
            set
            {
                _json.SetJSONStringAttribute("pending", value);
            }
        }

        /// <summary>
        /// Success field.
        /// </summary>
        public String Success
        {
            get
            {
                return _json.GetJSONStringAttribute("success");
            }
            set
            {
                _json.SetJSONStringAttribute("success", value);
            }
        }

        /// <summary>
        /// Returns the response urls as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The response urls as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
