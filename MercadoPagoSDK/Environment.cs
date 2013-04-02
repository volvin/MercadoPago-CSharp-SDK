using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK
{
    public static class Environment
    {
        public enum Scopes
        {
            Default,
            Live,
            Sandbox            
        }

        public static Scopes Scope = Scopes.Default;
    }
}
