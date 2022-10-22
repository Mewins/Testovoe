using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float passedDistance;  
    [SerializeField] private float maxDistance = 3f;
    
    private Transform startPos;

    public static Cube Instance;

    private Spawner spawner;

    private Pooler pooler;

    private void Awake() 
    {
        Instance = this;
    }
    private void Start() 
    {
        spawner = Spawner.Instance;
        pooler = Pooler.Instance;
        startPos = gameObject.transform;
    }
    private void Update() 
    {
        passedDistance = Vector3.Distance(spawner.spawnPoint.position, gameObject.transform.position);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if(passedDistance >= maxDistance)
        {
           gameObject.SetActive(false);
        }
    }
}
