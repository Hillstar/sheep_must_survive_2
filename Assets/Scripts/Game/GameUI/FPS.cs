using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    private float _deltaTime = 0.0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.LowerRight;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        var msec = _deltaTime * 1000.0f;
        var fps = 1.0f / _deltaTime;
        var text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}