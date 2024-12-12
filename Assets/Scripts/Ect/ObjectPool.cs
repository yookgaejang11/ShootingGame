using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance = null;

    [SerializeField] GameObject playerBulletA_Prefab;
    [SerializeField] GameObject playerBulletB_Prefab;
    [SerializeField] GameObject guidedBullet_Prefab;
    [SerializeField] GameObject enemyBullet_Prefab;
    [SerializeField] GameObject enemyA_Prefab;
    [SerializeField] GameObject enemyB_Prefab;
    [SerializeField] GameObject enemyC_Prefab;
    [SerializeField] GameObject HPItem_Prefab;
    [SerializeField] GameObject PowerItem_Prefab;
    [SerializeField] GameObject ScoreItem_Prefab;
    [SerializeField] GameObject BossBulletA_Prefab;
    [SerializeField] GameObject BossBulletB_Prefab;

    [SerializeField] int playerBulletA_Count;
    [SerializeField] int playerBulletB_Count;
    [SerializeField] int guidedBullet_Count;
    [SerializeField] int enemyBullet_Count;
    [SerializeField] int enemyA_Count;
    [SerializeField] int enemyB_Count;
    [SerializeField] int enemyC_Count;
    [SerializeField] int HPItem_Count;
    [SerializeField] int PowerItem_Count;
    [SerializeField] int ScoreItem_Count;
    [SerializeField] int BossBulletA_Count;
    [SerializeField] int BossBulletB_Count;

    private Queue<GameObject> playerBulletAs = new Queue<GameObject>();
    private Queue<GameObject> playerBulletBs = new Queue<GameObject>();
    private Queue<GameObject> guidedBullets = new Queue<GameObject>();
    private Queue<GameObject> enemyBullets = new Queue<GameObject>();
    private Queue<GameObject> enemyAs = new Queue<GameObject>();
    private Queue<GameObject> enemyBs = new Queue<GameObject>();
    private Queue<GameObject> enemyCs = new Queue<GameObject>();
    private Queue<GameObject> HPItems = new Queue<GameObject>();
    private Queue<GameObject> PowerItems = new Queue<GameObject>();
    private Queue<GameObject> ScoreItems = new Queue<GameObject>();
    private Queue<GameObject> BossBulletAs = new Queue<GameObject>();
    private Queue<GameObject> BossBulletBs = new Queue<GameObject>();

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
        Initialize();
    }
    private void Initialize()
    {
        for(int i = 0; i < playerBulletA_Count; i++)
        {
            GameObject obj = Instantiate(playerBulletA_Prefab);
            obj.SetActive(false);
            playerBulletAs.Enqueue(obj);
        }
        for (int i = 0; i < playerBulletB_Count; i++)
        {
            GameObject obj = Instantiate(playerBulletB_Prefab);
            obj.SetActive(false);
            playerBulletBs.Enqueue(obj);
        }
        for (int i = 0; i < guidedBullet_Count; i++)
        {
            GameObject obj = Instantiate(guidedBullet_Prefab);
            obj.SetActive(false);
            guidedBullets.Enqueue(obj);
        }
        for (int i = 0; i < enemyBullet_Count; i++)
        {
            GameObject obj = Instantiate(enemyBullet_Prefab);
            obj.SetActive(false);
            enemyBullets.Enqueue(obj);
        }
        for (int i = 0; i < enemyA_Count; i++)
        {
            GameObject obj = Instantiate(enemyA_Prefab);
            obj.SetActive(false);
            enemyAs.Enqueue(obj);
            Debug.Log(enemyAs.Count);
        }
        for (int i = 0; i < enemyB_Count; i++)
        {
            GameObject obj = Instantiate(enemyB_Prefab);
            obj.SetActive(false);
            enemyBs.Enqueue(obj);
        }
        for (int i = 0; i < enemyC_Count; i++)
        {
            GameObject obj = Instantiate(enemyC_Prefab);
            obj.SetActive(false);
            enemyCs.Enqueue(obj);
        }

        for (int i = 0; i < HPItem_Count; i++)
        {
            GameObject obj = Instantiate(HPItem_Prefab);
            obj.SetActive(false);
            HPItems.Enqueue(obj);
        }
        for (int i = 0; i < PowerItem_Count; i++)
        {
            GameObject obj = Instantiate(PowerItem_Prefab);
            obj.SetActive(false);
            PowerItems.Enqueue(obj);
        }
        for (int i = 0; i < ScoreItem_Count; i++)
        {
            GameObject obj = Instantiate(ScoreItem_Prefab);
            obj.SetActive(false);
            ScoreItems.Enqueue(obj);
        }
        for (int i = 0; i < BossBulletA_Count; i++)
        {
            GameObject obj = Instantiate(BossBulletA_Prefab);
            obj.SetActive(false);
            BossBulletAs.Enqueue(obj);
        }
        for (int i = 0; i < BossBulletB_Count; i++)
        {
            GameObject obj = Instantiate(BossBulletB_Prefab);
            obj.SetActive(false);
            BossBulletBs.Enqueue(obj);
        }
    }
    public GameObject GetObject(ObjectType type)
    {
        GameObject obj = null;
        switch (type)
        {
            case ObjectType.PlayerBulletA:
                obj = playerBulletAs.Dequeue(); 
                break;
            case ObjectType.PlayerBulletB:
                obj = playerBulletBs.Dequeue();
                break;
            case ObjectType.GuidedBullet:
                obj = guidedBullets.Dequeue();
                break;
            case ObjectType.EnemyBullet:
                obj = enemyBullets.Dequeue();
                break;
            case ObjectType.EnemyA:
                obj = enemyAs.Dequeue();
                break;
            case ObjectType.EnemyB:
                obj = enemyBs.Dequeue();
                break;
            case ObjectType.EnemyC:
                obj = enemyCs.Dequeue();
                break;
            case ObjectType.HPItem:
                obj = HPItems.Dequeue();
                break;
            case ObjectType.PowerItem:
                obj = PowerItems.Dequeue();
                break;
            case ObjectType.ScoreItem:
                obj = ScoreItems.Dequeue();
                break;
            case ObjectType.BossBulletA:
                obj = BossBulletAs.Dequeue();
                break;
            case ObjectType.BossBulletB:
                obj = BossBulletBs.Dequeue();
                break;
        }
        obj.SetActive(true);
        return obj;
    }
    public void DestroyObject(GameObject obj, ObjectType type)
    {
        obj.SetActive(false);
        switch (type)
        {
            case ObjectType.PlayerBulletA:
                playerBulletAs.Enqueue(obj);
                break;
            case ObjectType.PlayerBulletB:
                playerBulletBs.Enqueue(obj);
                break;
            case ObjectType.GuidedBullet:
                guidedBullets.Enqueue(obj);
                break;
            case ObjectType.EnemyBullet:
                enemyBullets.Enqueue(obj);
                break;
            case ObjectType.EnemyA:
                enemyAs.Enqueue(obj);
                break;
            case ObjectType.EnemyB:
                enemyBs.Enqueue(obj);
                break;
            case ObjectType.EnemyC:
                enemyCs.Enqueue(obj);
                break;
            case ObjectType.HPItem:
                HPItems.Enqueue(obj);
                break;
            case ObjectType.PowerItem:
                PowerItems.Enqueue(obj);
                break;
            case ObjectType.ScoreItem:
                ScoreItems.Enqueue(obj);
                break;
            case ObjectType.BossBulletA:
                BossBulletAs.Enqueue(obj);
                break;
            case ObjectType.BossBulletB:
                BossBulletBs.Enqueue(obj);
                break;
        }
    }

    public static ObjectPool Instance
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
public enum ObjectType
{
    PlayerBulletA, PlayerBulletB, GuidedBullet, EnemyBullet, EnemyA, EnemyB, EnemyC, HPItem, PowerItem, ScoreItem,BossBulletA, BossBulletB
}
