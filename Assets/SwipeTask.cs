using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public List<SwipePoint> _swipePoints = new List<SwipePoint>();

    public float _countdownMax = 0.5f;

    private int _currentSwipePointindex = 0;

    private float _cuntdown = 0;

    private void Update()
    {
        _cuntdown -= Time.deltaTime;

        if (_currentSwipePointindex != 0 && _cuntdown <= 0)
        {
            _currentSwipePointindex = 0;
            Debug.Log("nein error");
        }
    }

    public void  SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint == _swipePoints[_currentSwipePointindex])
        {
            _currentSwipePointindex++;
            _cuntdown = _countdownMax;
        }
        if (_currentSwipePointindex >= _swipePoints.Count)
        {
            _currentSwipePointindex = 0;
            Debug.Log("Yes nice");
        }
    }

    
}
