using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ObjectType itemType;
    //메서드 오버라이드 사용예정
    public virtual void GiveEffect()//virtual == 메서드 오버라이드 할거다
    {
        Debug.Log("GivEffect");
    }
}
