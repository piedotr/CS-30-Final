using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMetalDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject leftDoor;
    public GameObject rightDoor;
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()
    {
        if(theDistance <= 3)
        {
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            if (Input.GetButtonDown("Action"))
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                leftDoor.GetComponent<Animator>().Play("LeftSlide");
                rightDoor.GetComponent<Animator>().Play("RightSlide");
            }
        }
        
    }
    private void OnMouseExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
