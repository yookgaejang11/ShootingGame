using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public float speed;
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Update()//스펙마다 반복 속도가 다름(FPS) = 속도가 달라짐(그래서 deltatime)
    {
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
}
