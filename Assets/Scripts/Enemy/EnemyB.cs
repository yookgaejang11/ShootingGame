using System.Collections;
using UnityEngine;

public class EnemyB : Enemy
{
    public float rotateSpeed;
    bool canMove = true;
    Vector3 dir = Vector3.down;
    private void Start()
    {
        speed = 3;
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
        yield return new WaitUntil(() => (transform.position.y <= 4.1f && transform.position.y >= 3.9f));
        canMove = false;
        //타겟 잡고
        Vector3 target = GameManager.Instance.player.transform.position;
        Debug.Log(transform.up.z + " " + (transform.position - target).normalized.z);
        //회전하고
        while(!((transform.up.x >= (transform.position - target).normalized.x - 0.1f
            && transform.up.x <= (transform.position - target).normalized.x + 0.1f) &&
            (transform.up.y >= (transform.position - target).normalized.y - 0.1f
            && transform.up.y <= (transform.position - target).normalized.y + 0.1f)))
        {
            Debug.Log(1);
            transform.up =
Vector3.MoveTowards(transform.up, (transform.position - target).normalized,
rotateSpeed);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        //발사
        canMove = true;
        dir = transform.up * -1;
        speed = 20;
    }
}
