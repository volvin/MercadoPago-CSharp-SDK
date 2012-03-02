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
    /// A representation of the preference resource. 
    /// </summary>
    public class Preference
    {
        /// <summary>
        /// The preference as a json.
        /// </summary>
        private JSONObject _json;

        /// <summary>
        /// Create a new preference instance with empty values.
        /// </summary>
        public Preference()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new preference instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the preference data</param>
        public Preference(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// ActivationDate field.
        /// </summary>
        public DateTime? ActivationDate
        {
            get
            {
                return _json.GetJSONDateTimeAttribute("expiration_date_from");
            }
            set
            {
                _json.SetJSONDateTimeAttribute("expiration_date_from", value);
            }
        }

        /// <summary>
        /// BackUrls field.
        /// </summary>
        public ResponseUrls BackUrls
        {
            get
            {
                return new ResponseUrls(_json.GetJSONCustomClassAttribute("back_urls"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("back_urls", value.ToJSON());
            }
        }

        /// <summary>
        /// CollectorId field.
        /// </summary>
        public Int32? CollectorId
        {
            get
            {
                return _json.GetJSONInt32Attribute("collector_id");
            }
        }

        /// <summary>
        /// CustomPaymentChoices field.
        /// </summary>
        public PaymentChoices CustomPaymentChoices
        {
            get
            {
                return new PaymentChoices(_json.GetJSONCustomClassAttribute("payment_methods"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("payment_methods", value.ToJSON());
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
        /// ExpirationDate field.
        /// </summary>        
        public DateTime? ExpirationDate
        {
            get 
            {
                return _json.GetJSONDateTimeAttribute("expiration_date_to");
            }
            set 
            {
                _json.SetJSONDateTimeAttribute("expiration_date_to", value);
            }
        }

        /// <summary>
        /// Expires field.
        /// </summary>
        public bool? Expires
        {
            get
            {
                return _json.GetJSONBooleanAttribute("expires");            
            }
            set 
            {
                _json.SetJSONBooleanAttribute("expires", value);
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
        /// InitPoint field.
        /// </summary>
        public String InitPoint
        {
            get
            {
                return _json.GetJSONStringAttribute("init_point");
            }
        }

        /// <summary>
        /// Items field.
        /// </summary>
        public ItemList Items
        {
            get
            {
                return new ItemList(_json.GetJSONCustomClassAttribute("items"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("items", value.ToJSON());
            }
        }

        /// <summary>
        /// Payer field.
        /// </summary>
        public UserEx Payer
        {
            get
            {
                return new UserEx(_json.GetJSONCustomClassAttribute("payer"));
            }
            set
            {
                _json.SetJSONCustomClassAttribute("payer", value.ToJSON());
            }
        }

        /// <summary>
        /// SponsorId field.
        /// </summary>
        public Int32? SponsorId
        {
            get
            {
                return _json.GetJSONInt32Attribute("sponsor_id");
            }
        }

        /// <summary>
        /// SubscriptionPlanId field.
        /// </summary>
        public Int16? SubscriptionPlanId
        {
            get
            {
                return _json.GetJSONInt16Attribute("subscription_plan_id");
            }
            set
            {
                _json.SetJSONInt16Attribute("subscription_plan_id", value);
            }
        }

        /// <summary>
        /// Returns the preference as a json object.
        /// </summary>
        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
