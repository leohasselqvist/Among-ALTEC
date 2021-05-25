using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public List<SwipePoint> _swipePoints = new List<SwipePoint>();

    public float _countdownMax = 0.5f;

    public GameObject _greenOn;

    public GameObject _redOn;

    public GameObject _completed;

    public GameObject _tryagain;

    private int _currentSwipePointindex = 0;

    private float _cuntdown = 0;

    public GameObject winText;

    private void Update()
    {
        _cuntdown -= Time.deltaTime;

        if (_currentSwipePointindex != 0 && _cuntdown <= 0)
        {
            _currentSwipePointindex = 0;
            StartCoroutine(FinishTask(false));
        }
    }

    private IEnumerator FinishTask(bool wasSuccessful)
    {
        if (wasSuccessful)
        {
            _greenOn.SetActive(true);
            _completed.SetActive(true);
            winText.SetActive(true);
            StartCoroutine(Timer());
        }
        else
        {
            _redOn.SetActive(true);
            _tryagain.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);
        _greenOn.SetActive(false);
        _redOn.SetActive(false);
        _completed.SetActive(false);
        _tryagain.SetActive(false);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Destroy(winText);
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
            StartCoroutine(FinishTask(true));

        }
    }

    
}
