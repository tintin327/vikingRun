using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerClick(PointerEventData e)
    {
        System.Environment.Exit(0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }
    }
}
