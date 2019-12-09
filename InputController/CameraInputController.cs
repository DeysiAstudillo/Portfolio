using UnityEngine;
using UnityEditor;
using System.Linq;

public class CameraInputController : InputController
{
    CameraTracking cameraTrackingScript;

    Canvas canvas;

    public CameraInputController()
    {
        canvas = Resources.FindObjectsOfTypeAll<Canvas>().First(x => x.name == "CameraCanvas");
        if (canvas == null)
        {
            Debug.Log("camera canvas is null");
        }
        
        cameraTrackingScript = canvas.GetComponentInChildren<CameraTracking>();

        cameraTrackingScript.enabled = true;
        canvas.gameObject.SetActive(true);
        //canvas.enabled = true;
        if (cameraTrackingScript == null)
        {
            Debug.Log("cameraTracking is null");
        }
    }

    public MovementDirection getMovementDirection()
    {
        int lastCenterOffset = cameraTrackingScript.getCenterOffset();
        if (lastCenterOffset < -50)
        {
            return MovementDirection.RIGHT;
        } else if (lastCenterOffset > 50)
        {
            return MovementDirection.LEFT;
        } else
        {
            return MovementDirection.STRAIGHT;
        }
    }

    public void disable()
    {
        cameraTrackingScript.enabled = false;
        canvas.gameObject.SetActive(false);
    }
}