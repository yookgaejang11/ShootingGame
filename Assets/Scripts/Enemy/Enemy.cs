using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] ObjectType enemyType;
    public int Hp;
    public float speed;

    public List<DropItem> dropItems = new List<DropItem> ();
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDamage(int Dmg)
    {
        Hp -= Dmg;
        if(Hp <= 0)
        {
            ItemDrop();
            EnemyManager.Instance.enemys.Remove(this);
            ObjectPool.Instance.DestroyObject(this.gameObject, enemyType);
        }
    }
    private void OnBecameInvisible()
    {
        try
        {
            EnemyManager.Instance.enemys.Remove (this);
            ObjectPool.Instance.DestroyObject(this.gameObject, enemyType);
        }
        catch 
        {

        }
    }

    void ItemDrop()
    {
        for ( int i = 0; i < dropItems.Count; i++)
        {
            float ramdomValue = UnityEngine.Random.Range(0f, 100f);
            if(ramdomValue < dropItems[i].probability)
            {
                for (int j = 0; j < dropItems[i].count; j++)
                {
                    GameObject Item = ObjectPool.Instance.GetObject(dropItems[i].itemType);
                    float randox_x = UnityEngine.Random.Range(-1f,1f);
                    float randox_y = UnityEngine.Random.Range(-1f,1f);
                    Item.transform.position = new Vector3(transform.position.x + randox_x, transform.position.y + randox_y, 0);
                    Item.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
                }
            }
        }
    }

}
[Serializable]
public class DropItem
{
    public ObjectType itemType;
    public int count;
    public float probability;
}
