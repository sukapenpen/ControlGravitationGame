using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationManager : SingletonMonoBehaviour<ConstellationManager>
{   
    [SerializeField]
    private GameObject[] constellations;
    private GameObject[] planets;

    
    public void OnAwake()
    {
        var rand = Random.Range(0, constellations.Length);
        Instantiate(constellations[rand]);
    }

    private void Update()
    {
        
    }

    private void Init()
    {
        var rand = Random.Range(0, constellations.Length);
        Instantiate(constellations[rand]);
        /*
        var constellation = constellations[rand].transform;
        planets = new GameObject[constellation.childCount];
        for (int i = 0; i < constellation.childCount; i++)
        {
            planets[i] = constellation.GetChild(i).gameObject;
        }
        */
    }

    /*
    private void Init()
    {
        //状態にあった星たちを取得
        for (int i = 0; i < constellations.Length; i++)
        {
            if (constellations[i].name == constellationStatus.ToString())
            {
                var constellation = constellations[i].transform;
                planets = new GameObject[constellation.childCount];
                for (int k = 0; k < constellation.childCount; k++)
                {
                    planets[k] = constellation.GetChild(k).gameObject;
                }
                break;
            }
        }
        
    }
    */

    /*
    public GameObject[] Constellations()
    {
        return constellations;
    }

    public GameObject[] ActiveConstellation()
    {
        return null;
    }
    */
}