﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : SingletonMonoBehaviour<Spaceship>
{
    public struct PlanetData
    {
        public Vector3 pos; // { get; set; }
        public float radius;
        public float size;

        public PlanetData(Transform trans)
        {
            this.pos = trans.position;
            this.radius = trans.lossyScale.x;
            this.size = 4 * 3.14f * Mathf.Pow(trans.lossyScale.x / 2, 3) / 3;
        }
    }

    private PlanetData[] planetDatas;
    private float playerSize;
    private float pi;
    private float coefficient = 1.0f;

    private Rigidbody rigidbody;
    //private float averageForce;
    //private Vector3 averageDirection;

    public void OnStart()
    {
        rigidbody = GetComponent<Rigidbody>();
        pi = 3.14f;
        playerSize = Mathf.Pow(this.transform.lossyScale.x, 3);
        Reset();
        //averageForce = 0.0f;
        //averageDirection = Vector3.zero;
    }

    public void OnUpdate(GameObject _repulsion)
    {
        //var averageForce = 0.0f;
        //var averageDirection = Vector3.zero;
        for (int i = 0; i < planetDatas.Length; i++)
        {
            var planet = planetDatas[i];
            var direction = planet.pos - transform.position;
            //averageDirection += direction;
            var distance = direction.magnitude;
            distance *= distance;
            var gravity = coefficient * planet.size * playerSize / distance;
            //averageForce += gravity;
            //Debug.Log(gravity);
            rigidbody.AddForce(gravity * direction.normalized, ForceMode.Force);
        }

        if (_repulsion.gameObject.activeSelf)
        {
            var repulsion = new PlanetData(_repulsion.transform);
            Repulsive(repulsion);
        }

        /*
        Debug.Log(averageDirection);
        Debug.Log(averageForce);
        averageForce /= planetDatas.Length;
        rigidbody.AddForce(averageForce * averageDirection.normalized, ForceMode.Force);
        */
    }

    public void Reset()
    {
        var constellation = GameObject.FindGameObjectWithTag("Constellation").transform;
        planetDatas = new PlanetData[constellation.childCount];

        for (int i = 0; i < constellation.childCount; i++)
        {
            planetDatas[i] = new PlanetData(constellation.GetChild(i).transform);
        }
    }
    
    private void Repulsive(PlanetData _repulsion)
    {
        var direction = _repulsion.pos - transform.position;
        var distance = direction.magnitude;
        if (distance < _repulsion.radius)
        {
            distance = _repulsion.radius;
        }
        distance *= distance;
        var gravity = coefficient * _repulsion.size * playerSize / distance;
        rigidbody.AddForce(-gravity * direction.normalized, ForceMode.Force);
    }
    
    private void OnCollisionEnter(Collision _collision)
    {
        //_collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}