using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.SessionState;


namespace QWE.ASDF.WebAdapterHelper
{
    public class RemoteServiceUtils
    {
        public static void RegisterSessionKeys(IDictionary<string, Type> knownTypes)
        {
            knownTypes.Add("givenusername", typeof(string));
            knownTypes.Add("frameworksession", typeof(string));
            knownTypes.Add("coresession", typeof(string));
        }

        //public static void RemoveSessionkeysFromFrameWorkApp(NameObjectCollectionBase.KeysCollection sessionKeys)
        //how can the session back when user comes back lola.
        public static void RemoveSessionkeysFromFrameWorkApp(NameObjectCollectionBase.KeysCollection sessionKeys)
        {
            var keystoRemove = new List<string>();
            //COA
            foreach (string key in sessionKeys)
            {
                if (key.StartsWith("CurrentUserAuthenticationQuestion"))
                {
                    keystoRemove.Add(key);
                }
            }

            foreach (string key in keystoRemove)
            {
                System.Web.HttpContext.Current.Session.Remove(key);
            }
        }

        //Temporarily add Dyanamic Session users here in this below
        public static void AddDynamicUsers(IDictionary<string, Type> knownTypes)
        {
           

        }
    }
}
