﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function_Profile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Back()
    {
        Application.LoadLevel("Home");
    }
    public void Leaderboard()
    {
        Application.LoadLevel("Leaderboard");
    }
    public void Badges()
    {
        Application.LoadLevel("Badges");
    }
}
