using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{

    [SerializeField]
    private GameUI gameUI;

    public GameObject ball;

    private float scaleEffectTimer = 9999;

    private GameObject[] guns;
    private GameObject gun;
    private bool canShoot = false;

    public GameObject bullet;
    public Transform firepoint0;
    public Transform firepoint1;

    private void Awake()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
    }

    private void Start()
    {
        gun.SetActive(false);
    }

    private void Update()
    {
        if (scaleEffectTimer != 9999 && scaleEffectTimer > 0)
        {
            scaleEffectTimer -= Time.deltaTime;
        }
        else if (scaleEffectTimer <= 0)
        {
            StopScalePlayerEffect();
            scaleEffectTimer = 9999;
        }

        if (canShoot == true && Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, firepoint0.position, firepoint0.rotation);
            Instantiate(bullet, firepoint1.position, firepoint1.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {

            BallMovement ballMoveScript = col.gameObject.GetComponent<BallMovement>();

            Vector2 hitpoint = new Vector2(col.transform.position.x - transform.position.x,
                col.transform.position.y - transform.position.y);

            ballMoveScript.PlayerBounce(hitpoint.x);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.CompareTag("SlowPlayerPickup"))
        {
            gameUI.SetPowerText("Slow Player");
            GetComponent<PlayerMovement>().PlayerSpeedChanger(true);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.CompareTag("FastPlayerPickup"))
        {
            gameUI.SetPowerText("Fast Player");
            GetComponent<PlayerMovement>().PlayerSpeedChanger(false);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.CompareTag("ShortPlayerPickup"))
        {
            gameUI.SetPowerText("Short Player");
            ScalePlayer(true);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.CompareTag("LongPlayerPickup"))
        {
            gameUI.SetPowerText("Long Player");
            ScalePlayer(false);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.CompareTag("SlowBallPickup"))
        {
            gameUI.SetPowerText("Slow Ball");
            ball.GetComponent<BallMovement>().PlayerBounceForceChanger(true);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.CompareTag("FastBallPickup"))
        {
            gameUI.SetPowerText("Fast Ball");
            ball.GetComponent<BallMovement>().PlayerBounceForceChanger(false);
            Object.Destroy(trig.gameObject);
        }
        else if (trig.name.Contains("Gun"))
        {
            gameUI.SetPowerText("Gun");
            StartGun();
            Object.Destroy(trig.gameObject);
        }
    }

    void ScalePlayer(bool _smallPlayer)
    {
        if (_smallPlayer == true)
        {
            scaleEffectTimer = 10;
            this.transform.localScale = new Vector3(0.6f, 0.2f, 1);
        }
        else
        {
            scaleEffectTimer = 10;
            this.transform.localScale = new Vector3(1.8f, 0.2f, 1);
        }
    }

    void StopScalePlayerEffect()
    {
        this.transform.localScale = new Vector3(1.2f, 0.2f, 1);
        gameUI.SetPowerTextBackToDefault();
    }

    void StartGun()
    {
        gun.SetActive(true);
        canShoot = true;
        StartCoroutine(StopGun());
    }

    IEnumerator StopGun()
    {
        yield return new WaitForSeconds(5);
        gun.SetActive(false);
        canShoot = false;
    }
}