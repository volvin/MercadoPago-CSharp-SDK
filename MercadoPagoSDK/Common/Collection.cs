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
    /// A representation of the collection resource. 
    /// </summary>
    public class Collection
    {
        /// <summary>
        /// Create a new collection instance with empty values.
        /// </summary>
        public Collection()
        {
            string json = "{}";

            _json = JSONObject.CreateFromString(json);
        }

        /// <summary>
        /// Create a new collection instance using a valid json.
        /// </summary>
        /// <param name="json">The json object used to
        /// fill the collection data</param>
        public Collection(JSONObject json)
        {
            // todo: strong type validation
            _json = json;
        }

        /// <summary>
        /// Collector field.
        /// </summary>
        public User Collector
        {
            get
            {
                return new User(_json.GetJSONCustomClassAttribute("collector"));
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
        /// DateApproved field.
        /// </summary>
        public DateTime? DateApproved
        {
            get
            {
                return _json.GetJSONDateTimeAttribute("date_approved");
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
        /// FinanceCharge field.
        /// </summary>
        public float? FinanceCharge
        {
            get
            {
                return _json.GetJSONFloatAttribute("finance_charge");
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
        /// Installments field.
        /// </summary>
        public Int16? Installments
        {
            get
            {
                return _json.GetJSONInt16Attribute("installments");
            }
        }

        /// <summary>
        /// LastModified field.
        /// </summary>
        public DateTime? LastModified
        {
            get
            {
                return _json.GetJSONDateTimeAttribute("last_modified");
            }
        }

        /// <summary>
        /// Marketplace field.
        /// </summary>
        public String Marketplace
        {
            get
            {
                return _json.GetJSONStringAttribute("marketplace");
            }
        }

        /// <summary>
        /// MercadoPagoFee field.
        /// </summary>
        public float? MercadoPagoFee
        {
            get
            {
                return _json.GetJSONFloatAttribute("mercadopago_fee");
            }
        }

        /// <summary>
        /// MoneyReleaseDate field.
        /// </summary>
        public DateTime? MoneyReleaseDate
        {
            get
            {
                return _json.GetJSONDateTimeAttribute("money_release_date");
            }
        }

        /// <summary>
        /// NetReceivedAmount field.
        /// </summary>
        public float? NetReceivedAmount
        {
            get
            {
                return _json.GetJSONFloatAttribute("net_received_amount");
            }
        }

        /// <summary>
        /// OperationType field.
        /// </summary>
        public String OperationType
        {
            get
            {
                return _json.GetJSONStringAttribute("operation_type");
            }
        }

        /// <summary>
        /// OrderId field.
        /// </summary>
        public String OrderId
        {
            get
            {
                return _json.GetJSONStringAttribute("order_id");
            }
        }

        /// <summary>
        /// Payer field.
        /// </summary>
        public User Payer
        {
            get
            {
                return new User(_json.GetJSONCustomClassAttribute("payer"));
            }
        }

        /// <summary>
        /// PaymentType field.
        /// </summary>
        public String PaymentType
        {
            get
            {
                return _json.GetJSONStringAttribute("payment_type");
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
        }

        /// <summary>
        /// Released field.
        /// </summary>
        public bool? Released
        {
            get
            {
                return _json.GetJSONBooleanAttribute("released");
            }
        }

        /// <summary>
        /// ShippingCost field.
        /// </summary>
        public float? ShippingCost
        {
            get
            {
                return _json.GetJSONFloatAttribute("shipping_cost");
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
            set
            {
                _json.SetJSONStringAttribute("status", value);
            }
        }

        /// <summary>
        /// StatusDetail field.
        /// </summary>
        public String StatusDetail
        {
            get
            {
                return _json.GetJSONStringAttribute("status_detail");
            }
        }

        /// <summary>
        /// TotalPaidAmount field.
        /// </summary>
        public float? TotalPaidAmount
        {
            get
            {
                return _json.GetJSONFloatAttribute("total_paid_amount");
            }
        }

        /// <summary>
        /// TransactionAmount field.
        /// </summary>
        public float? TransactionAmount
        {
            get
            {
                return _json.GetJSONFloatAttribute("transaction_amount");
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
