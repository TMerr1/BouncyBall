using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [HideInInspector]
    public Text text;

    public GameObject menuButton;
    public GameObject inGameMenuPanel;
    public GameObject levelCompleteMenuPanel;
    public GameObject gameOverMenuPanel;

    [HideInInspector]
    public bool levelIsComplete = false;

    public static string powerText = "- - -";

    public static int lives = 3;
    private string livesText = "Lives: ";

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (this.name == "PowerText")
        {
            text.text = powerText;
        }
        else if (this.name == "LivesText")
        {
            text.text = livesText + lives;
        }
    }

    public void SetLivesAmount(int _lives)
    {
        lives = _lives;
    }

    public void SetPowerText(string _newText)
    {
        powerText = _newText;
    }

    public void SetPowerTextBackToDefault()
    {
        powerText = "- - -";
    }
}
