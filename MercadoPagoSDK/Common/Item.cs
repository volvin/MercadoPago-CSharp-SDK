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
    /// A representation of the item resource. 
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Create a new item instance with empty values.
        /// </summary>
        public Item()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new item instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the item data</param>
        public Item(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
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
        /// Id field.
        /// </summary>
        public String Id
        {
            get
            {
                return _json.GetJSONStringAttribute("id");
            }
            set
            {
                _json.SetJSONStringAttribute("id", value);
            }
        }

        /// <summary>
        /// Quantity field.
        /// </summary>
        public Int16? Quantity
        {
            get
            {
                return _json.GetJSONInt16Attribute("quantity");
            }
            set
            {
                _json.SetJSONInt16Attribute("quantity", value);
            }
        }

        /// <summary>
        /// PictureUrl field.
        /// </summary>
        public String PictureUrl
        {
            get
            {
                return _json.GetJSONStringAttribute("picture_url");
            }
            set
            {
                _json.SetJSONStringAttribute("picture_url", value);
            }
        }

        /// <summary>
        /// Title field.
        /// </summary>
        public String Title
        {
            get
            {
                return _json.GetJSONStringAttribute("title");
            }
            set
            {
                _json.SetJSONStringAttribute("title", value);
            }
        }

        /// <summary>
        /// UnitPrice field.
        /// </summary>
        public Int16? UnitPrice
        {
            get
            {
                return _json.GetJSONInt16Attribute("unit_price");
            }
            set
            {
                _json.SetJSONInt16Attribute("unit_price", value);
            }
        }

        /// <summary>
        /// Returns the item as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The item as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
