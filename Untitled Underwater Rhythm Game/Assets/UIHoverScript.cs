using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoverScript : MonoBehaviour
{
    public GameObject hoverGameObject;
    // Start is called before the first frame update
    void Start()
    {
        hoverGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ShowGameObject()
    {
        hoverGameObject.SetActive(true);
    }

    public void HideGameObject()
    {
        hoverGameObject.SetActive(false);
    }
}
