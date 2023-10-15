using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class viwers : MonoBehaviour
{
    public int Viewers;
    public int Bannedusers;
    public TextMeshProUGUI viewersval;

    public float viewercheck;
    public float multiplier;
    public void OnEnable()
    {
        ChatBox.OnBanned += BanUser;
    }
    public void OnDisable()
    {
        ChatBox.OnBanned -= BanUser;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        viewersval = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        viewercheck += Time.deltaTime;
        viewersval.text = Viewers.ToString();
        

        if (viewercheck > 10f)
        {
            viewercheck = 0;
            int viewrand = Random.Range(0, 2);
            if (viewrand == 0)
            {
                Viewers += (1 * Mathf.CeilToInt(multiplier));

            }
            if (viewrand == 1)
            {
                Viewers += 2 * (Mathf.CeilToInt(multiplier));
                multiplier += 0.25f;
            }

        }



    }



    public void BanUser()
    {
        Bannedusers += 1;
        multiplier += 0.5f;
    }
}
