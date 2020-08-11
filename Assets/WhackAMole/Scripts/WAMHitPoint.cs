
using UnityEngine;
using UnityEngine.UI;
public class WAMHitPoint : MonoBehaviour
{
    
    [SerializeField] private string selectableTag = "mole";
    public Text score;
    private int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    var selectionRenderer = selection.GetComponent<Transform>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.GetComponent<WAMMoleControlScript>().CloseFunc();
                        points += 10;
                        score.text = points.ToString();

                    }
                }
            }
        }
    }
}
