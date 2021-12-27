using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int point = GameObject.Find("viking").GetComponent<character>().coinPoint;
        GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = " Your survival time :" + System.Convert.ToString(point) + "s; your coins:" + System.Convert.ToString(point);

    }
}
