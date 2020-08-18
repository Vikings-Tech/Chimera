using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public GameObject button;
    private void OnTriggerEnter(Collider other)
    {
        button.SetActive(true);
        Debug.Log("IIIINNNNN");
    }
    void OnTriggerExit(Collider other)
    {
        button.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnEnterPortal(){

    }
}
