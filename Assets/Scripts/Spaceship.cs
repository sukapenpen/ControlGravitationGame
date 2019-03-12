using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public struct PlanetData
    {
        public Vector3 pos;// { get; set; }
        public float size;
        
        public PlanetData(Transform trans)
        {
            this.pos = trans.position;
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
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pi = 3.14f;
        var planets = GameObject.FindGameObjectsWithTag("Planet");
        planetDatas = new PlanetData[planets.Length];
        
        for (int i = 0; i < planets.Length; i++)
        {
            planetDatas[i] = new PlanetData(planets[i].transform);
            Debug.Log(planetDatas[i].size);
        }
        
        playerSize = Mathf.Pow(this.transform.lossyScale.x, 3);
        //averageForce = 0.0f;
        //averageDirection = Vector3.zero;
    }

    private void Update()
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
        /*
        Debug.Log(averageDirection);
        Debug.Log(averageForce);
        averageForce /= planetDatas.Length;
        rigidbody.AddForce(averageForce * averageDirection.normalized, ForceMode.Force);
        */
        
    }
}