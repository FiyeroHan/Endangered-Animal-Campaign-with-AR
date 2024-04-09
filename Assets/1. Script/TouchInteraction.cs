using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    public Camera arCamera;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Input.GetMouseButtonDown(0)");

            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitObject;
            if(Physics.Raycast(ray, out hitObject))
            {
                ARInteractableObject aRInteractableObject = hitObject.transform.GetComponent<ARInteractableObject>();
                if(aRInteractableObject)
                {
                    aRInteractableObject.UpdateObject();
                }
            }
        }   
    }
}
