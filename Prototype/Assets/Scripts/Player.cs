using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 8.0f;
    public int Power;

    Rigidbody2D rigid;

    public GameObject bullet1;

    [SerializeField] float ShootDelay;
    public float MaxDelay;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Reload();
    }

    void Move()
    {
        float xputs = Input.GetAxisRaw("Horizontal");
        float yputs = Input.GetAxisRaw("Vertical");
        float xSpeed;
        float ySpeed;

        xSpeed = xputs * Speed;
        ySpeed = yputs * Speed;

        Vector3 velo = new Vector3(xSpeed, ySpeed, 0);

        rigid.velocity = velo;
    }
    void Fire()
    {

        if (ShootDelay < MaxDelay)
            return;

        if (Input.GetButton("Fire1"))
        {
            if (Power == 1)
            {
                GameObject Bullet = Instantiate(bullet1, transform.position, transform.rotation);
                Rigidbody2D Brigid = Bullet.GetComponent<Rigidbody2D>();
                Brigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
            else if (Power == 2)
            {
                GameObject BulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject BulletR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D BrigidL = BulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidR = BulletR.GetComponent<Rigidbody2D>();
                BrigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
            else if (Power == 3)
            {
                GameObject BulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject BulletR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, transform.rotation);
                GameObject BulletCR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, Quaternion.Euler(new Vector3(0, 0, 45)));
                GameObject BulletCL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, Quaternion.Euler(new Vector3(0, 0, -45)));
                Rigidbody2D BrigidL = BulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidR = BulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidCR = BulletCR.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidCL = BulletCL.GetComponent<Rigidbody2D>();
                BrigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidCR.AddForce(Vector2.one * 10, ForceMode2D.Impulse);
                BrigidCL.AddForce((Vector2.up + Vector2.left) * 10, ForceMode2D.Impulse);
            }

            ShootDelay = 0;
        }
    }

   

    void Reload()
    {
        ShootDelay += Time.deltaTime;
    }
}