using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class MiddleBoss : MonoBehaviour
{
    Rigidbody rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public int health;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnDamaged(bullet.dmg);
        }
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
}
