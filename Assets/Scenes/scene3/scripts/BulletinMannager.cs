using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.Sockets;
using HurricaneVR.Framework.Shared;
using HurricaneVR.Framework.Core.Bags;
using System.Linq;

public class BulletinMannager : MonoBehaviour
{
    GameObject level_obj;
    List<GameObject> notes = new List<GameObject>();
    List<GameObject> notes_level;
    HVRHandGrabber Grabber { get; set; }
    List<HVRSocket> Sockets;
    // Start is called before the first frame update
    void Start()
    {
        level_obj = GameObject.Find("level manager");
        Grabber = GameObject.Find("main/Player/Physics LeftHand").GetComponent<HVRHandGrabber>();
        notes_level = level_obj.GetComponent<LevelManager>().GetNote();
        Sockets = GetComponentInChildren<HVRSocketContainer>().Sockets;
    }

    // Update is called once per frame
    void Update()
    {
        // bool checkAnswer = true;
        // foreach(var s in Sockets)
        //     if(s.gameObject.tag == "answer"){
        //         HVRGrabbable sb = s.gameObject.GetComponent<HVRTriggerGrabbableBag>().ValidGrabbables.FirstOrDefault();
        //         if (sb.gameObject.tag != "answer"){
        //             checkAnswer = false;
        //             break;
        //         }
        //     }
        // if(checkAnswer)
        //     Debug.Log("win");
    }
    
    void PlaceNote(){
        if (notes_level.Count != 0){
            Grabber.ForceRelease();
            foreach(var note in notes_level)
                if(!notes.Contains(note))
                    notes.Add(note);
            notes_level.Clear();

            foreach(var note in notes){
                note.SetActive(true);
                Grabber.Grab(note.GetComponent<HVRGrabbable>(), HVRGrabTrigger.ManualRelease);
                Grabber.ForceRelease();
            }
            Grabber.enabled = false;
        }
    }
}
