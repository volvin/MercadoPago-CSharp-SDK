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

namespace MercadoPagoSDK
{
    /// <summary>
    /// A representation of the account balance resource. 
    /// </summary>
    public class AccountBalance
    {
        /// <summary>
        /// Create a new account balance instance with empty values.
        /// </summary>
        public AccountBalance()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new account balance instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the balance data</param>
        public AccountBalance(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// AvailableBalance field.
        /// </summary>
        public float? AvailableBalance
        {
            get
            {
                return _json.GetJSONFloatAttribute("available_balance");
            }
        }

        /// <summary>
        /// AvailableBalanceByTransactionType field.
        /// </summary>
        public AmountByTTypeList AvailableBalanceByTransactionType
        {
            get
            {
                return new AmountByTTypeList(_json.GetJSONCustomClassAttribute("available_balance_by_transaction_type"));
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
        /// TotalBalance field.
        /// </summary>
        public float? TotalBalance
        {
            get
            {
                return _json.GetJSONFloatAttribute("available_balance") + _json.GetJSONFloatAttribute("unavailable_balance");
            }
        }

        /// <summary>
        /// UnavailableBalance field.
        /// </summary>
        public float? UnavailableBalance
        {
            get
            {
                return _json.GetJSONFloatAttribute("unavailable_balance");
            }
        }

        /// <summary>
        /// UnavailableBalanceByReason field.
        /// </summary>
        public AmountByReasonList UnavailableBalanceByReason
        {
            get
            {
                return new AmountByReasonList(_json.GetJSONCustomClassAttribute("unavailable_balance_by_reason"));
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
