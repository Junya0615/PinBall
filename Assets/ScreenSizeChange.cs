using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeChange : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        this.rect = GetComponent<RectTransform>();

        this.rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void Update()
    {
        this.rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}