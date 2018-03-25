using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField]
    private GameMaster gameMaster;
    [SerializeField]
    private LevelMaster levelMaster;
    [SerializeField]
    private GameUI gameUI;

    public GameObject player;
    public GameObject ball;

    public GameObject[] tiles;
    public Vector3[] spawnInstances;

    private static int tilesLeft;

    private GameObject[] spawnedTiles;

    void OnEnable()
    {
        Debug.Log("here");
        gameMaster.lives = 3;
        gameUI.SetLivesAmount(3);
        gameUI.menuButton.SetActive(true);
        tilesLeft = spawnInstances.Length;
        spawnedTiles = new GameObject[spawnInstances.Length];
        StartCoroutine(SpawnLevel());
    }

    IEnumerator SpawnLevel()
    {
        yield return new WaitForSeconds(1);

        GameObject _spawnedPlayer = Instantiate(player, player.transform.position, player.transform.rotation);
        GameObject _spawnedBall = Instantiate(ball, ball.transform.position, ball.transform.rotation);

        levelMaster.player = _spawnedPlayer;
        levelMaster.ball = _spawnedBall;

        for (int i = 0; i < spawnInstances.Length; i++)
        {
            int objectID = (int)spawnInstances[i].x;
            GameObject toSpawn = tiles[objectID];
            GameObject _spawnedTile = Instantiate(toSpawn, new Vector2(spawnInstances[i].y, spawnInstances[i].z), transform.rotation);
            spawnedTiles[i] = _spawnedTile;
        }

        levelMaster.tiles = spawnedTiles;
    }

    public void CheckIfLastTile()
    {
        tilesLeft -= 1;

        if (tilesLeft <= 0)
        {
            levelMaster.CleanOutEntireLevel();
            gameUI.menuButton.SetActive(false);
            gameUI.levelCompleteMenuPanel.SetActive(true);
        }
    }
}

