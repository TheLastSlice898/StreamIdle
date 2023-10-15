using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class timer : MonoBehaviour
{

    public float t;
    private TextMeshProUGUI val;
    // Start is called before the first frame update
    void Start()
    {
        val = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;
        float timer = MathF.Floor(t);
        TimeSpan Span = TimeSpan.FromSeconds(timer);

        val.text = $"{Span.Hours:D2},{Span.Minutes:D2},{Span.Seconds:D2}";




    }
}
