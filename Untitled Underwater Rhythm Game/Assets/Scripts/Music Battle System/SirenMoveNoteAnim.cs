using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SirenMoveNoteAnim : MonoBehaviour
{
    [SerializeField] private RectTransform sirenAnimObject;

    [SerializeField] Vector3 Qplacement;
    [SerializeField] Vector3 Wplacement;
    [SerializeField] Vector3 Eplacement;
    [SerializeField] Vector3 Rplacement;

    [SerializeField] Image sirenMarkerImg;
    [SerializeField] Sprite sirenMarker1;
    [SerializeField] Sprite sirenMarker2;
    [SerializeField] Sprite sirenMarker3;
    [SerializeField] Sprite sirenMarker4;
    public void SirenSingQAnim()
    {
        sirenMarkerImg.gameObject.SetActive(true);
        //move to Q position 
        sirenAnimObject.anchoredPosition = Qplacement; 
        sirenMarkerImg.sprite = sirenMarker1;
        //play Q animation 
    }
    public void SirenSingWAnim()
    {
        sirenMarkerImg.gameObject.SetActive(true);
        //move to W position 
        sirenAnimObject.anchoredPosition = Wplacement;
        sirenMarkerImg.sprite = sirenMarker2;
        //play W animation 
    }

    public void SirenSingEAnim()
    {
        sirenMarkerImg.gameObject.SetActive(true);
        //move to E position 
        sirenAnimObject.anchoredPosition = Eplacement;
        sirenMarkerImg.sprite = sirenMarker3;
        //play E animation 
    }
   
    public void SirenSingRAnim()
    {
        sirenMarkerImg.gameObject.SetActive(true);
        //move to R position 
        sirenAnimObject.anchoredPosition = Rplacement;
        sirenMarkerImg.sprite = sirenMarker4;
        //play R animation 

    }


    public void ShowSirenMarkerEmpty()
    {
        sirenMarkerImg.gameObject.SetActive(false);
        sirenMarkerImg.sprite = null;

    }

    public void HideSirenMarker()
    {
        sirenMarkerImg.gameObject.SetActive(false);
    }
}
