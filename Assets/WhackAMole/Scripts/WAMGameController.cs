using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WAMGameController : MonoBehaviour
{
    public static int MoleGen;
    public static float timeSpeed;
    
    
    void Start()
    {
        timeSpeed = 2;
        StartCoroutine(GeneratorController());
    }

    IEnumerator GeneratorController()
    {
        float time = Time.time;
        int preMol = 0;
        while (time < 60)
        {   
            MoleGen = Random.Range(1, 7);
            if (MoleGen == preMol)
            {
                MoleGen = Random.Range(1, 7);
            }
            Debug.Log(MoleGen);
            yield return new WaitForSeconds(timeSpeed);
            time += timeSpeed;
            if (time > 45)
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
}
