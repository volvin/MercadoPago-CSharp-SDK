/*
 * Copyright 2010 Facebook, Inc.
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
using System.Text;

namespace MercadoPagoSDK
{
    public class RESTAPIException : Exception
    {
        public string Cause { get; set; }
        public string Error { get; set; }
        public int Status { get; set; }

        public RESTAPIException(int status, string error, string msg, string cause = "")
            : base(msg) 
        {
            Cause = cause;
            Error = error;
            Status = status;
        }

        public override string ToString()
        {
            return Status.ToString() + ": " + Error + "; Message: " + base.ToString() + "; Cause: " + Cause;
        }

        public RESTAPIException()
        { }
    }
}
