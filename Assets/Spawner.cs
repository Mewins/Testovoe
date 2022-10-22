using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{   
    [SerializeField]private int spawnTime = 0;
    [SerializeField]public Transform spawnPoint;
    [SerializeField]private string spawnerName = "";
    public static Spawner Instance;
    private Pooler pooler;
    private void Awake() 
    {
        Instance = this;
    }   

    private void Start() 
    {
        pooler = Pooler.Instance;
        StartCoroutine(SpawnCube());
    }
    
    IEnumerator SpawnCube()
    {
        while(true)
        {
            pooler.SpawnFromPool(spawnerName, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
