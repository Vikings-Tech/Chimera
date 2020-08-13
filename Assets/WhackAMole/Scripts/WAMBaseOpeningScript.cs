using System;
using UnityEngine;

public class WAMBaseOpeningScript : MonoBehaviour
{
    
    public float speed = 10;
    private float _scaleReq;
    private bool _close = false;
    private WAMGameController _gameController;
    private void Start()
    {
        _gameController = FindObjectOfType<WAMGameController>();
    }

    void Update()
    {
        if (gameObject.name == WAMGameController.MoleGen.ToString() && !_close)
        { 
            _scaleReq = 1;
            
            if (transform.localScale.x >= 0.98)
            {
                Invoke(nameof(CloseFunc), WAMGameController.timeSpeed);
            }
        }

        if (_close)
        {
            _scaleReq = 0; 
            if (transform.localScale.x <= 0.02)
            {
                _close = false;
            }
        }
        transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, _scaleReq, Time.deltaTime * speed),
            0,Mathf.Lerp(transform.localScale.z, _scaleReq, Time.deltaTime * speed));
        
        
    }
    public void CloseFunc()
    {
        _close = true;
        
    }
}
