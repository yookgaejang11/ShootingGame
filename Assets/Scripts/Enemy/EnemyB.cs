using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyB : Enemy
{
    public float rotateSpeed;
    bool canMove = true;
    Vector3 dir = Vector3.down;
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
        transform.position += dir * speed * Time.deltaTime;
    }


    IEnumerator Shoot()
    {
        yield return new WaitUntil(() => (transform.position.y <= 4.1f && transform.position.y >= 3.9f));//특정 조건이 만족될때 까지 기다리기 Approximately = 근사치 람다식 = 함수를 줄일대로 줄인거 (함수이름, return 값)
        canMove = false;
        //타켓 잡기
        Vector3 target = GameManager.Instance.player.transform.position;
        //회전하기
        while (!((transform.up.x  >= (transform.position - target).normalized.x -0.1f
            && transform.up.x <= (transform.position -target).normalized.x + 0.1f) &&
            (transform.up.x >= (transform.position - target).normalized.x - 0.1f
            && transform.up.x <= (transform.position - target).normalized.x + 0.1f)))
        {
            transform.up = Vector3.MoveTowards(transform.up, (transform.position - target).normalized,
             rotateSpeed);

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        //총알 발사
        canMove = true;
        dir = transform.up * -1;
        speed = 20;
    }
}
