using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class WAMGameController : MonoBehaviour
{
    public static int MoleGen;
    public static float timeSpeed;
    public GameObject gameOverAnim;
    public Image clockImage;
    private float time;
    private WAMMoleControlScript[] _moleControlScripts;
    private WAMBaseOpeningScript[] _baseOpeningScripts;
    
    void Start()
    {
        _moleControlScripts = FindObjectsOfType<WAMMoleControlScript>();
        _baseOpeningScripts = FindObjectsOfType<WAMBaseOpeningScript>();
        timeSpeed = 2;
        StartCoroutine(GeneratorController());
    }

    IEnumerator Clock()
    {
        
        while (time < 120)
        {
            clockImage.fillAmount = 1- time / 120;
            if (time < 40)
            {
                clockImage.color = Color.green;
            }
            else if (time < 80)
            {
                clockImage.color = Color.yellow;
            }
            else
            {
                clockImage.color = Color.red;
            }
            yield return null;
            Debug.Log(time);
        }
        
    }
    IEnumerator GeneratorController()
    {
        
        time = 0;
        StartCoroutine(Clock());
        int preMol = 0;
        while (time < 120)
        {   
            MoleGen = Random.Range(1, 10);
            if (MoleGen == preMol)
            {
                MoleGen = Random.Range(1, 10);
            }
            // Debug.Log(MoleGen);
            yield return new WaitForSeconds(timeSpeed);
            time += timeSpeed;
            if (time > 60)
            {
                timeSpeed = 0.25f;
            }
            else if (time > 45)
            {
                timeSpeed = 0.5f;
            }

            else if (time > 30)
            {
                timeSpeed = 1f;
            }
            
            else if (time > 15)
            {
                timeSpeed = 1.3f;
            }

            preMol = MoleGen;
        }

        time = 120;
        MoleGen = 0;
        foreach (var VARIABLE in _moleControlScripts)
        {
            VARIABLE.CloseFunc();
        }

        foreach (var VARIABLE in _baseOpeningScripts)
        {
            VARIABLE.CloseFunc();
        }
        yield return new WaitForSeconds(0.5f);
        gameOverAnim.SetActive(true);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}

