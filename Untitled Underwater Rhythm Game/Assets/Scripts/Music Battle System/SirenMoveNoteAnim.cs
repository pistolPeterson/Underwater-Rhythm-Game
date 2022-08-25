using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenMoveNoteAnim : MonoBehaviour
{
    [SerializeField] private RectTransform sirenAnimObject;

    [SerializeField] Vector3 Qplacement;
    [SerializeField] Vector3 Wplacement;
    [SerializeField] Vector3 Eplacement;
    [SerializeField] Vector3 Rplacement;
    public void SirenSingQAnim()
    {
        //move to Q position 
        sirenAnimObject.anchoredPosition = Qplacement; 
        //play Q animation 
    }

    public void SirenSingEAnim()
    {
        //move to E position 
        sirenAnimObject.anchoredPosition = Eplacement;
        //play E animation 
    }
    public void SirenSingWAnim()
    {
        //move to W position 
        sirenAnimObject.anchoredPosition = Wplacement;
        //play W animation 
    }
    public void SirenSingRAnim()
    {
        //move to R position 
        sirenAnimObject.anchoredPosition = Rplacement;
        //play R animation 

    }
}
