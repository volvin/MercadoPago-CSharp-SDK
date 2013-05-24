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
using MercadoPagoSDK.Helpers;

namespace MercadoPagoSDK
{
    /// <summary>
    /// A helper for MoneyRequests operations. 
    /// </summary>
    public class MoneyRequestsHelper : BaseHelper
    {
        /// <summary>
        /// Creates a money request. 
        /// </summary>
        public MoneyRequest CreateMoneyRequest(MoneyRequest moneyRequest)
        {
            
            JSONObject json = _api.Post(SettingsHelper.MoneyRequestsUri, moneyRequest.ToJSON(), ContentType.JSON);
            moneyRequest = new MoneyRequest(json);

            return moneyRequest;
        }

        /// <summary>
        /// Gets a money request. 
        /// </summary>
        public MoneyRequest GetMoneyRequest(Int32 moneyRequestId)
        {

            JSONObject json = _api.Get(SettingsHelper.MoneyRequestsUri + "/" + moneyRequestId.ToString());
            MoneyRequest moneyRequest = new MoneyRequest(json);

            return moneyRequest;
        }
    }
}
