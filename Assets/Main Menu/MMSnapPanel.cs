using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMSnapPanel : MonoBehaviour
{
    public int panelNum;

    public GameObject mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(mainPanel.transform.localPosition);
        Debug.Log(transform.localPosition);
        transform.localPosition = new Vector3( panelNum * Screen.width,
            mainPanel.transform.localPosition.y, mainPanel.transform.localPosition.z);
        Debug.Log(mainPanel.transform.localPosition);
        Debug.Log(transform.localPosition);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(transform.localPosition);
        }
    }
}

