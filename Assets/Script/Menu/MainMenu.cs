using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            EventManager.instance.onCrossfadeTransition.Invoke();
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            EventManager.instance.onCrossfadeTransition.Invoke();
        }
    }
}
