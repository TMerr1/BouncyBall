using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public static int xMoveSpeed = 0;
    public static int yMoveSpeed = -350;

    public static int playerBounceForce = 300;
    public static float forceEffectTimer = 9999;
    public static bool slowBall = false;
    public static bool fastBall = false;
    public static bool speedBallBackUp = false;
    public static bool slowBallBackDown = false;

    private static Rigidbody2D rb;

    public Text powerText;
    private GameUI textScript;

    public int moveDelay;

    private GameMaster gameMaster;

    [HideInInspector]
    public LevelSpawner levelSpawner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        textScript = powerText.GetComponent<GameUI>();

        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        }
    }

    void Start()
    {
        StartCoroutine(MoveDelay());
    }

    private void Update()
    {
        if (forceEffectTimer != 9999 && forceEffectTimer > 0)
        {
            forceEffectTimer -= Time.deltaTime;
        }
        else if (forceEffectTimer <= 0)
        {
            if (playerBounceForce == 100)
            {
                StopForceEffect(true);
            }
            else
            {
                StopForceEffect(false);
            }

            forceEffectTimer = 9999;
        }

        if (transform.position.y <= -3)
        {
            gameMaster.UpdateLives(true);
            gameMaster.DestroyObject(this.gameObject);
        }
    }

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(moveDelay);
        rb.AddForce(new Vector2(xMoveSpeed, yMoveSpeed));
    }

    public void PlayerBounce(float _force)
    {
        if (slowBall == true)
        {
            rb.AddForce(new Vector2(playerBounceForce * _force, -200));
            slowBall = false;
        }
        else if (speedBallBackUp == true)
        {
            rb.AddForce(new Vector2(playerBounceForce * _force, 200));
            speedBallBackUp = false;
        }
        else if (fastBall == true)
        {
            rb.AddForce(new Vector2(playerBounceForce * _force, 200));
            fastBall = false;
        }
        else if (slowBallBackDown == true)
        {
            rb.AddForce(new Vector2(playerBounceForce * _force, -200));
            slowBallBackDown = false;
        }
        else
        {
            rb.AddForce(new Vector2(playerBounceForce * _force, 0));
        }
    }

    public void PlayerBounceForceChanger(bool _slowBall)
    {
        if (_slowBall == true)
        {
            slowBall = true;
            forceEffectTimer = 10;
            playerBounceForce = 100;
        }
        else
        {
            fastBall = true;
            forceEffectTimer = 10;
            playerBounceForce = 500;
        }
    }

    void StopForceEffect(bool _slowBall)
    {
        if (_slowBall == true)
        {
            Debug.Log("stopping slow ball effect");
            playerBounceForce = 300;
            speedBallBackUp = true;
        }
        else
        {
            Debug.Log("stopping fast ball effect");
            playerBounceForce = 300;
            slowBallBackDown = true;
        }

        textScript.SetPowerTextBackToDefault();
    }
}
