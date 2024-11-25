using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerBulletAPrefab;//[SerializeField] = public 선언 한 것처럼 인스펙터창에 보이게 하되 private 처럼 캡슐화
    [SerializeField] GameObject playerBulletBPrefab;
    [SerializeField] GameObject guideBulletPrefab;
    private Animator animator;
    public float speed;
    public float angle;
    bool canShoot = true;
    public float shootDelay;
    public int power = 1;
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Update()//스펙마다 반복 속도가 다름(FPS) = 속도가 달라짐(그래서 deltatime)
    {
        Shoot();
        Move();
    }
    private void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(input_x, input_y, 0).normalized;//키 동시입력하면 속도가 더 붙음, 간이벡터 == 크기는 없고 방향만 있는거

        transform.position += dir * speed * Time.deltaTime;//Time.deltaTime = 한번 반복하는데 걸린시간 스펙차이가 나도 빠른놈은 짧고 많이, 느린놈은 길고 적게 하게됨

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position); //world = position에있는 좌표값, viewport =화면의 끝부분은 0과 1로 조정
        if(pos.x >1) { pos.x = 1; }
        if (pos.x < 0) { pos.x = 0; }
        if (pos.y > 1) { pos.y = 1; }
        if (pos.y < 0) { pos.y = 0; }
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("isMove", (int)input_x);//input_x값이 float 값인데 isMove는 int값을 받으므로 input_x를 int 자료형으로 변환 후 inteager값을 지정
        }
    }
    void Shoot()
    {
        if(!Input.GetKey(KeyCode.Z)) { return; }
        if(!canShoot) { return; }

        canShoot = false;
        StartCoroutine(ShootDelay());

        switch (power) //파워 값에 따른 총알 발사 값
        {
            case 1:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);//프리펩 복사
                    GameObject bulletB = Instantiate(playerBulletAPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.1f;//총알 발사 위치 조정
                    bulletB.transform.position = transform.position + Vector3.left * 0.1f;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);//총알 오브젝트에 rigidbody2D 컴포넌트 불러온 후 AddForce로 총알 움직이기
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    break;
                }
            case 2:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletAPrefab);
                    GameObject bulletC = Instantiate(playerBulletBPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.25f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.25f;
                    bulletC.transform.position = transform.position;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    bulletC.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    break;
                }
            case 3:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletAPrefab);
                    GameObject bulletC = Instantiate(playerBulletBPrefab);
                    GameObject guidedBulletA = Instantiate(guideBulletPrefab);
                    GameObject guidedBulletB = Instantiate(guideBulletPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.25f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.25f;
                    bulletC.transform.position = transform.position;
                    guidedBulletA.transform.position = transform.position + Vector3.left * 0.5f;
                    guidedBulletB.transform.position = transform.position + Vector3.right * 0.5f ;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    bulletC.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    guidedBulletA.transform.Rotate(Vector3.forward * -70);
                    guidedBulletB.transform.Rotate(Vector3.forward * 70);

                    break;
                }
         

        }
    }

    IEnumerator ShootDelay()//코루틴
    {
        yield return new WaitForSeconds(shootDelay);//yield return에 옵션 추가(shootDelay만큼 기다렸다 실행)
        canShoot = true;
    }
}
