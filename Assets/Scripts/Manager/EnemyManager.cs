using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour//싱글톤 패턴(클래스 이름으로 접근 ㄱㄴ하게)객체가 여러개일 수 이써서 못씀 -> 객체를 하나만 유지시킴
{
    public List<Enemy> enemys = new List<Enemy>();
    private static EnemyManager instance = null;//static는 단 한 개,쓸수는 잇는데 대입은 안되게, 클래스 밖에 만들어짐(다른데에서도 아무데나 접근 ㄱㄴ)
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static EnemyManager Instance//프로퍼티(get,set) get = 호출할때 set = 대입할때(캡슐화과정에 나옴)
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
