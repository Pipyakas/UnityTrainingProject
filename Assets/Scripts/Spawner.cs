using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject helicopterPrefab;
    public GameObject soldierPrefab;
    
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(spawner());
    }
    private void spawnHelicopter(){
        GameObject heli = Instantiate(helicopterPrefab) as GameObject;
        heli.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    private void spawnSoldier(){
        GameObject soldier = Instantiate(soldierPrefab) as GameObject;
        soldier.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator spawner(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnHelicopter();
            spawnSoldier();
            Debug.Log("spawned");
        }
    }
}
