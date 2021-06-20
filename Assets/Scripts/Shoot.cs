using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject currentBullet;
    private readonly Vector2 spawnPos = new Vector3(0,-3,0);
    private const float BulletForce = 25f;
    private Cat cat;
    private Vector3 mousePos;
    private float reloadTime = 0.5f;

    private void Awake()
    {
        cat = GetComponent<Cat>();
        currentBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }
    void Start()
    {
        cat.AddBullet(currentBullet);
    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    
    private void RotateBullet()
    {
        if (ReferenceEquals(currentBullet, null)) return;
        var lookDir = mousePos - gameObject.transform.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        currentBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void shoot()
    {
        if (ReferenceEquals(currentBullet, null)) return;
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(currentBullet.transform.up * BulletForce, ForceMode2D.Impulse);
        cat.ReleaseBullet(currentBullet);
        currentBullet = null;
        Invoke(nameof(reload), reloadTime);
    }
    private void reload()
    {
        currentBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        cat.AddBullet(currentBullet);
    }
}
