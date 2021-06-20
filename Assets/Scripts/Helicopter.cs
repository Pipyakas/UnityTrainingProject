using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject soldierPrefab;
    public GameObject explosion;
    public GameObject fragments;
    private Rigidbody2D rb;
    public int speed;
    public bool bFlipped { get; set; }

    private void Awake()
    {
        speed = Random.Range(3, 7);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!bFlipped)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void FixedUpdate()
    {
        if (bFlipped)
        {
            rb.MovePosition(Vector3.right * (Time.fixedDeltaTime * speed) + transform.position);
            return;
        }
        rb.MovePosition(Vector3.left * (Time.fixedDeltaTime * speed) + transform.position);
    }

    void Update()
    {
        if(transform.position.x < -Game.Instance.screenBounds.x * 2 || transform.position.x > Game.Instance.screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }

    private void SpawnSoldier()
    {
        var soldier = Instantiate(soldierPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<Soldier>();
        soldier.bFlipped = bFlipped;
        Game.Instance.gameObjects.Add(soldier.gameObject);
    }
}
