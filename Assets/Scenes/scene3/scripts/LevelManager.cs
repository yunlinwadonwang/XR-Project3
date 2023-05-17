using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject main_obj, s1_obj;
    public enum player{
        main,
        s1
    };
    public player cur_player;
    // Start is called before the first frame update
    void Start()
    {
        cur_player = player.main;
        main_obj = GameObject.Find("main");
        s1_obj = GameObject.Find("s1");
        main_obj.SetActive(true);
        s1_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangePlayer(player p){
        cur_player = p;
        switch(cur_player){
            case player.main:
                main_obj.SetActive(true);
                s1_obj.SetActive(false);
                break;
            case player.s1:
                main_obj.SetActive(false);
                s1_obj.SetActive(true);
                break;
        }
    }
}
