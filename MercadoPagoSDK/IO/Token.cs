using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class Token
    {
        private JSONObject _json;

        public Token()
        {
            string json = "{";
            json += "\"access_token\":\"\",";
            json += "\"expires_in\":0,";
            json += "\"refresh_token\":\"\"";
            json += "\"scope\":\"\"";
            json += "\"token_type\":\"\"";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public Token(JSONObject json) 
        {
            _json = json;
        }

        // todo: como valido que no me asignen cualquier fruta

        public string AccessToken
        {
            get
            {
                return _json.Dictionary["access_token"].String;
            }
            set
            {
                _json.Dictionary["access_token"] = JSONObject.CreateFromString(value);
            }
        }

        public Int16 ExpiresIn
        {
            get
            {
                return Convert.ToInt16(_json.Dictionary["expires_in"].String);
            }
            set
            {
                _json.Dictionary["expires_in"] = JSONObject.CreateFromString(value.ToString());
            }
        }

        public string RefreshToken
        {
            get
            {
                return _json.Dictionary["refresh_token"].String;
            }
            set
            {
                _json.Dictionary["refresh_token"] = JSONObject.CreateFromString(value);
            }
        }

        public string Scope
        {
            get
            {
                return _json.Dictionary["scope"].String;
            }
            set
            {
                _json.Dictionary["scope"] = JSONObject.CreateFromString(value);
            }
        }

        public string TokenType
        {
            get
            {
                return _json.Dictionary["token_type"].String;
            }
            set
            {
                _json.Dictionary["token_type"] = JSONObject.CreateFromString(value);
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
