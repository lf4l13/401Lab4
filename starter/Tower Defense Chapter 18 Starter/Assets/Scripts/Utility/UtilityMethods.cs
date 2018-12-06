using UnityEngine;

public static class UtilityMethods
{
    public static void MoveUiElementToWorldPosition(RectTransform rectTransform, Vector3 worldPosition)
    {
        rectTransform.position = worldPosition + new Vector3(0, 3);
        
        // Needed to rotate UI the right way
        rectTransform.LookAt(Camera.main.transform.position + Camera.main.transform.forward * 10000);
        
        ScaleRectTransformBasedOnDistanceFromCamera(rectTransform);
    }
    // takes the parameter Transform which has to be rotated and position where it wants to look
    public static Quaternion SmoothlyLook(Transform fromTransform,
     Vector3 toVector3)
    {
        // checks to ensure the method stops executing 
        if (fromTransform.position == toVector3)
        {
            return fromTransform.localRotation;
        }

        // stores current rotation & creates the target rotation for the Transform by using the LookRotation() method
        Quaternion currentRotation = fromTransform.localRotation;
        Quaternion targetRotation = Quaternion.LookRotation(toVector3 -
        fromTransform.position);
      
        return Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 10f);
    }

    // scales based on distance from the camera
    private static void ScaleRectTransformBasedOnDistanceFromCamera(RectTransform rectTransform)
    {
        
        float distance = Vector3.Distance(Camera.main.transform.
        position, rectTransform.position);
        
        rectTransform.localScale = new Vector3(distance /
        UIManager.vrUiScaleDivider, distance /
        UIManager.vrUiScaleDivider, 1f);
    }
}