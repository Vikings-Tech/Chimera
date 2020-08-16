
using UnityEngine;
using UnityEngine.UI;
public class WAMHitPoint : MonoBehaviour
{
    public ParticleSystem[] cloudParticles;
    [SerializeField] private string selectableTag = "mole";
    public GameObject baseHolder;
    private WAMBaseOpeningScript[] _baseOpeningScripts;
    public Text score;
    private int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _baseOpeningScripts = baseHolder.GetComponentsInChildren<WAMBaseOpeningScript>();

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
                        _baseOpeningScripts[System.Int16.Parse(selectionRenderer.gameObject.name)-1].CloseFunc();
                        Debug.Log(cloudParticles.Length);
                        cloudParticles[System.Int16.Parse(selectionRenderer.gameObject.name)-1].Play();
                        
                        points += 10;
                        score.text = points.ToString();

                    }
                }
            }
        }
    }
}
