using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInteractableObject : MonoBehaviour
{
    public int maxInteractionStep;

    public int currentInteractionStep;

    void Start()
    {
        maxInteractionStep = this.transform.childCount;
        currentInteractionStep = 0;
        UpdateObject();
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        if(currentInteractionStep == maxInteractionStep)
        {
            currentInteractionStep = 0;
        }

        for(int i=0; i<maxInteractionStep; i++)
        {
            if(i == currentInteractionStep)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        currentInteractionStep++;
    }
}
