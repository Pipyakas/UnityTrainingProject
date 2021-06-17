using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject helicopterPrefab;
    public GameObject soldierPrefab;
    
    public float respawnTime = 1.0f;
    
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawner());
    }
    private void spawnHelicopter(){
        GameObject heli = Instantiate(helicopterPrefab) as GameObject;
        if (rand.NextDouble() >= 0.5)
        {
            heli.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            heli.transform.position = new Vector2(-Game.Instance.screenBounds.x, Random.Range(Game.Instance.screenBounds.y / 2, Game.Instance.screenBounds.y));
        }
        else
        {
            heli.transform.Rotate(new Vector3(0, 180, 0));
            heli.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            heli.transform.position = new Vector2(Game.Instance.screenBounds.x, Random.Range(Game.Instance.screenBounds.y / 2, Game.Instance.screenBounds.y));
        }
        
    }

    IEnumerator spawner(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnHelicopter();
        }
    }
}
