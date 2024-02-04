using StaticData;
using UnityEngine;

namespace Services.Configs
{
    public interface IConfigLoader
    {
        public void LoadSingle<TConfig>(string path) 
            where TConfig : Object;        
        
        public void LoadMultiple<TConfig>(string path) 
            where TConfig : Object, IIdConfig;
    }
}