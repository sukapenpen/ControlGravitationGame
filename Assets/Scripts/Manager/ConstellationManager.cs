using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationManager : SingletonMonoBehaviour<ConstellationManager>
{
    public enum ConstellationStatus
    {
        GreatDipper,
        Ram
    }
    
    [SerializeField]
    private GameObject[] constellations;
    private ConstellationStatus constellationStatus;
    private GameObject[] planets;

    
    private void Awake()
    {
        for (int i = 0; i < constellations.Length; i++)
        {
            constellations[i] = Instantiate(constellations[i]);
            constellations[i].SetActive(false);
        }
        constellationStatus = ConstellationStatus.GreatDipper;
    }

    private void Update()
    {
        switch (constellationStatus)
        {
            case ConstellationStatus.GreatDipper:
                Debug.Log("北斗七星のステージ");
                constellations[0].SetActive(true);
                break;
            
            case ConstellationStatus.Ram:
                Debug.Log("牡羊座のステージ");
                break;
        }
        
    }

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

    public void ChangeConstellation()
    {
        constellationStatus += 1;
    }

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