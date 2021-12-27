using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public int num = 12;
    public GameObject[] roadblock = new GameObject[12];
    public float[] roadPositionX = new float[12];
    public float[] roadPositionZ = new float[12];
    public float[] roadRotationY = new float[12];




    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 12; i++)
        {
            roadblock[i] = GameObject.Find("straight (" + System.Convert.ToString(i) + ")");
        }
        for (int i =0;i<12;i++)
        {
            
            roadPositionX[i] = i * 6 - 6;
            roadPositionZ[i] = 0;
            roadRotationY[i] = 90;
            roadblock[i].transform.position = new Vector3(i * 6 - 6, 0, 0);
            roadblock[i].transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        
    }
}
