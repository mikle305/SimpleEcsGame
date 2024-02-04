using Additional.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LoadLevelButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(SceneNames.Level));
        }
    }
}