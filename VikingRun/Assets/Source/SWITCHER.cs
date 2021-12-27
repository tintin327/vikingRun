using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SWITCHER : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    public int SceneId = 2;
    public void OnPointerClick(PointerEventData e)
    {
        Debug.Log("SSS");
        SceneId = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneId);
;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("SSS");
            SceneId = 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(SceneId);
        }
    }
}
