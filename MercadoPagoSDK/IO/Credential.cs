using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class Credential
    {
        private JSONObject _json;

        public Credential()
        {
            string json = "{";
            json += "\"client_id\":\"\",";
            json += "\"client_secret\":\"\",";
            json += "\"grant_type\":\"\"";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public Credential(JSONObject json)
        {
            _json = json;
        }

        public string ClientId
        {
            get 
            {
                return _json.Dictionary["client_id"].String;
            }
            set 
            {
                _json.Dictionary["client_id"] = JSONObject.CreateFromString(value);
            }
        }

        public string ClientSecret
        {
            get 
            {
                return _json.Dictionary["client_secret"].String;
            }
            set 
            {
                _json.Dictionary["client_secret"] = JSONObject.CreateFromString(value);
            }
        }

        public string GrantType 
        {
            get 
            {
                return _json.Dictionary["grant_type"].String;
            }
            set 
            {
                _json.Dictionary["grant_type"] = JSONObject.CreateFromString(value);
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
