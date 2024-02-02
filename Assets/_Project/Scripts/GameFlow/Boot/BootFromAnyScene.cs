#if UNITY_EDITOR

using System.Linq;
using Additional.Constants;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameFlow.Boot
{
    [InitializeOnLoad]
    public class BootFromAnyScene
    {
        static BootFromAnyScene()
        {
            EditorApplication.playModeStateChanged += Run;
        }

        private static void Run(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode)
                return;

            EditorApplication.playModeStateChanged -= Run;
            Scene currentScene = SceneManager.GetActiveScene();
            
            if (currentScene.name == SceneNames.Boot)
                return;
            
            if (EditorBuildSettings.scenes.Any(s => s.path == currentScene.path))
                SceneManager.LoadScene(SceneNames.Boot);
        }
    }
}

#endif