using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Services.Configs
{
    public interface IConfigAccess
    {
        public TConfig GetSingle<TConfig>()
            where TConfig : Object, ISingleConfig;

        public TConfig GetMultiple<TConfig>(string id)
            where TConfig : Object, IMultipleConfig;
        
        public IEnumerable<TConfig> GetAllMultiple<TConfig>() 
            where TConfig : Object, IMultipleConfig;
    }
}