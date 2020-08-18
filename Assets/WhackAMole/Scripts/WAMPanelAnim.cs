using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAMPanelAnim : MonoBehaviour
{

    private Vector3 reqScale;
    public float duration;

    private WAMPauseMenu _pauseMenu;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Start()
    {
        _pauseMenu = FindObjectOfType<WAMPauseMenu>();
    }

    private void OnEnable()
    {
        StartCoroutine(OpenPan());
    }

    

    IEnumerator OpenPan()
    {
        var counter = 0.0f;
        while(counter < 1.0f){
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, 
                Mathf.SmoothStep(0.0f, 1.0f, counter));
         
            counter += Time.deltaTime / duration;
            yield return null;
        }
        transform.localScale = Vector3.one;
        if (_pauseMenu != null)
        {
            _pauseMenu.GamePause();
        }
    }
    
    public void ClosePan()
    {
        if (_pauseMenu != null)
        {
            _pauseMenu.GameUnpaused();
        }
        StartCoroutine(ClosePanel());
    }
    
    IEnumerator ClosePanel()
    {
        var counter = 0.0f;
        while(counter < 1.0f){
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, 
                Mathf.SmoothStep(0.0f, 1.0f, counter));
         
            counter += Time.deltaTime / duration;
            yield return null;
        }
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }
}
