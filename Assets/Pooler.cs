using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {   
        public int size;
        public string name;
        public GameObject prefab;
    }
    public List <Pool> poolList;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static Pooler Instance;
    private Spawner spawner;

    private void Awake() 
    {
        Instance = this;
        spawner = Spawner.Instance;
    }
    private void Start() 
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in poolList)
        {       
            Queue <GameObject> poolQueue = new Queue<GameObject>();
            for(int i=0; i<pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                poolQueue.Enqueue(obj);      
            }
            poolDictionary.Add(pool.name, poolQueue);
        }
    }

    public void SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {
        GameObject cubeToSpawn = poolDictionary[name].Dequeue();
        cubeToSpawn.SetActive(true);
        cubeToSpawn.transform.position = position;
        cubeToSpawn.transform.rotation = rotation;

        poolDictionary[name].Enqueue(cubeToSpawn);
    }    
}
