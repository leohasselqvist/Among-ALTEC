using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoinButton : Button
{
    // Start is called before the first frame update
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        CustomNetworkManager.Instance.ServerChangeScene("MapSkeld");
    }
}
