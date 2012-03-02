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
    /// A representation of the payment choices resource. 
    /// </summary>
    public class PaymentChoices
    {
        /// <summary>
        /// The payment choices as a json.
        /// </summary>
        private JSONObject _json;

        /// <summary>
        /// Create a new payment choices instance with empty values.
        /// </summary>
        public PaymentChoices()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new payment choices instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the payment choices data</param>
        public PaymentChoices(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// AllowedInstallments field.
        /// </summary>
        public Int16? AllowedInstallments
        {
            get
            {
                return _json.GetJSONInt16Attribute("installments");
            }
            set
            {
                _json.SetJSONInt16Attribute("installments", value);
            }
        }

        /// <summary>
        /// ExcludedMethods field.
        /// </summary>
        public IdList ExcludedMethods
        {
            get
            {
                return new IdList(_json.GetJSONCustomClassAttribute("excluded_payment_methods"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("excluded_payment_methods", value.ToJSON());
            }
        }

        /// <summary>
        /// ExcludedTypes field.
        /// </summary>
        public IdList ExcludedTypes
        {
            get
            {
                return new IdList(_json.GetJSONCustomClassAttribute("excluded_payment_types"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("excluded_payment_types", value.ToJSON());
            }
        }

        /// <summary>
        /// Returns the payment choices as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
