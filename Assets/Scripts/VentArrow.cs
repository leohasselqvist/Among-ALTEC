using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentArrow : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed;
    void Start() {

        LookAt2D(target.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LookAt2D(Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
