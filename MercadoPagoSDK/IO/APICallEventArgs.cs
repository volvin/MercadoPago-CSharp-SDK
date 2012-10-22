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

namespace MercadoPagoSDK.IO
{
    /// <summary>
    /// A representation of the API call event. 
    /// </summary>
    public class APICallEventArgs
    {
        /// <summary>
        /// Body field.
        /// </summary>
        public string Body
        {
            get
            {
                return _body;
            }

            set
            {
                _body = value;
            }
        }

        /// <summary>
        /// Response field.
        /// </summary>
        public string Response
        {
            get
            {
                return _response;
            }

            set
            {
                _response = value;
            }
        }

        /// <summary>
        /// Url field.
        /// </summary>
        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }

        #region "Private Members"

        private string _body;
        private string _response;
        private string _url;

        #endregion 
    }
}
