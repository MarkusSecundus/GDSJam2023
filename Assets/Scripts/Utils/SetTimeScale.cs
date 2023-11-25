using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] float timeScale = 0.4f;

    void Start()
    {
        Time.timeScale = timeScale; 
    }

    private void Update() => Start();
}
