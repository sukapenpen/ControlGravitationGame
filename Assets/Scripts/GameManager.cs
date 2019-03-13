using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private Camera mainCamera;
    
    [SerializeField]
    private GameObject repulsion;
    
    private void Start()
    {
        repulsion.SetActive(false);
        Spaceship.Instance.OnStart();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var appearPos = Input.mousePosition;
            appearPos.z += 15.0f;
            appearPos = mainCamera.ScreenToWorldPoint(appearPos);
            repulsion.transform.position = appearPos;
            repulsion.SetActive(true);
        }
        else
        {
            repulsion.SetActive(false);
        }
        //Debug.Log(Input.mousePosition);
        Spaceship.Instance.OnUpdate(repulsion);
    }
}