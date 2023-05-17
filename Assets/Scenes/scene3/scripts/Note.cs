using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.HandPoser;
using HurricaneVR.Framework.Shared;
using System.Linq;

public class Note : MonoBehaviour
{
    public HVRHandGrabber Grabber { get; set; }
    public HVRGrabbable Grabbable;
    public HVRGrabTrigger GrabTrigger;
    public HVRPosableGrabPoint GrabPoint;
    ChangePlayer changePlayerScript;

    public void Start()
    {
        changePlayerScript = GetComponent<ChangePlayer>();
        Grabber = GameObject.FindObjectsOfType<HVRHandGrabber>().FirstOrDefault(e => e.gameObject.name == "Physics LeftHand");
    }

    public void Grab()
    {
        if(!changePlayerScript.isVisited){
            Grabbable.gameObject.SetActive(true);
            if (Grabbable && Grabber)
            {
                if(Grabber.IsGrabbing){
                    Grabber.ForceRelease();
                    Grabbable.gameObject.SetActive(false);
                }
                Grabber.Grab(Grabbable, GrabTrigger, GrabPoint);
            }
        }
    }
}
