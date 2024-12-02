using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int atk;
    public ObjectType bulletType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().OnDamage(atk);//Enemy 컴포넌트(내가 만든 스크립트) 불러온 후 OnDamage(atk값 넣은 후) 실행
            //데미지
            ObjectPool.Instance.DestroyObject(this.gameObject, bulletType);
        }
    }

    
}
