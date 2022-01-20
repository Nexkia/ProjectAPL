using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Diagnostics;
using APL.Data;

namespace APL.Cache
{
    public  class CachingProviderBase
    {
                public CachingProviderBase()
                {

                }

            #region Singleton
            public static CachingProviderBase Instance
            {
                get
                {
                    return Nested.instance;
                }
            }

            class Nested
            {
                // Explicit static constructor to tell C# compiler
                // not to mark type as beforefieldinit
                static Nested()
                {
                }
                internal static readonly CachingProviderBase instance = new CachingProviderBase();
            }
            #endregion

            protected MemoryCache cache = new MemoryCache("CachingProvider");

            static readonly object locker = new object();

            public  void AddItem(string key, object value)
            {
                lock (locker)
                {
                    cache.Add(key, value, DateTime.Now.AddMinutes(1));
                }
            }

            public  void RemoveItems(string key)
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
