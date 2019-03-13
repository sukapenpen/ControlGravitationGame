﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetManager : SingletonMonoBehaviour<PlanetManager>
{
    //private GameObject[] planets;
    private bool[] planets;
    
    private void Awake()
    {
        /*
        planets = new GameObject[transform.childCount];
        for ()
        */
        
        planets = new bool[transform.childCount];
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i] = false;
        }
    }

    private void Update()
    {
        
    }

    public bool CheckTouchOrder(int _planetNum)
    {
        if (_planetNum == 0)
        {
            planets[_planetNum] = true;
            return true;
        }
        else if (planets[_planetNum - 1])
        {
            planets[_planetNum] = true;
            return true;
        }
        return false;
    }
}