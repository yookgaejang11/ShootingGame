using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ObjectType itemType;
    //�޼��� �������̵� ��뿹��
    public virtual void GiveEffect()//virtual == �޼��� �������̵� �ҰŴ�
    {
        Debug.Log("GivEffect");
    }
}
