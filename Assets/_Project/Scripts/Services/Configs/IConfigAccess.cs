using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Services.Configs
{
    public interface IConfigAccess
    {
        public TConfig GetSingle<TConfig>()
            where TConfig : Object;

        public TConfig GetMultiple<TConfig>(string id)
            where TConfig : Object, IConfig;
        
        public IEnumerable<TConfig> GetAllMultiple<TConfig>() 
            where TConfig : Object, IConfig;
    }
}