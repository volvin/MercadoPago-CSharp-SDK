using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class User
    {
        private JSONObject _json;

        public User()
        {
            string json = "{";
            json += "\"email\":\"\",";
            json += "\"name\":\"\",";
            json += "\"surname\":\"\"";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public User(JSONObject json)
        {
            _json = json;
        }

        // todo: como valido que no me asignen cualquier fruta

        public string Email
        {
            get
            {
                return _json.Dictionary["email"].String;
            }
            set
            {
                _json.Dictionary["email"] = JSONObject.CreateFromString(value);
            }
        }

        public string Name
        {
            get
            {
                return _json.Dictionary["name"].String;
            }
            set
            {
                _json.Dictionary["name"] = JSONObject.CreateFromString(value);
            }
        }

        public string Surname
        {
            get
            {
                return _json.Dictionary["surname"].String;
            }
            set
            {
                _json.Dictionary["surname"] = JSONObject.CreateFromString(value);
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
