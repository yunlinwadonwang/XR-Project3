using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.HandPoser;
using HurricaneVR.Framework.Shared;
using HurricaneVR.Framework.Core.Sockets;
using System.Linq;

public class Note : MonoBehaviour
{
    public HVRHandGrabber Grabber { get; set; }
    public HVRGrabbable Grabbable;
    public HVRGrabTrigger GrabTrigger;
    public HVRPosableGrabPoint GrabPoint;
    public HVRSocket CardSocket;
    GameObject level_obj;

    public void Start()
    {
        level_obj = GameObject.Find("level manager");
        Grabber = GameObject.Find("main/Player/Physics LeftHand").GetComponent<HVRHandGrabber>();
        GameObject card_obj = GetComponentInChildren<HVRTagSocketable>().gameObject;
        HVRGrabbable card_grab = card_obj.GetComponent<HVRGrabbable>();
        card_grab.LinkedSocket = CardSocket;
        card_grab.LinkedSocket.LinkedGrabbable = card_grab;
        card_obj.SetActive(false);
    }

    public void Grab()
    {
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
