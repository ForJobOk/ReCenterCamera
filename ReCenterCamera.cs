using UnityEngine;
using System.Collections;
using UnityEngine.Events;
/// <summary>
/// Recenter your camera when you start VR. Attach to CameraRig.
/// </summary>
public class ReCenterCamera : MonoBehaviour
{
    [SerializeField, Tooltip("Set this child camera")]
    GameObject eyeCamera;

    [SerializeField,Tooltip("This event is skiped one frame")]
    UnityEvent startEvent;

    void Start()
    {
        StartCoroutine(ReCenterCoroutine());
    }

    IEnumerator ReCenterCoroutine()
    {
        yield return null; 
        Vector3 cameraRig_Angles = this.gameObject.transform.eulerAngles;
        Vector3 eyeCamera_Angles = eyeCamera.transform.eulerAngles;

        this.gameObject.transform.eulerAngles += new Vector3(0, cameraRig_Angles.y  - eyeCamera_Angles.y, 0);

        Vector3 cameraRig_StartPos = this.gameObject.transform.position;
        Vector3 eyeCamera_Pos = eyeCamera.transform.position;

        this.gameObject.transform.position += new Vector3(cameraRig_StartPos.x - eyeCamera_Pos.x, 0, cameraRig_StartPos.z - eyeCamera_Pos.z);

        yield return null;
        startEvent.Invoke();
    }
}