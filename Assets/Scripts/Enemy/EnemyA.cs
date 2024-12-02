using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyA : Enemy
{
    public GameObject bulletPosition;
    bool isShoot = true;
    public float rotateSpeed;
    bool canMove = true;
    Vector3 dir = Vector3.down;
    private void Start()
    {
       
    }
    private void Update()
    {
        if (isShoot)
        {
            StartCoroutine(Shoot());
        }
        Move();
    }
    void Move()
    {
        if (!canMove) { return; }
        transform.position += dir * speed * Time.deltaTime;
    }


    IEnumerator Shoot()
    {
        isShoot = false;
        //타켓 잡기
        Vector3 target = GameManager.Instance.player.transform.position;
        //회전하기

        bulletPosition.transform.up = (bulletPosition.transform.position - target).normalized;
        //총알 발사
        GameObject bulletA = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
        GameObject bulletB = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
        GameObject bulletC= ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
        bulletA.transform.position = bulletPosition.transform.position;
        bulletB.transform.position = bulletPosition.transform.position;
        bulletC.transform.position = bulletPosition.transform.position;
        bulletA.transform.rotation = bulletPosition.transform.rotation * Quaternion.Euler(0, 0, 30);
        bulletB.transform.rotation = bulletPosition.transform.rotation;
        bulletC.transform.rotation = bulletPosition.transform.rotation * Quaternion.Euler(0, 0, -30);
        bulletA.GetComponent<Rigidbody2D>().AddForce(bulletA.transform.up * -7, ForceMode2D.Impulse);
        bulletB.GetComponent<Rigidbody2D>().AddForce(bulletB.transform.up * -7, ForceMode2D.Impulse);
        bulletC.GetComponent<Rigidbody2D>().AddForce(bulletC.transform.up * -7, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        isShoot = true;
    }
}
