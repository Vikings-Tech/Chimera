using UnityEngine;

public class WAMMoleControlScript : MonoBehaviour
{
    public float posReq;
    public float speed = 10;
    private bool close = false;

    void Awake()
    {
        posReq = -0.1f;
    }
    void Update()
    {
        if (gameObject.name == WAMGameController.MoleGen.ToString() && !close)
        {
            posReq = 1.2f;
            if (transform.position.y > 1.18)
            {
                Invoke("CloseFunc", WAMGameController.timeSpeed);
            }
        }
        if(close)
        {
            posReq = -0.1f;
            if (transform.position.y < 0)
            {
                close = false;
                WAMGameController.MoleGen = -1;
            }
        }
        transform.position = new Vector3(transform.position.x,
            Mathf.Lerp(transform.position.y, posReq, Time.deltaTime * speed),
            transform.position.z);
        

        
        
        // if (gameObject.name == WAMGameController.MoleGen.ToString() && !close)
        // {
        //     posReq = 1.2f;
        //     transform.position = new Vector3(transform.position.x,
        //         Mathf.Lerp(transform.position.y, posReq, Time.deltaTime * speed),
        //         transform.position.z);
        //     if (transform.position.y >= 1.18)
        //     {
        //         Invoke("CloseFunc", WAMGameController.timeSpeed);
        //     }
        // }
        //
        // if (close)
        // {
        //     posReq = -0.1f;
        //     transform.position = new Vector3(transform.position.x,
        //         Mathf.Lerp(transform.position.y, posReq, Time.deltaTime * speed),
        //         transform.position.z);
        //     if (transform.position.y <= 0)
        //     {
        //         close = false;
        //         WAMGameController.MoleGen = -1;
        //     }
        // }

        

        
    }

    public void CloseFunc()
    {
        close = true;
        
    }
}
