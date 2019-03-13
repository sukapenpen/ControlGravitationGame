using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }
    
    private void OnCollisionEnter(Collision _collision)
    {
        var planetNum = int.Parse(this.name[this.name.Length - 1].ToString());
        if (PlanetManager.Instance.CheckTouchOrder(planetNum))
        {
            this.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}