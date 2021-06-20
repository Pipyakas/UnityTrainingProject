using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera cam;
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
        cam = Camera.main;
    }
    void Start()
    {
        cat.AddBullet(currentBullet);
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
