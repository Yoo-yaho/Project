using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Bullet : MonoBehaviour
{
    public float distance;
    public int dmg;
    public LayerMask isLayer;

    void Awake()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        rigid.gravityScale = 0;
        box.isTrigger = true;

        Invoke("DestroyBullet", 2);
    }

    private void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);

        if (ray.collider != null)
        {
            if (ray.collider.tag == "MiddleBoss")
            {
                Debug.Log("ИэСп");
            }
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MiddleBoss" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}