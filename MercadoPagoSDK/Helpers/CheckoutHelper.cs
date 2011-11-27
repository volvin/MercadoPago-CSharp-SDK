using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Script.Serialization;

namespace MercadoPagoSDK
{
    public class CheckoutHelper
    {	
        // todo: to app.config
        public static string API_BASE_URL = "https://api.mercadolibre.com";
        public static string APP_SECURITY_PATH = "/oauth/token";
        public static string PREFERENCE_PATH = "/checkout/preferences";

        private RESTAPI api;

        public string AccessToken 
        {
            get
            {
                return api.AccessToken;
            }
            set
            {
                api.AccessToken = value;
            }
        }

        public CheckoutHelper()
        {
            api = new RESTAPI(new Uri(API_BASE_URL));
        }

        public Token CreateAccessToken(string clientId, string clientSecret)
		{
		    // Set client credential
            Credential credential = new Credential();
			credential.ClientId = clientId;
			credential.ClientSecret = clientSecret;
			credential.GrantType = "client_credentials";

            // Create token
            JSONObject json = api.Post(APP_SECURITY_PATH, credential.ToJSON(), ContentType.HTTP);
            Token token = new Token(json);

            return token;
        }

        public Preference CreatePreference(Preference preference)
        {
            JSONObject json = api.Post(PREFERENCE_PATH, preference.ToJSON(), ContentType.JSON);
            preference = new Preference(json);

            return preference;
		}
		
		public Preference UpdatePreference(Preference preference)
		{
		    return null;
		}
		
		public Preference GetPreference(string preferenceId)
		{
			return null;
		}
		
		public void DeletePreference(string preferenceId)
		{}
    }
}
