using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour//싱글톤 패턴
{
    public List<Enemy> enemys = new List<Enemy>();
    private static EnemyManager instance = null;//static는 단 한 개,쓸수는 잇는데 대입은 안되게
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
