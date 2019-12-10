using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    float furthestCelestial;
    public GameObject prefab;
    public Transform min;
    public Transform max;
    [SerializeField]Transform lastSpawn;
    SpaceShip player;
    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<SpaceShip>();
         Spawn();
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position,lastSpawn.position)<10)Spawn();
    }
    void Spawn()
    {
        float X= Random.Range(5f,15f);
        float Y= Random.Range(-3f,3f);
        lastSpawn = Instantiate(prefab,new Vector2(lastSpawn.position.x+X,Y),prefab.transform.rotation).transform;
    }
}
