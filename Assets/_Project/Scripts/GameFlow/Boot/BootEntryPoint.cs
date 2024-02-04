using Additional.Constants;
using Services.Configs;
using Services.Save;
using StaticData;
using UnityEngine.SceneManagement;

namespace GameFlow.Boot
{
    public class BootEntryPoint
    {
        private readonly IConfigLoader _configLoader;
        private readonly SaveService _saveService;


        public BootEntryPoint(
            IConfigLoader configLoader,
            SaveService saveService)
        {
            _configLoader = configLoader;
            _saveService = saveService;
        }

        public void Execute()
        {
            LoadSaveData();
            LoadStaticData();
            LoadMainMenu();
        }

        private void LoadSaveData()
            => _saveService.Load();

        private void LoadMainMenu()
            => SceneManager.LoadScene(SceneNames.MainMenu);

        private void LoadStaticData()
        {
            _configLoader.LoadSingle<PlayerConfig>(StaticDataPaths.PlayerConfig);
        }
    }
}