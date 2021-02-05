using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 100f;

    //private Canvas _canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        /*Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, eventData.position, _canvas.worldCamera, out pos);

        transform.position = _canvas.transform.TransformPoint(pos);*/
    }

    private void Awake()
    {
        //_canvas = GetComponentInParent<Canvas>();
    }

}
