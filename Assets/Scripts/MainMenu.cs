using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneMaster sceneMaster;

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
