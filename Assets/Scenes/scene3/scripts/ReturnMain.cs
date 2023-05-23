using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReturnMain : MonoBehaviour
{
    GameObject level_obj;
    bool prevPress;
    HurricaneVR.Framework.ControllerInput.HVRPlayerInputs ControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        prevPress = false;
        level_obj = GameObject.Find("level manager");
        GameObject ControllerObject = GetComponentsInChildren<Transform>().Where(c => c.gameObject.name == "PlayerController").FirstOrDefault().gameObject;
        ControllerScript = ControllerObject.GetComponent<HurricaneVR.Framework.ControllerInput.HVRPlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!prevPress && ControllerScript.IsRightGrabActivated){
            prevPress = true;
            level_obj.SendMessage("ChangePlayer", LevelManager.player.main);
        }
        if(!ControllerScript.IsRightGrabActivated){
            prevPress = false;
        }
    }
}
