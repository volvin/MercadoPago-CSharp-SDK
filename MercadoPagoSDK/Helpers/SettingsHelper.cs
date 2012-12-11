using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Helpers
{
    public class SettingsHelper
    {
        public static string AccountBalanceUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.AccountBalanceUri;
                #else
                    return Properties.Release.Default.AccountBalanceUri;
                #endif
            }
        }

        public static string ApiBaseUrl
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.ApiBaseUrl;
                #else
                    return Properties.Release.Default.ApiBaseUrl;
                #endif
            }
        }

        public static string AppSecurityUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.AppSecurityUri;
                #else
                    return Properties.Release.Default.AppSecurityUri;
                #endif
            }
        }

        public static string CollectionsUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.CollectionsUri;
                #else
                    return Properties.Release.Default.CollectionsUri;
                #endif
            }
        }

        public static string CollectionsNotificationsUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.CollectionsNotificationsUri;
                #else
                    return Properties.Release.Default.CollectionsNotificationsUri;
                #endif
            }
        }

        public static string CollectionsSearchUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.CollectionsSearchUri;
                #else
                    return Properties.Release.Default.CollectionsSearchUri;
                #endif
            }
        }

        public static string MovementsSearchUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.MovementsSearchUri;
                #else
                    return Properties.Release.Default.MovementsSearchUri;
                #endif
            }
        }

        public static string PreferencesUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.PreferencesUri;
                #else
                    return Properties.Release.Default.PreferencesUri;
                #endif
            }
        }

        public static string UsersUri
        {
            get
            {
                #if SANDBOX
                    return Properties.Sandbox.Default.UsersUri;
                #else
                    return Properties.Release.Default.UsersUri;
                #endif
            }
        } 
    }
}
