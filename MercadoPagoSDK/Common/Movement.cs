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
    /// A representation of the movement resource. 
    /// </summary>
    public class Movement
    {
        /// <summary>
        /// Create a new movement instance with empty values.
        /// </summary>
        public Movement()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new movement instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the movement data</param>
        public Movement(JSONObject json)
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
        }

        /// <summary>
        /// BalancedAmount field.
        /// </summary>
        public float? BalancedAmount
        {
            get
            {
                return _json.GetJSONFloatAttribute("balanced_amount");
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
        }

        /// <summary>
        /// DateCreated field.
        /// </summary>
        public DateTime? DateCreated
        {
            get
            {
                return _json.GetJSONDateTimeAttribute("date_created");
            }
        }

        /// <summary>
        /// Detail field.
        /// </summary>
        public String Detail
        {
            get
            {
                return _json.GetJSONStringAttribute("detail");
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
        }

        /// <summary>
        /// OriginalMoveId field.
        /// </summary>
        public Int32? OriginalMoveId
        {
            get
            {
                return _json.GetJSONInt32Attribute("original_move_id");
            }
        }

        /// <summary>
        /// ReferenceId field.
        /// </summary>
        public String ReferenceId
        {
            get
            {
                return _json.GetJSONStringAttribute("reference_id");
            }
        }

        /// <summary>
        /// SiteId field.
        /// </summary>
        public String SiteId
        {
            get
            {
                return _json.GetJSONStringAttribute("site_id");
            }
        }

        /// <summary>
        /// Status field.
        /// </summary>
        public String Status
        {
            get
            {
                return _json.GetJSONStringAttribute("status");
            }
        }

        /// <summary>
        /// Type field.
        /// </summary>
        public String Type
        {
            get
            {
                return _json.GetJSONStringAttribute("type");
            }
        }

        /// <summary>
        /// UserId field.
        /// </summary>
        public Int32? UserId
        {
            get
            {
                return _json.GetJSONInt32Attribute("user_id");
            }
        }

        /// <summary>
        /// Returns the collection as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }

        #region "Private Members"

        /// <summary>
        /// The collection as a json.
        /// </summary>
        private JSONObject _json;

        #endregion
    }
}
