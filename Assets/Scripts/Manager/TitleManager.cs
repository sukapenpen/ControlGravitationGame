using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Awake()
    {
        ConstellationManager.Instance.OnAwake();
    }

    private void Update()
    {
        
    }
}