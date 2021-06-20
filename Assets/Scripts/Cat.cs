using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    void Start()
    {
        
    }
    public void AddBullet(GameObject bullet)
    {
        bullet.transform.parent = gameObject.transform;   
    }

    public void ReleaseBullet(GameObject bullet)
    {
        var bulletCollider = bullet.GetComponent<BoxCollider2D>();
        if (!ReferenceEquals(bulletCollider, null))
        {
            bulletCollider.isTrigger = false;
        }
        bullet.transform.parent = null;
    }
    void Update()
    {
        
    }
}
