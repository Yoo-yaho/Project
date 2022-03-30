using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity = Vector2.down * speed;
    }

    void OnDamaged(int dmg)
    {
        gameObject.layer = 9;

        spriteRenderer.material.color = new Color(1.8f, 1.8f, 1.8f);

        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Invoke("OffDamaged", 0.2f);
    }

    void OffDamaged()
    {
        gameObject.layer = 8;

        spriteRenderer.material.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnDamaged(bullet.dmg);
        }
             
    }
}
