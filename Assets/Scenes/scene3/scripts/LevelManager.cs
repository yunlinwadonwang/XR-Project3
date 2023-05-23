using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HurricaneVR.Framework.Core.Grabbers;

public class LevelManager : MonoBehaviour
{
    GameObject main_obj, s1_obj, s2_obj;
    public enum player{
        main,
        s1,
        s2
    };
    public player cur_player;
    public List<GameObject> notes = new List<GameObject>();
    HVRHandGrabber Grabber { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        notes.Clear();
        Grabber = GameObject.Find("main/Player/Physics LeftHand").GetComponent<HVRHandGrabber>();
        Grabber.enabled = false;
        cur_player = player.main;
        main_obj = GameObject.Find("main");
        s1_obj = GameObject.Find("s1");
        s2_obj = GameObject.Find("s2");
        main_obj.SetActive(true);
        s1_obj.SetActive(false);
        s2_obj.SetActive(false);
    }

    void ChangePlayer(player p){
        cur_player = p;
        switch(cur_player){
            case player.main:
                main_obj.SetActive(true);
                s1_obj.SetActive(false);
                s2_obj.SetActive(false);
                break;
            case player.s1:
                main_obj.SetActive(false);
                s1_obj.SetActive(true);
                s2_obj.SetActive(false);
                break;
            case player.s2:
                main_obj.SetActive(false);
                s1_obj.SetActive(false);
                s2_obj.SetActive(true);
                break;
        }
    }

    void AddNote(GameObject n){
        notes.Add(n);
    }

    public List<GameObject> GetNote(){
        return notes;
    }
}
