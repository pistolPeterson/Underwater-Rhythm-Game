using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    [SerializeField] private GameObject pooledObject;
    [SerializeField] private int pooledAmount; 
    [SerializeField] private bool willGrow;

    private List<GameObject> pooledObjects;

    private void Awake()
    {

        current = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.parent = this.transform;
        }
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject obj in pooledObjects)
        {
            if(!obj.activeInHierarchy)
                return obj;


        }

        if(willGrow)
        {
            Debug.Log("Instantiate");
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
           

        return null;
    }

}
