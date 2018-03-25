using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour
{

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(new Vector2(0, -200));
    }
}
