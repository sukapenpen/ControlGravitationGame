using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject spaceship;
    private Vector3 initPos;
    
    private void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        initPos = this.transform.position;
    }

    private void Update()
    {
        var pos = spaceship.transform.position;
        pos.z = initPos.z;
        this.transform.position = pos;
    }
}