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
    public Text clockTimer;
    
    void Start()
    {
        timeSpeed = 2;
        StartCoroutine(GeneratorController());
    }

    IEnumerator Clock()
    {
        float time = 120;
        while (time > 0)
        {
            time -= 1;
            yield return new WaitForSeconds(1);
            clockTimer.text = time.ToString();
        }
        
    }
    IEnumerator GeneratorController()
    {
        StartCoroutine(Clock());
        float time = 0;
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

        MoleGen = 0;
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy GC");
        StopAllCoroutines();
    }
}

