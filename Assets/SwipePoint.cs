using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePoint : MonoBehaviour
{
    private SwipeTask _swipeTask; // refferens till swipetask
    private void Awake() //
    {
        _swipeTask = GetComponentInParent<SwipeTask>(); // får in föreldern till swiptasken

    }
    private void OnTriggerEnter2D(Collider2D other) // om collider 2d på swipepointsen träffar vad som hels
    {
        _swipeTask.SwipePointTrigger(this); //sikcar til baka som en metod  till swipetasken
    }
}






