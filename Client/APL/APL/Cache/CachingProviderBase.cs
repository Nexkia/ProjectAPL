using APL.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace APL.Cache
{
    public sealed class CachingProviderBase
    {


        #region Singleton-------------------------------------------------------------
        static readonly CachingProviderBase instance = new CachingProviderBase();
        private CachingProviderBase() { }
        public static CachingProviderBase Instance
        {
            get
            {
                return instance;
            }
        }

      
        #endregion


        private MemoryCache cache = new MemoryCache("CachingProvider");
        private static readonly object locker = new object();

        public void AddItem(string key, object value)
        {
            lock (locker)
            {
                cache.Add(key, value, DateTime.Now.AddMinutes(1));
            }
        }

        public void RemoveItems(string key)
        {
            lock (locker)
            {
                cache.Remove(key);
            }
        }

        public List<Componente> GetItem(string key)
        {
            lock (locker)
            {
                List<Componente> res = (List<Componente>)cache[key];

                //ritorna null se l'elemento non viene trovato
                return res;

            }

        }


    }

}
