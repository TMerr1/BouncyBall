using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private LevelMaster levelMaster;
    [SerializeField]
    private GameUI gameUI;

    [SerializeField]
    private GameObject ball;

    public int lives = 3;

    public void UpdateLives(bool _down)
    {
        if (_down == true)
        {
            lives -= 1;

            if (lives == 0)
            {
                Time.timeScale = 0;
                gameUI.menuButton.SetActive(false);
                gameUI.gameOverMenuPanel.SetActive(true);
            }
            else
            {
                StartCoroutine(RespawnBall());
            }
        }
        else
        {
            lives += 1;
        }

        gameUI.SetLivesAmount(lives);
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(1);
        GameObject _spawnedBall = Instantiate(ball, ball.transform.position, ball.transform.rotation);
        Debug.Log("passing ball");
        levelMaster.ball = _spawnedBall;
    }

    public void DestroyObject(GameObject _ball)
    {
        Object.Destroy(_ball);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
