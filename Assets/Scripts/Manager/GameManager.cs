using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> enemys = new List<Player>();
    private static GameManager instance = null;//static는 단 한 개,쓸수는 잇는데 대입은 안되게, 클래스 밖에 만들어짐(다른데에서도 아무데나 접근 ㄱㄴ)
    public Player player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance//프로퍼티(get,set) get = 호출할때 set = 대입할때(캡슐화과정에 나옴)
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
