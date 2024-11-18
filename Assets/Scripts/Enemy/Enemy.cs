using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp;
    public void OnDamage(int Dmg)
    {
        Hp -= Dmg;
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
