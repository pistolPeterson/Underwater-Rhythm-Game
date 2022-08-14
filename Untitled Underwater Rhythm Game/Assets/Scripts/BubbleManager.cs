using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab;


    private float timer = 0;
    [SerializeField] [Range(0.1f, 1f)]private float spawnTime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    

        if(timer > spawnTime)
        {
            //spawn in a box area 
            GameObject obj = ObjectPooler.current.GetPooledObject();
            if (obj == null) return;


            float x = Random.Range(-8f, 8);
            float y = Random.Range(-8f, 8);
            obj.transform.position = new Vector3(x, y, 0);
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);Debug.Log("yo?");

            //Instantiate(bubblePrefab, new Vector3(x, y, 0), Quaternion.identity);
            timer = 0;
        }

    }

    //make box gizmo 
    //object pool
}
