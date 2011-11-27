using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public class Preference
    {
        private JSONObject _json;

        public Preference()
        {
            string json = "{";
            json += "back_urls:" + new ResponseUrls().ToJSON().ToString() + ",";
            json += "external_reference:\"\",";
            json += "items:[],";
            json += "payer:" + new User().ToJSON().ToString() + ",";
            json += "payment_methods:" + new PaymentChoices().ToJSON().ToString();
            json += "}";

            _json = JSONObject.CreateFromString(json);
        }

        public Preference(JSONObject json)
        {
            _json = json;
        }

        public DateTime ActivationDate
        {
            get
            {
                return Convert.ToDateTime(_json.Dictionary["expiration_date_from"].String);
            }
            set
            {
                try
                {
                    _json.Dictionary["expiration_date_from"] = JSONObject.CreateFromString(value.ToString("yyyy-MM-ddThh:mm:ss.fffzzzz"));
                }
                catch (KeyNotFoundException)
                {
                    _json.Dictionary.Add("expiration_date_from", JSONObject.CreateFromString(value.ToString("yyyy-MM-ddThh:mm:ss.fffzzzz")));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ResponseUrls BackUrls
        {
            get
            {
                return new ResponseUrls(_json.Dictionary["back_urls"]);
            }
            set
            {
                _json.Dictionary["back_urls"] = value.ToJSON();
            }
        }

        public Int32 CollectorId
        {
            get
            {
                return Convert.ToInt32(_json.Dictionary["collector_id"].String);
            }
        }

        public PaymentChoices CustomPaymentChoices
        {
            get
            {
                return new PaymentChoices(_json.Dictionary["payment_methods"]);
            }
            set
            {
                _json.Dictionary["payment_methods"] = value.ToJSON();
            }
        }

        public DateTime DateCreated
        {
            get 
            {
                return Convert.ToDateTime(_json.Dictionary["date_created"].String);
            }
        }
        
        public DateTime ExpirationDate
        {
            get 
            {
                return Convert.ToDateTime(_json.Dictionary["expiration_date_to"].String);
            }
            set 
            {
                try
                {
                    _json.Dictionary["expiration_date_to"] = JSONObject.CreateFromString(value.ToString("yyyy-MM-ddThh:mm:ss.fffzzzz"));
                }
                catch (KeyNotFoundException)
                {
                    _json.Dictionary.Add("expiration_date_to", JSONObject.CreateFromString(value.ToString("yyyy-MM-ddThh:mm:ss.fffzzzz")));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public bool Expires
        {
            get
            {
                return Convert.ToBoolean(_json.Dictionary["expires"].String);            
            }
            set 
            {
                try
                {
                    _json.Dictionary["expires"] = JSONObject.CreateFromString(value.ToString());
                }
                catch (KeyNotFoundException)
                {
                    _json.Dictionary.Add("expires", JSONObject.CreateFromString(value.ToString()));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public string ExternalReference
        {
            get
            {
                return _json.Dictionary["external_reference"].String;
            }
            set
            {
                _json.Dictionary["external_reference"] = JSONObject.CreateFromString(value);
            }
        }

        public string Id
        {
            get
            {
                return _json.Dictionary["id"].String;
            }
            set
            {
                _json.Dictionary["id"] = JSONObject.CreateFromString(value);
            }
        }
        public string InitPoint
        {
            get
            {
                return _json.Dictionary["init_point"].String;
            }
        }

        public ItemList Items
        {
            get
            {
                return new ItemList(_json.Dictionary["items"]);
            }
            set
            {
                _json.Dictionary["items"] = value.ToJSON();
            }
        }

        public User Payer
        {
            get
            {
                return new User(_json.Dictionary["payer"]);
            }
            set
            {
                _json.Dictionary["payer"] = value.ToJSON();
            }
        }

        public Int32 SponsorId
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_json.Dictionary["sponsor_id"].String);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public Int16 SubscriptionPlanId
        {
            get
            {
                try
                {
                    return Convert.ToInt16(_json.Dictionary["subscription_plan_id"].String);
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
                    _json.Dictionary["subscription_plan_id"] = JSONObject.CreateFromString(value.ToString());
                }
                catch (KeyNotFoundException)
                {
                    _json.Dictionary.Add("subscription_plan_id", JSONObject.CreateFromString(value.ToString()));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public JSONObject ToJSON()
        {
            return _json;
        }
    }
}
