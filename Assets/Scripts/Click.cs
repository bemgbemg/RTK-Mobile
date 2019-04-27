using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {
    void Awake()
    {
        // 设置阈值
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.1f;

    }
} 

