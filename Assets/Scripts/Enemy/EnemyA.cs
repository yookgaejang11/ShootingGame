using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public Transform firepoint;
    public float attackDelay;

    private void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    IEnumerator Attack()
    {
        while (true)
        {
            Vector3 dir = GameManager.Instance.player.transform.position - firepoint.position;
            firepoint.up = dir;
            firepoint.Rotate(Vector3.forward * -15);
            for(int i = 0; i < 3; i++)
            {
                GameObject bullet = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
                bullet.transform.position = firepoint.transform.position;
                bullet.transform.rotation = firepoint.transform.rotation;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 5, ForceMode2D.Impulse);

                firepoint.Rotate(Vector3.forward * 15);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
}
