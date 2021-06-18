using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float speed = 5f;
    public bool bFlipped { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -Game.Instance.screenBounds.x * 2 || transform.position.x > Game.Instance.screenBounds.x * 2){
            Destroy(this.gameObject);
        }
    }
}
