using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : Enemy
{
    public Transform firepoint;
    bool canMove = true;

    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (!canMove) { return; }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void Attack()
    {
        int bulletNum = 20;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
            bullet.transform.position = firepoint.transform.position;
            bullet.transform.rotation = firepoint.transform.rotation;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 7, ForceMode2D.Impulse);

            firepoint.Rotate((360 / bulletNum) * Vector3.forward);
        }
    }
    IEnumerator Shoot()
    {
        Debug.Log(1);
        yield return new WaitUntil(() => (transform.position.y <= 2.1f && transform.position.y >= 1.9f));
        canMove = false;
        for(int i = 0; i < 5; i++)
        {
            Attack();
            firepoint.Rotate(Vector3.forward * 9);
            yield return new WaitForSeconds(0.5f);
        }
        canMove = true;
    }
}
