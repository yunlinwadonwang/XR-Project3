using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public LevelManager.player player;
    public bool isVisited;
    GameObject level_obj;
    ParticleSystem particle;
    Note noteScripts;
    HurricaneVR.Framework.Core.HVRGrabbable GrabScript;
    float time_counter;
    // Start is called before the first frame update
    void Start()
    {
        isVisited = false;
        level_obj = GameObject.Find("level manager");
        noteScripts = GetComponent<Note>();
        GrabScript = GetComponent<HurricaneVR.Framework.Core.HVRGrabbable>();
        particle = transform.Find("GrabPoints/Particle System").gameObject.GetComponent<ParticleSystem>();
        time_counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GrabScript.Grabbers.Count != 0){
            if(time_counter < Time.deltaTime){
                particle.Play();
            }
            time_counter += Time.deltaTime;
            if(time_counter > 3){
                noteScripts.Grab();
                isVisited = true;
                time_counter = 0;
                level_obj.SendMessage("ChangePlayer", player);
            }
        }else{
            particle.Stop();
            time_counter = 0;
        }
    }
}
