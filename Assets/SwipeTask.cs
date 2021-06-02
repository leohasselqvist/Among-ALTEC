using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public List<SwipePoint> _swipePoints = new List<SwipePoint>(); //sparar swipepoinsen i en lista

    public float _countdownMax = 0.5f; //timer som andvänds för att se till så att tiden mellan colidersan inte översiger

    public GameObject _greenOn; //lampa på

    public GameObject _redOn; // lampa av

    public GameObject _completed; //completed text

    public GameObject _tryagain; //try agin text

    private int _currentSwipePointindex = 0; //vilken swipepoint som kotet rör

    private float _cuntdown = 0; //cuntddown når sitt slut

    public GameObject winText; // wintexten

    private void Update()
    {
        _cuntdown -= Time.deltaTime; //subtraherar tiden som går i cuntdownen

        if (_currentSwipePointindex != 0 && _cuntdown <= 0) //ifall cuntdowen når noll eller den inte når alla swipepoint index
        {
            _currentSwipePointindex = 0; 
            StartCoroutine(FinishTask(false)); //starta finishTask False
        }
    }

    public void SwipePointTrigger(SwipePoint swipePoint) // funktionen kallas av varje swipepoint
    {
        if (swipePoint == _swipePoints[_currentSwipePointindex]) //ifall swipepointen faller i årdning
        {
            _currentSwipePointindex++; //plussa på 1 på swipepontindexet
            _cuntdown = _countdownMax; //cuntdown är då lika med den tid som ska vara max imellan swipepointsen
        }
        if (_currentSwipePointindex >= _swipePoints.Count) //ifall man når den sista swipepointen
        {
            _currentSwipePointindex = 0;
            StartCoroutine(FinishTask(true)); //starta finishtask true

        }
    }

    private IEnumerator FinishTask(bool wasSuccessful) //startar om den kallas i koden
    {
        if (wasSuccessful)
        {
            _greenOn.SetActive(true); //grön knapp
            _completed.SetActive(true); //texten korect
            winText.SetActive(true); //win text
            StartCoroutine(Timer()); // starta timer
        }
        else
        {
            _redOn.SetActive(true); //rödlampa
            _tryagain.SetActive(true); //texten försök igen
        }

        yield return new WaitForSeconds(1.5f); //leverear en i tagen 
        _greenOn.SetActive(false); //visa ingen 
        _redOn.SetActive(false);
        _completed.SetActive(false);
        _tryagain.SetActive(false);
    }

    private IEnumerator Timer() //startar vid kallelse
    {
        yield return new WaitForSeconds(2); //vänta 
        Destroy(gameObject); //förstör
        Destroy(winText); //förstör
    }



    
}
