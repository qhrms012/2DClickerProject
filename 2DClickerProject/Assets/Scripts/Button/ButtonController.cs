using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    public GameObject UIpanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIpanel.SetActive(false);
        }
    }

    public void ActiveOn()
    {
        UIpanel.SetActive(true);
    }
}
