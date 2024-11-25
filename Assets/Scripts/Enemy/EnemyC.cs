using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyC : Enemy
{
    public GameObject bulletPosition;
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
        if(!canMove) {return;}
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void Attack()
    {

        int bulletNum = 20;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab);
            bullet.transform.position = bulletPosition.transform.position;
            bullet.transform.rotation = bulletPosition.transform.rotation;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 7,ForceMode2D.Impulse);

            bulletPosition.transform.Rotate((360 / bulletNum) * Vector3.forward);

        }
        /**for(int i = 0; i < 360; i += 20)
        {
            GameObject circleBullet = Instantiate(enemyBulletPrefab);
            bulletPosition.transform.rotation = Quaternion.Euler(0,0,i);
            circleBullet.transform.rotation = Quaternion.Euler(0, 0, i);
            circleBullet.transform.position = transform.position;
            circleBullet.GetComponent<Rigidbody2D>().AddForce(bulletPosition.transform.up * 7,ForceMode2D.Impulse);

        }**/
    }

    IEnumerator Shoot()
    {
        Debug.Log("실행");
        yield return new WaitUntil(() => (transform.position.y <= 2.1f && transform.position.y >= 1.9f));//특정 조건이 만족될때 까지 기다리기 Approximately = 근사치 람다식 = 함수를 줄일대로 줄인거 (함수이름, return 값)
        canMove = false;
        //총알 발사
        for (int i = 0; i < 5; i++)
        {
            Attack();
            bulletPosition.transform.Rotate(Vector3.forward * 9);
            yield return new WaitForSeconds(0.75f);
        }
        canMove = true;
    }
}
