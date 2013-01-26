using System;
using System.Collections.Generic;

namespace tombola.eventstreamer.proxy
{
    //this needs to be stored in redis at some point and retreived from there
    public sealed class IncrementalKeyStore
    {
        private static readonly Lazy<IncrementalKeyStore> lazy = new Lazy<IncrementalKeyStore>(() => new IncrementalKeyStore());

        public static IncrementalKeyStore Instance { get { return lazy.Value; } }

        private HashSet<string> KeyNames;

        private IncrementalKeyStore()
        {
            KeyNames = new HashSet<string>();
        }

        public bool AddKeyNameIfNeeded(string key)
        {
            return KeyNames.Add(key);
        }

        public HashSet<string> GetKeys()
        {
            return KeyNames;
        }
    }

}
