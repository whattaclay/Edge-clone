using System;
using UnityEngine;

public class FallViewer : MonoBehaviour
{
    [SerializeField] private GameObject _mainHero;
    private float _previousHeight;
 
    void Update()
    {
        var currentHeight = _mainHero.transform.position.y;
        if(currentHeight +0.02f < _previousHeight) Console.WriteLine("fallen");
        _previousHeight = _mainHero.transform.position.y;
    }
}