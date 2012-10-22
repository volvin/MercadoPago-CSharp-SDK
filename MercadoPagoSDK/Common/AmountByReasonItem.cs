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
    /// A representation of the amount by reason item resource. 
    /// </summary>
    public class AmountByReasonItem
    {
        /// <summary>
        /// Create a new amount by reason item instance with empty values.
        /// </summary>
        public AmountByReasonItem()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new amount by reason item instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the amount by reason item data</param>
        public AmountByReasonItem(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// Amount field.
        /// </summary>
        public float? Amount
        {
            get
            {
                return _json.GetJSONFloatAttribute("amount");
            }
            set
            {
                _json.SetJSONFloatAttribute("amount", value);
            }
        }

        /// <summary>
        /// Reason field.
        /// </summary>
        public String Reason
        {
            get
            {
                return _json.GetJSONStringAttribute("reason");
            }
            set
            {
                _json.SetJSONStringAttribute("reason", value);
            }
        }

        /// <summary>
        /// Returns the amount by reason item as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The amount by reason item as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
