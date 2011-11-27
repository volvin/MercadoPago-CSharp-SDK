using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class PaymentChoices
    {
        private JSONObject _json;

        public PaymentChoices()
        {
            string json = "{";
            json += "\"excluded_payment_methods\":[],";
            json += "\"excluded_payment_types\":[]";
            json += "}";
            _json = JSONObject.CreateFromString(json);
        }

        public PaymentChoices(JSONObject json)
        {
            _json = json;
        }

        // todo: como valido que no me asignen cualquier fruta

        public Int16 AllowedInstallments
        {
            get
            {
                try
                {
                    return Convert.ToInt16(_json.Dictionary["installments"].String);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    _json.Dictionary["installments"] = JSONObject.CreateFromString(value.ToString());
                }
                catch (KeyNotFoundException)
                {
                    _json.Dictionary.Add("installments", JSONObject.CreateFromString(value.ToString()));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public IdList ExcludedMethods
        {
            get
            {
                return new IdList(_json.Dictionary["excluded_payment_methods"]);
            }
            set
            {
                _json.Dictionary["excluded_payment_methods"] = value.ToJSON();
            }
        }

        public IdList ExcludedTypes
        {
            get
            {
                return new IdList(_json.Dictionary["excluded_payment_types"]);
            }
            set
            {
                _json.Dictionary["excluded_payment_types"] = value.ToJSON();
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
