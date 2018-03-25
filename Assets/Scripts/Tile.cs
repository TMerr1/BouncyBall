using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public GameObject level;

    private SpriteRenderer spriteRenderer;

    public GameObject pickupItem;

    public int tileHealth;

    private void Awake()
    {
        level = GameObject.FindGameObjectWithTag("Level");

        if (this.name.Contains("Strong"))
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (tileHealth == 0)
        {
            DestroyTile();
        }
    }

    void DestroyTile()
    {
        if (this.name.Contains("Basic"))
        {
            level.GetComponent<LevelSpawner>().CheckIfLastTile();
            Object.Destroy(this.gameObject);
        }
        else
        {
            level.GetComponent<LevelSpawner>().CheckIfLastTile();
            Instantiate(pickupItem, transform.position, transform.rotation);
            Object.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        tileHealth -= 1;

        if (this.name.Contains("Strong"))
        {
            if (tileHealth == 1)
            {
                spriteRenderer.color = new Color(1, 0.9572389f, 0.6556f, 1);
            }
            else if (tileHealth == 2)
            {
                spriteRenderer.color = new Color(1, 0.6805682f, 0.3160f, 1);
            }
            else if (tileHealth == 3)
            {
                spriteRenderer.color = new Color(1, 0.4571667f, 0.1179f, 1);
            }
        }
    }
}
