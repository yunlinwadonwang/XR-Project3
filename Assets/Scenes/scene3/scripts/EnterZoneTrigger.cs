using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZoneTrigger : MonoBehaviour
{
    GameObject bulletin_obj;
    void Start(){
        bulletin_obj = GameObject.Find("bulletin");
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "left hand box"){
            bulletin_obj.SendMessage("PlaceNote");
        }
    }
}
