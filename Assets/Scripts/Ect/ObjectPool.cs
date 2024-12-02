using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance = null;

    [SerializeField] GameObject playerBulletA_Prefab;
    [SerializeField] GameObject playerBulletB_Prefab;
    [SerializeField] GameObject guideBullet_Prefab;
    [SerializeField] GameObject enemyBullet_Prefab;
    [SerializeField] GameObject enemyA_Prefab;
    [SerializeField] GameObject enemyB_Prefab;
    [SerializeField] GameObject enemyC_Prefab;

    [SerializeField] int playerBulletA_Count;
    [SerializeField] int playerBulletB_Count;
    [SerializeField] int guidedBullet_Count;
    [SerializeField] int enemyBullet_Count;
    [SerializeField] int enemyA_Count;
    [SerializeField] int enemyB_Count;
    [SerializeField] int enemyC_Count;

    private Queue<GameObject> playerBulletAs = new Queue<GameObject>();
    private Queue<GameObject> playerBulletBs = new Queue<GameObject>();
    private Queue<GameObject> guidedBullets = new Queue<GameObject>();
    private Queue<GameObject> enemyBullets = new Queue<GameObject>();
    private Queue<GameObject> enemyAs = new Queue<GameObject>();
    private Queue<GameObject> enemyBs = new Queue<GameObject>();
    private Queue<GameObject> enemyCs = new Queue<GameObject>();

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

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        for (int i = 0; i < playerBulletA_Count; i++)
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
            GameObject obj = Instantiate(guideBullet_Prefab);
            obj.SetActive(false);
            guidedBullets.Enqueue(obj);
        }

        for (int i = 0; i < enemyBullet_Count; i++)
        {
            GameObject obj = Instantiate(playerBulletA_Prefab);
            obj.SetActive(false);
            playerBulletAs.Enqueue(obj);
        }

        for (int i = 0; i < enemyA_Count; i++)
        {
            GameObject obj = Instantiate(enemyA_Prefab);
            obj.SetActive(false);
            enemyAs.Enqueue(obj);
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
    PlayerBulletA, PlayerBulletB, GuidedBullet, EnemyBullet, EnemyA, EnemyB, EnemyC
}
