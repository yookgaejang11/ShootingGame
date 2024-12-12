using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Boss : Enemy
{
    public List<Transform> bulletpoints = new List<Transform>();

    public List<int> spellIndexes = new List<int>();
    Coroutine currentSpell;
    bool canAttack = false;
    public float spellTimer;
    public float currentSpellTime;
    void Update()
    {
        Move();
        SpellChange();
    }

    void Move()
    {
        if (transform.position.y <= 3) { canAttack = true; return; }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void SpellChange()
    {
        if(!canAttack) { return; }
        if (Hp > 0 && spellTimer > currentSpellTime) { return; }
        if (currentSpell != null)
        {
            StopCoroutine(currentSpell);
        }
        currentSpellTime = 0;
        Hp = 100;

        int spellIndex = spellIndexes[Random.Range(0,spellIndexes.Count)];
        spellIndexes.Remove(spellIndex);
        currentSpell = StartCoroutine("Spell" +  spellIndex);
    }


    IEnumerator Spell1()
    {
        while(true)
        {
            int count = 20;
            for (int i = 0; i < count; i++)
            {
                GameObject bullet = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
                bullet.transform.position = bulletpoints[0].position;
                bullet.transform.rotation = bulletpoints[0].rotation;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 5, ForceMode2D.Impulse);
                bulletpoints[0].transform.Rotate(Vector3.forward * (360 / count));
            }
            bulletpoints[0].Rotate(Vector3.forward * (360 / count) / 3);

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator Spell2()
    {
        while (true)
        {
            for(int i = 0; i < 3; i++)
            {
                GameObject bulletA = ObjectPool.Instance.GetObject(ObjectType.BossBulletA);
                bulletA.transform.position = bulletpoints[0].position;
                bulletA.GetComponent<Rigidbody2D>().
                    AddForce(
                    (GameManager.Instance.player.transform.position - bulletA.transform.position).normalized * 5
                    , ForceMode2D.Impulse);
                while(bulletA.activeSelf)//setActive일도앙ㄴ
                {
                    GameObject bulletB = ObjectPool.Instance.GetObject(ObjectType.BossBulletB);
                    Vector3 pos = 
                        new Vector3(bulletA.transform.position.x + Random.Range(-0.7f, 0.7f),
                        bulletA.transform.position.y + Random.Range(-0.7f, 0.7f),
                        0);
                    bulletB.transform.position = pos;
                    bulletB.transform.Rotate(Vector3.forward * Random.Range(0, 360f));
                    DeleteBulletB(bulletB);// 값형 자료형 : 변수를 a를 만들고 그 값을 채로운 변수인 b에 해놓고 a 값을 바꿔도 바뀌지 않음, 참조형 자료형 : class,string, 포인터 같은거
                    yield return new WaitForSeconds(0.05f);
                }
            }
            for (int i = 0;i < 5;i++)
            {
                Vector3 dir = GameManager.Instance.player.transform.position - bulletpoints[0].position;
                bulletpoints[0].up = dir.normalized;//transform.up는 이 오브젝트 기준 위쪽
                bulletpoints[0].Rotate(Vector3.forward * 30);
                for (int j = 0; i < 3; j++)
                {
                    GameObject bullet = ObjectPool.Instance.GetObject(ObjectType.EnemyBullet);
                    bullet.transform.position = bulletpoints[0].transform.position;
                    bullet.transform.rotation = bulletpoints[0].transform.rotation;
                    bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 7, ForceMode2D.Impulse);
                    bulletpoints[0].transform.Rotate(Vector3.forward * -15);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    
    IEnumerator DeleteBulletB(GameObject bullet)
    {
        yield return new WaitForSeconds(4);
        ObjectPool.Instance.DestroyObject(bullet, ObjectType.BossBulletB);
    }
    

    IEnumerator Spell3()
    {
        Debug.Log(3);
        yield return null;
    }

    IEnumerator Spell4()
    {
        Debug.Log(4);
        yield return null;
    }
}
