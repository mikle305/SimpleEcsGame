using Leopotam.EcsLite;
using Services.Configs;
using Services.Save;

namespace GamePlay.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        private readonly IConfigLoader _configLoader;
        private readonly SaveService _saveService;


        public GameInitSystem(
            IConfigLoader configLoader,
            SaveService saveService)
        {
            _configLoader = configLoader;
            _saveService = saveService;
        }
        
        public void Init(IEcsSystems systems)
        {
            LoadSaveData();
            LoadStaticData();
        }

        private void LoadSaveData()
            => _saveService.Load();

        private void LoadStaticData()
        {
            
        }
    }
}