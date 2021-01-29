using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SwipeTask swipeTask;
    private void Awake()
    {
        _swipeTask = GetComponentInParent<SwipeTask>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _swipeTask.SwipePointTrigger(this);
    }
}
