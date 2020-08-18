using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MMSlider : MonoBehaviour, IDragHandler,IEndDragHandler
{
    private Vector3 panelPosition;
    public float threshodPercentage = 0.2f;
    public float easing = 0.5f;

    public int panelLeft;
    public int panelRight;
    // Start is called before the first frame update
    void Start()
    {
        panelPosition = transform.position;
    }

 

    public void OnDrag(PointerEventData eventData)
    {
        float difference = eventData.pressPosition.x - eventData.position.x;
        if (difference > 0)
        {   if(panelRight>0)
            {transform.position = panelPosition - new Vector3(difference, 0, 0);}
        }
        else
        {
            if(panelLeft > 0)
            {transform.position = panelPosition - new Vector3(difference, 0, 0);}
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float percentage = (eventData.pressPosition.x - eventData.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= threshodPercentage)
        {
            Vector3 newLocation = panelPosition;
            if (percentage > 0 && panelRight > 0)
            {
                panelRight -= 1;
                panelLeft += 1;
                newLocation += new Vector3(-Screen.width,0,0);
            }
            else if (percentage < 0 && panelLeft > 0)
            {
                panelRight += 1;
                panelLeft -= 1;
                newLocation += new Vector3(Screen.width,0,0);
            }

            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelPosition = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelPosition, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
