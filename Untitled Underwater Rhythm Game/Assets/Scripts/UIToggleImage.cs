using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggleImage : MonoBehaviour
{
    public Image img;
    public Sprite pressedImg;
    public Sprite normalImg;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        img.sprite = normalImg;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
            img.sprite = pressedImg;

        if (Input.GetKeyUp(keyToPress))
            img.sprite = normalImg;
    }
}
