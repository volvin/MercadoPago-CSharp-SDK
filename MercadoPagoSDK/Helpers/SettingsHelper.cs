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
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.AccountBalanceUri;
                    #else
                        return Properties.Release.Default.AccountBalanceUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.AccountBalanceUri;                    
                    }
                    else
                    {
                        return Properties.Release.Default.AccountBalanceUri;                    
                    }
                }
            }
        }

        public static string ApiBaseUrl
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.ApiBaseUrl;
                    #else
                        return Properties.Release.Default.ApiBaseUrl;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.ApiBaseUrl;
                    }
                    else
                    {
                        return Properties.Release.Default.ApiBaseUrl;
                    }
                }
            }
        }

        public static string AppSecurityUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.AppSecurityUri;
                    #else
                        return Properties.Release.Default.AppSecurityUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.AppSecurityUri;
                    }
                    else
                    {
                        return Properties.Release.Default.AppSecurityUri;
                    }
                }
            }
        }

        public static string CollectionsUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.CollectionsUri;
                    #else
                        return Properties.Release.Default.CollectionsUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.CollectionsUri;
                    }
                    else
                    {
                        return Properties.Release.Default.CollectionsUri;
                    }
                }
            }
        }

        public static string CollectionsNotificationsUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.CollectionsNotificationsUri;
                    #else
                        return Properties.Release.Default.CollectionsNotificationsUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.CollectionsNotificationsUri;
                    }
                    else
                    {
                        return Properties.Release.Default.CollectionsNotificationsUri;
                    }
                }
            }
        }

        public static string CollectionsSearchUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.CollectionsSearchUri;
                    #else
                        return Properties.Release.Default.CollectionsSearchUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.CollectionsSearchUri;
                    }
                    else
                    {
                        return Properties.Release.Default.CollectionsSearchUri;
                    }
                }
            }
        }

        public static string MovementsSearchUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.MovementsSearchUri;
                    #else
                        return Properties.Release.Default.MovementsSearchUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.MovementsSearchUri;
                    }
                    else
                    {
                        return Properties.Release.Default.MovementsSearchUri;
                    }
                }
            }
        }

        public static string PreferencesUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.PreferencesUri;
                    #else
                        return Properties.Release.Default.PreferencesUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.PreferencesUri;
                    }
                    else
                    {
                        return Properties.Release.Default.PreferencesUri;
                    }
                }
            }
        }

        public static string UsersUri
        {
            get
            {
                if (Environment.Scope == Environment.Scopes.Default)
                {
                    #if SANDBOX
                        return Properties.Sandbox.Default.UsersUri;
                    #else
                        return Properties.Release.Default.UsersUri;
                    #endif
                }
                else
                {
                    if (Environment.Scope == Environment.Scopes.Sandbox)
                    {
                        return Properties.Sandbox.Default.UsersUri;
                    }
                    else
                    {
                        return Properties.Release.Default.UsersUri;
                    }
                }
            }
        } 
    }
}
