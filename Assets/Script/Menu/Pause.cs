using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused = false;
public void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;        
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;          
        isPaused = false;
    }
}

//if (EventSystem.current.IsPointerOverGameObject())
//{
//    Debug.Log("Clicked on the UI");
//}

