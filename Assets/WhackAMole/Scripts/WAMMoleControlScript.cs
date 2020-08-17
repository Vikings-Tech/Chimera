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
            if (transform.localPosition.y > openPos-0.02)
            {
                Invoke("CloseFunc", WAMGameController.timeSpeed);
            }
        }
        if(close)
        {
            posReq = closePos;
            if (transform.localPosition.y < 0)
            {
                close = false;
                WAMGameController.MoleGen = -1;
            }
        }
        transform.localPosition = new Vector3(transform.localPosition.x,
            Mathf.Lerp(transform.localPosition.y, posReq, Time.deltaTime * speed),
            transform.localPosition.z);


    }

    public void CloseFunc()
    {
        close = true;
        
    }
}
