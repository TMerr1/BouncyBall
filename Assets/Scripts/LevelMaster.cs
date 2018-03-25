using UnityEngine;
using System.Collections;

public class LevelMaster : MonoBehaviour
{


    [SerializeField]
    private SceneMaster sceneMaster;
    [SerializeField]
    private GameUI gameUI;

    public GameObject spareBall;
    
    [Space (3, order = 0)]
    [Header("Levels")]
    public GameObject[] levels;

    private int levelToLoad;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject ball;
    [HideInInspector]
    public GameObject[] tiles;


    void Start()
    {
        levelToLoad = sceneMaster.levelToLoadSM;
        StartLevel();
    }

    public void StartLevel()
    {
        levels[levelToLoad].SetActive(true);
    }

    public void CleanOutEntireLevel()
    {
        Object.Destroy(ball);
        Object.Destroy(player);
        levels[levelToLoad].SetActive(false);

        for (int i = 0; i < tiles.Length; i++)
        {
            Object.Destroy(tiles[i]);
        }
    }

    /*
     * 
     *      Menu Methods
     * 
     */

    public void RestartLevelFromInGameMenuPanel()
    {
        levels[levelToLoad].SetActive(false);
        CleanOutEntireLevel();
        Time.timeScale = 1;
        levels[levelToLoad].SetActive(true);
    }

    public void RestartLevelFromGameOverMenuPanel()
    {
        levels[levelToLoad].SetActive(false);
        CleanOutEntireLevel();
        Time.timeScale = 1;
        levels[levelToLoad].SetActive(true);
    }

    public void RestartLevelFromLevelCompleteMenuPanel()
    {
        levels[levelToLoad].SetActive(false);
        CleanOutEntireLevel();
        Time.timeScale = 1;
        levels[levelToLoad].SetActive(true);
    }

    public void StartNextLevelFromLevelCompleteMenuPanel()
    {
        levels[levelToLoad].SetActive(false);
        CleanOutEntireLevel();
        Time.timeScale = 1;
        levelToLoad += 1;
        levels[levelToLoad].SetActive(true);
    }
}
