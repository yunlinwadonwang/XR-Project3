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
    GameObject level_obj;

    public void Start()
    {
        level_obj = GameObject.Find("level manager");
        changePlayerScript = GetComponent<ChangePlayer>();
        Grabber = GameObject.Find("main/Player/Physics LeftHand").GetComponent<HVRHandGrabber>();
    }

    public void Grab()
    {
        if(!changePlayerScript.isVisited){
            Grabber.enabled = true;
            if(Grabber.IsGrabbing){
                GameObject grabObj = Grabber.GrabbedTarget.gameObject;
                Grabber.ForceRelease();
                grabObj.SetActive(false);
            }
            level_obj.SendMessage("AddNote", Grabbable.gameObject);
            Grabbable.gameObject.SetActive(true);
            Grabber.Grab(Grabbable, GrabTrigger, GrabPoint);
        }
    }
}
