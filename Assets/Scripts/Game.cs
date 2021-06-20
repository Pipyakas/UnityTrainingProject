using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Vector2 screenBounds;
    public static Game Instance;
    public GameObject helicopterPrefab;
    public GameObject soldierPrefab;
    
    public float respawnTime = 1.0f;
    
    System.Random rand = new System.Random();
    public List<GameObject> gameObjects = new List<GameObject>();
    public int score;
    void Start()
    {
        Instance = this;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        InvokeRepeating(nameof(spawnHelicopter), 1f, 1f);
    }
    
    private void spawnHelicopter(){
        GameObject heli = Instantiate(helicopterPrefab) as GameObject;
        if (rand.NextDouble() >= 0.5)
        {
            heli.transform.position = new Vector2(Game.Instance.screenBounds.x, Random.Range(Game.Instance.screenBounds.y / 2, Game.Instance.screenBounds.y));
        }
        else
        {
            heli.GetComponent<Helicopter>().bFlipped = true;
            heli.transform.position = new Vector2(-Game.Instance.screenBounds.x, Random.Range(Game.Instance.screenBounds.y / 2, Game.Instance.screenBounds.y));
        }   
        Game.Instance.gameObjects.Add(heli);
    }

    void Update()
    {
        
    }
    public void ClearGameObjects()
    {
        foreach (var gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
    }
}
