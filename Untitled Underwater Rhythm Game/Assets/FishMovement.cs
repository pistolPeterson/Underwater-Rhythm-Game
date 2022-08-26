using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishMovement : MonoBehaviour
{
    public List<GameObject> fishes;
    private bool goLeft = true;

    private void Start()
    {
        MakeFishesGo();
    }

    public void MakeFishesGo()
    {
        foreach (var fish in fishes)
        {
            float r1 = Random.Range(750f, 850f);
            float r2 = Random.Range(20f, 22f);
            fish.transform.DOMove(new Vector3(fish.transform.position.x - r1, fish.transform.position.y, fish.transform.position.z), r2);
        }
        StartCoroutine(FlipAllFish());

    }
    //after 18 secs
    //they all flip

    //then in 18 secs the call make fish go
    // they all go to right

    private IEnumerator FlipAllFish()
    {
        yield return new WaitForSeconds(18);
        
        foreach (var fish in fishes)
        {
            Vector3 currentScale = fish.transform.localScale;
            currentScale.x *= -1;
            fish.transform.localScale = currentScale;

            float r1 = Random.Range(750f, 850f);
            float r2 = Random.Range(20f, 22f);
            fish.transform.DOMove(new Vector3(fish.transform.position.x + r1, fish.transform.position.y, fish.transform.position.z), r2);

        }


    }

}
