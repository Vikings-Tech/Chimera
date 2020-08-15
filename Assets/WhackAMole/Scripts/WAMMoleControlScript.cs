using UnityEngine;

public class WAMMoleControlScript : MonoBehaviour
{
    public float posReq;
    public float speed = 10;
    private bool close = false;
    public float openPos;
    public float closePos;
    void Awake()
    {
        posReq = -0.1f;
    }
    void Update()
    {
        if (gameObject.name == WAMGameController.MoleGen.ToString() && !close)
        {
            posReq = openPos;
            if (transform.position.y > openPos-0.02)
            {
                Invoke("CloseFunc", WAMGameController.timeSpeed);
            }
        }
        if(close)
        {
            posReq = closePos;
            if (transform.position.y < 0)
            {
                close = false;
                WAMGameController.MoleGen = -1;
            }
        }
        transform.position = new Vector3(transform.position.x,
            Mathf.Lerp(transform.position.y, posReq, Time.deltaTime * speed),
            transform.position.z);


    }

    public void CloseFunc()
    {
        close = true;
        
    }
}
