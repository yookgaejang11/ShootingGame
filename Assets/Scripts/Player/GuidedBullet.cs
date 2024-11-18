using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuidedBullet : PlayerBullet//PlayerBullet의 내용을 상속받음
{
    Transform target;
    void Update()
    {
        target = EnemyManager.Instance.enemys[0].transform;
    }
}
