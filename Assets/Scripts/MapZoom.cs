using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapZoom : MonoBehaviour {

    public bool Zooming;
    public GameObject Panel;
    public GameObject Map;

    void Start()
    {
        Panel.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;
        Zooming = false;
    }

    void Update()
    {
        var Rect = Map.GetComponent<RectTransform>();

        if(Zooming == true)
        {
            Panel.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
            Rect.localScale = new Vector3(3f, 3f);
        }
        else
        {
            Panel.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;
            Rect.localScale = new Vector3(1f, 1f);
        }

    }

}
