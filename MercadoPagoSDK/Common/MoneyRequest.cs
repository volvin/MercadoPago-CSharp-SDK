/*
 * Copyright 2013 MercadoLibre, Inc.
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
    /// A representation of the money request resource. 
    /// </summary>
    public class MoneyRequest
    {
        /// <summary>
        /// Create a new money request instance with empty values.
        /// </summary>
        public MoneyRequest()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new money request instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the money request data</param>
        public MoneyRequest(JSONObject json)
        {
            // todo: como valido que no me asignen cualquier fruta
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
        /// ConceptType field.
        /// </summary>
        public String ConceptType
        {
            get
            {
                return _json.GetJSONStringAttribute("concept_type");
            }
            set
            {
                _json.SetJSONStringAttribute("concept_type", value);
            }
        }

        /// <summary>
        /// CurrencyId field.
        /// </summary>
        public String CurrencyId
        {
            get
            {
                return _json.GetJSONStringAttribute("currency_id");
            }
            set
            {
                _json.SetJSONStringAttribute("currency_id", value);
            }
        }

        /// <summary>
        /// Description field.
        /// </summary>
        public String Description
        {
            get
            {
                return _json.GetJSONStringAttribute("description");
            }
            set
            {
                _json.SetJSONStringAttribute("description", value);
            }
        }

        /// <summary>
        /// ExternalReference field.
        /// </summary>
        public String ExternalReference
        {
            get
            {
                return _json.GetJSONStringAttribute("external_reference");
            }
            set
            {
                _json.SetJSONStringAttribute("external_reference", value);
            }
        }

        /// <summary>
        /// Id field.
        /// </summary>
        public Int32? Id
        {
            get
            {
                return _json.GetJSONInt32Attribute("id");
            }
            set
            {
                _json.SetJSONInt32Attribute("id", value);
            }
        }

        /// <summary>
        /// PayerEmail field.
        /// </summary>
        public String PayerEmail
        {
            get
            {
                return _json.GetJSONStringAttribute("payer_email");
            }
            set
            {
                _json.SetJSONStringAttribute("payer_email", value);
            }
        }

        /// <summary>
        /// Returns the phone as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The phone as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
