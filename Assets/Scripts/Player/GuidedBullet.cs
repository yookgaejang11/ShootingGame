using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuidedBullet : PlayerBullet//PlayerBullet의 내용을 상속받음
{
    Rigidbody2D rigid;
    public Transform target;
    public float rotateSpeed;
    public float speed;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(EnemyManager.Instance.enemys.Count > 0)
        {
            List<Enemy> targets = EnemyManager.Instance.enemys.//enemys 리스트에 접근
            OrderByDescending(_ => Vector3.Distance(_.transform.position, transform.position)).ToList();
            //람다식 _ ==변수 ㅓㄴ언 그 뒤에 정렬 조건 enemys 와 내 사이 거리 실수형으로 계산 후 내림차순 정렬
            //OrgerByDescending = 내림차순 정렬 linq사용
            target = targets[targets.Count - 1].transform;
        }




    }
    void Update()
    {
        if(target != null)
        {
            transform.up = Vector3.MoveTowards(transform.up, (target.transform.position - transform.position).normalized,
                rotateSpeed * Time.deltaTime);
        }
    

        rigid.velocity = transform.up * speed;  
    }
}
