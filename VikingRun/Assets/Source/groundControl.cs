using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] roadblock;
    public GameObject player;
    public GameObject[] corner = new GameObject[4];
    public float[] roadPositionX;
    public float[] roadPositionZ;
    public float[] roadRotationY;
    public float[] cornerPositionX = new float[4];
    public float[] cornerPositionZ = new float[4];
    public float[] cornerRotationY = new float[4];
    public float speed = 8;
    public int directionX = 1;
    public int directionZ = 0;
    int roadDirectionX = 1;
    int roadDirectionZ = 0;
    public int transition = 0;
    int cornerNum = 0;
    int first;
    int loc = 0;
    int trans = 0;
    int curentY = 90;
    void Start()
    {
        for(int i=0;i<4;i++)
        {
            cornerPositionX[i] = 10000;
            cornerPositionZ[i] = 10000;
            cornerRotationY[i] = 90;
        }
        first = 0;
        speed = 8;
        directionX = 1;
        directionZ = 0;
        for(int i=0;i<4;i++)
        {
            corner[i] = GameObject.Find("corner (" + System.Convert.ToString(i) + ")");
        }
        roadPositionX = GameObject.Find("Ground").GetComponent<roadSpawn>().roadPositionX;
        roadPositionZ = GameObject.Find("Ground").GetComponent<roadSpawn>().roadPositionZ;
        roadRotationY = GameObject.Find("Ground").GetComponent<roadSpawn>().roadRotationY;
        player = GameObject.Find("viking");
        

    }


    // Update is called once per frame
    void Update()
    {

        GameObject[] roadblock = GameObject.Find("Ground").GetComponent<roadSpawn>().roadblock;
        int second = (first + 1) % 12;
        for (int i = 0; i < 12; i++)
        {
       
            if(i<4)
            {
                cornerPositionX[i] -= (float)(Time.deltaTime * speed * directionX);
                cornerPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
                corner[i].transform.position = new Vector3(cornerPositionX[i], 0, cornerPositionZ[i]);
               /* if (directionX == 0 && roadPositionX[second] > 0)
                {
                    cornerPositionX[i] -= 0.05f;
                }
                else if (directionX == 0 && roadPositionX[second] < 0)
                {
                    cornerPositionX[i] += 0.05f;
                }
                else if (directionZ == 0 && roadPositionZ[second] > 0)
                {
                    cornerPositionZ[i] -= 0.05f;
                }
                else if (directionZ == 0 && roadPositionZ[second] < 0)
                {
                    cornerPositionZ[i] += 0.05f;
                }*/
            }
            roadPositionX[i] -= (float)(Time.deltaTime * speed* directionX);
            roadPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
        /*    if(directionX==0&& roadPositionX[second] >0)
            {
                roadPositionX[i] -= 0.05f;
            }
            else if(directionX == 0 && roadPositionX[second] < 0)
            {
                roadPositionX[i] += 0.05f;
            }
            else if (directionZ == 0 && roadPositionZ[second] > 0)
            {
                roadPositionZ[i] -= 0.05f;
            }
            else if (directionZ == 0 && roadPositionZ[second] < 0)
            {
                roadPositionZ[i] += 0.05f;
            }*/
        

        roadblock[i].transform.position = new Vector3(roadPositionX[i], 0, roadPositionZ[i]);
        roadblock[i].transform.rotation = Quaternion.Euler(0, roadRotationY[i], 0);
        }
        if ((Input.GetKey(KeyCode.UpArrow)))
        {
            if(speed<16)
            {
                speed += 0.5f;
            }
        }
        else
        {
            if(speed>8)
            {
                speed -= 0.5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            
            if(directionX== 1)
            {
                
                directionX = 0;
                directionZ = -1;
            }
            else if (directionX == -1)
            {
                directionX = 0;
                directionZ = 1;
            }
            else if (directionZ == 1)
            {
                directionZ = 0;
                directionX = 1;
            }
            else if (directionZ == -1)
            {
                directionZ = 0;
                directionX = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
  
            Debug.Log("L");
            if (directionX == 1)
            {
                directionX = 0;
                directionZ = 1;
            }
            else if (directionX == -1)
            {
                directionX = 0;
                directionZ = -1;
            }
            else if (directionZ == 1)
            {
                directionZ = 0;
                directionX = -1;
            }
            else if(directionZ == -1)
            {
                directionZ = 0;
                directionX = 1;
            }

        }

        if (System.Math.Abs(roadPositionX[first]) + System.Math.Abs(roadPositionZ[first]) > 12 && player.transform.position.y>1.4)
        {
            for(int i=0;i<4;i++)
            {
                if(System.Math.Abs(roadPositionX[first]- cornerPositionX[i])+ System.Math.Abs(roadPositionZ[first] - cornerPositionZ[i])<=6.1)
                {
                    cornerPositionX[i] = 10000;
                    cornerPositionZ[i] = 10000;
                }
            }
            if (trans > 0) trans--;
            float last_X = roadPositionX[(first + 11) % 12];
            float last_Z = roadPositionZ[(first + 11) % 12];
            if (Random.value > 0.9 &&trans<=0)
            {
                trans = 3;
                curentY += 90;
                cornerNum = cornerNum % 4;
                if (roadDirectionX==1)
                {
                    if (Random.value > 0.5)
                    {
                        cornerPositionX[cornerNum] = last_X + 6;
                        cornerPositionZ[cornerNum] = last_Z;
                        cornerRotationY[cornerNum] = 270;
                        corner[cornerNum].transform.position = new Vector3(last_X + 6, 0, last_Z);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_X += 6;
                        roadDirectionX = 0;
                        roadDirectionZ = -1;

                    }
                    else
                    {
                        cornerRotationY[cornerNum] = 0;
                        cornerPositionX[cornerNum] = last_X + 6;
                        cornerPositionZ[cornerNum] = last_Z;
                        corner[cornerNum].transform.position = new Vector3(last_X + 6, 0, last_Z);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_X += 6;
                        roadDirectionX = 0;
                        roadDirectionZ = 1;
                    }
;
                    

                }
                else if(roadDirectionX==-1)
                {
                    if (Random.value > 0.5)
                    {
                        cornerRotationY[cornerNum] = 90;
                        cornerPositionX[cornerNum] = last_X - 6;
                        cornerPositionZ[cornerNum] = last_Z;
                        corner[cornerNum].transform.position = new Vector3(last_X - 6, 0, last_Z);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_X -= 6;
                        roadDirectionX = 0;
                        roadDirectionZ = 1;

                    }
                    else
                    {
                        cornerRotationY[cornerNum] = 180;
                        cornerPositionX[cornerNum] = last_X - 6;
                        cornerPositionZ[cornerNum] = last_Z;
                        corner[cornerNum].transform.position = new Vector3(last_X - 6, 0, last_Z);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_X -= 6;
                        roadDirectionX = 0;
                        roadDirectionZ = -1;
                    }
                }
                else if (roadDirectionZ == 1)
                {
                    if (Random.value > 0.5)
                    {
                        cornerRotationY[cornerNum] = 180;
                        cornerPositionX[cornerNum] = last_X;
                        cornerPositionZ[cornerNum] = last_Z + 6;
                        corner[cornerNum].transform.position = new Vector3(last_X , 0, last_Z+6);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_Z += 6;
                        roadDirectionX = 1;
                        roadDirectionZ = 0;

                    }
                    else
                    {
                        cornerRotationY[cornerNum] = 270;
                        cornerPositionX[cornerNum] = last_X;
                        cornerPositionZ[cornerNum] = last_Z + 6;
                        corner[cornerNum].transform.position = new Vector3(last_X, 0, last_Z + 6);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        last_Z += 6;
                        cornerNum++;
                        roadDirectionX = -1;
                        roadDirectionZ = 0;
                    }
                }
                else
                {
                    if (Random.value > 0.5)
                    {
                        cornerRotationY[cornerNum] = 0;
                        cornerPositionX[cornerNum] = last_X;
                        cornerPositionZ[cornerNum] = last_Z - 6;
                        corner[cornerNum].transform.position = new Vector3(last_X, 0, last_Z - 6);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        cornerNum++;
                        last_Z -= 6;
                        roadDirectionX = -1;
                        roadDirectionZ = 0;

                    }
                    else
                    {
                        cornerRotationY[cornerNum] = 90;
                        cornerPositionX[cornerNum] = last_X;
                        cornerPositionZ[cornerNum] = last_Z - 6;
                        corner[cornerNum].transform.position = new Vector3(last_X, 0, last_Z - 6);
                        corner[cornerNum].transform.rotation = Quaternion.Euler(0, cornerRotationY[cornerNum], 0);
                        last_Z -= 6;
                        cornerNum++;
                        roadDirectionX = 1;
                        roadDirectionZ = 0;
                    }
                }
            }
            else if ( Random.value > 0.8 && trans <= 0)
            {
                trans += 3;
                if(roadDirectionX != 0)
                    last_X += roadDirectionX * Random.value *  6+ 6 ;
                else
                    last_Z += roadDirectionZ * Random.value *  6 + 6;
            }
            roadRotationY[first] = curentY;
            if (roadDirectionX == 1)
            {

                roadPositionX[first] = last_X + 6;
                roadPositionZ[first] = last_Z;
                roadblock[first].transform.position = new Vector3(roadPositionX[first], 0, roadPositionZ[first]);
            }

            if (roadDirectionX == -1)
            {


                roadPositionX[first] = last_X - 6;
                roadPositionZ[first] = last_Z;
                roadblock[first].transform.position = new Vector3(roadPositionX[first], 0, roadPositionZ[first]);
            }

            if (roadDirectionZ == 1)
            {

                roadPositionX[first] = last_X ;
                roadPositionZ[first] = last_Z + 6;
                roadblock[first].transform.position = new Vector3(roadPositionX[first], 0, roadPositionZ[first]);
            }

            if (roadDirectionZ == -1)
            {


                roadPositionX[first] = last_X;
                roadPositionZ[first] = last_Z - 6;
                roadblock[first].transform.position = new Vector3(roadPositionX[first], 0, roadPositionZ[first]);
            }
            first = (first + 1) % 12;
            loc = 0;
            
        }

    }

}

