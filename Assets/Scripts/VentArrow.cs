using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentArrow : MonoBehaviour
{
    public Vent targetObject;
    private Transform target;
    private Collider2D player;
    public Vent host;
    private float rotationSpeed;

    void Start() {
        target = targetObject.gameObject.transform;
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
    void OnMouseUp()
    {
        if (host.isInVent)
		{
            player = host.entryObject;
            player.transform.position = target.transform.position;
            host.isInVent = false;
            host.showArrows(false);
            targetObject.isInVent = true;
            targetObject.showArrows(true);
        }
    }
}