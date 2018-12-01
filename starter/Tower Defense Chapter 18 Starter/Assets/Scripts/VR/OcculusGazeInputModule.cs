using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OcculusGazeInputModule : PointerInputModule {

    public GameObject reticle;
    //2
    public Transform centerEyeTransform;
    //3
    public float reticleSizeMultiplier = 0.02f;
    //4
    private PointerEventData pointerEventData;
    //5
    private RaycastResult currentRaycast;
    //6
    private GameObject currentLookAtHandler;

    public override void Process()
    {
        HandleLook();
        HandleSelection();
    }

    void HandleLook()
    {
        //1
        if (pointerEventData == null)
        {
            pointerEventData = new PointerEventData(eventSystem);
        }
        pointerEventData.position = Camera.main.ViewportToScreenPoint(new Vector3(.5f, .5f));
        //3
        List<RaycastResult> raycastResults =
        new List<RaycastResult>();
        //4
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        //5
        currentRaycast = pointerEventData.pointerCurrentRaycast =
        FindFirstRaycast(raycastResults);
        //6
        reticle.transform.position = centerEyeTransform.position +
        (centerEyeTransform.forward * currentRaycast.distance);
        //7
        float reticleSize = currentRaycast.distance *
        reticleSizeMultiplier;
        reticle.transform.localScale =
        new Vector3(reticleSize, reticleSize, reticleSize);
        //8
        ProcessMove(pointerEventData);
    }

    void HandleSelection()
    {
        if (pointerEventData.pointerEnter != null)
        {
            //2
            currentLookAtHandler = ExecuteEvents.GetEventHandler
            <IPointerClickHandler>(pointerEventData.pointerEnter);
            //3
            if (currentLookAtHandler != null &&
            OVRInput.GetDown(OVRInput.Button.One))
            {
                //4
                ExecuteEvents.ExecuteHierarchy(currentLookAtHandler,
                pointerEventData, ExecuteEvents.pointerClickHandler);
            }
        }
        else
        { //5
            currentLookAtHandler = null;
        }
    }
}