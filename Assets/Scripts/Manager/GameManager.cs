using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public enum GameState
    {
        Init,
        Play,
        Result
    }
    
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject repulsion;

    private float countTime = 4;
    private float elapsedTime;
    private GameState gameState;

    private void Awake()
    {
        gameState = GameState.Init;
        elapsedTime = 0;
        repulsion.SetActive(false);
        Spaceship.Instance.OnAwake();
        PlanetManager.Instance.OnAwake();
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.Init:
                countTime -= Time.deltaTime;
                if (countTime < 0)
                {
                    gameState = GameState.Play;
                }
                //Debug.Log(countTime);
                break;
            
            case GameState.Play:
                elapsedTime += Time.deltaTime;
                RepulsionMove();
                Spaceship.Instance.OnUpdate(repulsion);
                if (PlanetManager.Instance.JudgeStageClear())
                {
                    gameState = GameState.Result;
                }
                break;
            
            case GameState.Result:
                Debug.Log(elapsedTime);
                break;
        }
        
    }

    private void RepulsionMove()
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
        Spaceship.Instance.OnUpdate(repulsion);
    }
}