﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Learn : MonoBehaviour {
     Level_Class[] level_temp = new Level_Class[7];

    // Use this for initialization
    void Start () {
        Text t_temp;
        Button b_temp;
        if(Level_Check.init == 0)
            Level_Data.Level_Init();
        for (int i = 0; i < 6; i++)
        {
            level_temp[i] = Level_Data.Level_Get(i);
            t_temp = GameObject.Find("Text_Level-" + (i+1).ToString() + "_Score").GetComponent<Text>();
            t_temp.text = level_temp[i].GetHighestScore();
        }
        level_temp[6] = Level_Data.Level_Get(6);
        t_temp = GameObject.Find("Text_Overall_Score").GetComponent<Text>();
        t_temp.text = level_temp[6].GetHighestScore();

        switch (System_Data.language)
        {
            case 0:
                b_temp = GameObject.Find("Button_Material").GetComponent<Button>();
                b_temp.GetComponentInChildren<Text>().text = "教材";
                b_temp = GameObject.Find("Button_Level").GetComponent<Button>();
                b_temp.GetComponentInChildren<Text>().text = "關卡";
                b_temp = GameObject.Find("Button_Back").GetComponent<Button>();
                b_temp.GetComponentInChildren<Text>().text = "返回";
                break;
            default:
                break;
        }

    }
	
}
