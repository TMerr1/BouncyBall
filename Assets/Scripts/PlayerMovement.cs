using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public int moveSpeed;

    private float horizontal;

    private float speedEffectTimer = 9999;
    private bool slowingPlayer;

    private Rigidbody2D rb;

    public Text powerText;
    private GameUI textScript;

    [SerializeField]
    private GameMaster gameMaster;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        textScript = powerText.GetComponent<GameUI>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            float xMove = horizontal * moveSpeed;
            rb.MovePosition(new Vector2((transform.position.x + horizontal * moveSpeed * Time.deltaTime), -3));
        }

        if (speedEffectTimer != 9999 && speedEffectTimer > 0)
        {
            speedEffectTimer -= Time.deltaTime;
        }
        else if (speedEffectTimer <= 0)
        {
            StopSpeedChanger(slowingPlayer);
            speedEffectTimer = 9999;
        }
    }

    public void PlayerSpeedChanger(bool _slowPlayer)
    {
        if (_slowPlayer == true)
        {
            speedEffectTimer = 10;
            moveSpeed /= 2;
            slowingPlayer = true;
        }
        else
        {
            speedEffectTimer = 10;
            moveSpeed *= 2;
            slowingPlayer = false;
        }
    }

    void StopSpeedChanger(bool _playerIsBeingSlowed)
    {
        if(_playerIsBeingSlowed == true)
        {
            moveSpeed *= 2;
        }
        else
        {
            moveSpeed /= 2;
        }

        textScript.SetPowerTextBackToDefault();
    }
}
