using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public delegate void OnRevaluated();
    public static event OnRevaluated _onRevaluated;
    void Start()
    {
        CelController._onDivision += ReEstart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReEstart() {
        _onRevaluated?.Invoke();
    }
}
