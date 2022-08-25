using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishMovement : MonoBehaviour
{
    public List<GameObject> fishes;

    private void Start()
    {
        MakeFishesGo();
    }

    public void MakeFishesGo()
    {
        foreach (var fish in fishes)
        {
            float r1 = Random.Range(500f, 575f);
            float r2 = Random.Range(10f, 12f);
            fish.transform.DOMove(new Vector3(fish.transform.position.x - r1, fish.transform.position.y, fish.transform.position.z), r2);
        }
      

    }


}
