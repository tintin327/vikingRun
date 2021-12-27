using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class groundControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] roadblock;
    public GameObject player;
    public GameObject[] corner = new GameObject[4];
    public GameObject[] coin = new GameObject[12];
    public GameObject[] sement = new GameObject[12];
    public float[] roadPositionX;
    public float[] roadPositionZ;
    public float[] roadRotationY;
    public float[] cornerPositionX = new float[4];
    public float[] cornerPositionZ = new float[4];
    public float[] cornerRotationY = new float[4];
    public float[] coinPositionX = new float[12];
    public float[] coinPositionZ = new float[12];
    public float[] sementPositionX = new float[12];
    public float[] sementPositionZ = new float[12];
    public float[] coinRotationY = new float[12];
    public float speed = 8;
    public int directionX = 1;
    public int directionZ = 0;
    string latestTriggerCion = "";
    int die = 0;
    int point = 0;
    int dietrigger;
    int roadDirectionX = 1;
    int roadDirectionZ = 0;
    public int transition = 0;
    int cornerNum = 0;
    int first;
    int loc = 0;
    int sementid = 0;
    int trans = 0;
    int coinid = 0;
    int curentY = 90;
    int triggerid = -1;
    public int start = 0;
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
        
        for(int i=0;i<12;i++)
        {
            coin[i] = GameObject.Find("coin (" + System.Convert.ToString(i) + ")");
            coinPositionX[i] = 10000;
            coinPositionZ[i] = 10000;
            coinRotationY[i] = 0;
            coin[i].transform.position = new Vector3(10000, 0,10000);
            coin[i].transform.rotation = Quaternion.Euler(90,0, 90);

            sement[i] = GameObject.Find("sement (" + System.Convert.ToString(i) + ")");
            sementPositionX[i] = 10000;
            sementPositionZ[i] = 10000;
            coin[i].transform.position = new Vector3(10000, 0, 10000);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(die==1 && start == 1)
        {
            start = 0;
            speed = 0;
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.S)&& start==0)
        {
            start = 1;
            speed = 8;
        }

        else if (Input.GetKeyDown(KeyCode.S) && start == 1)
        {
          
            start = 0;
            speed = 0;
            SceneManager.LoadScene(0);
        }


        if (player.transform.position.y < -40)
            die = 1;
        if(GameObject.Find("viking").GetComponent<character>().latestTrigger.Length>=10)
        {
            
            for (int i = 0; i < 12; i++)
            {
                if (string.Equals("sement (" + System.Convert.ToString(i) + ")", latestTriggerCion))
                {
                    dietrigger = i;
                    sementPositionX[i] = 10000;
                    sementPositionZ[i] = 10000;
                    sement[i].transform.position = new Vector3(10000, 0, 10000);
                    break;
                }
            }
            


            
            
            speed = 1;
            if(GameObject.Find("viking").GetComponent<character>().rx> 90)
            {
                speed = 0;
                die = 1;
            }
               
        }
       
        if (point != GameObject.Find("viking").GetComponent<character>().coinPoint)
        {
            point = GameObject.Find("viking").GetComponent<character>().coinPoint;
            latestTriggerCion = GameObject.Find("viking").GetComponent<character>().latestTrigger;
            
            for (int i = 0; i < 12; i++)
            {
                if(string.Equals("coin (" + System.Convert.ToString(i) + ")",latestTriggerCion))
                {
                    triggerid = i;
                    break;
                }
            }


        }

        GameObject[] roadblock = GameObject.Find("Ground").GetComponent<roadSpawn>().roadblock;
        int second = (first + 1) % 12;
        if(start==0)
        {
            speed = 0;
        }
        for (int i = 0; i < 12; i++)
        {
       
            if(i<4)
            {
                cornerPositionX[i] -= (float)(Time.deltaTime * speed * directionX);
                cornerPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
                corner[i].transform.position = new Vector3(cornerPositionX[i], 0, cornerPositionZ[i]);
            }
            roadPositionX[i] -= (float)(Time.deltaTime * speed* directionX);
            roadPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
            coinPositionX[i] -= (float)(Time.deltaTime * speed * directionX);
            coinPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
            sementPositionX[i] -= (float)(Time.deltaTime * speed * directionX);
            sementPositionZ[i] -= (float)(Time.deltaTime * speed * directionZ);
            coinRotationY[i] += 1.8f;
            if(i==triggerid)
            {
                coinRotationY[i] += 8f;
            }


            roadblock[i].transform.position = new Vector3(roadPositionX[i], 0, roadPositionZ[i]);
            roadblock[i].transform.rotation = Quaternion.Euler(0, roadRotationY[i], 0);
            sement[i].transform.position = new Vector3(sementPositionX[i], sement[i].transform.position.y, sementPositionZ[i]);
            coin[i].transform.position = new Vector3(coinPositionX[i], coin[i].transform.position.y, coinPositionZ[i]);
            if (i == triggerid)
            {
                coin[i].transform.position = new Vector3(coinPositionX[i], coin[i].transform.position.y+0.5f, coinPositionZ[i]);
            }
            coin[i].transform.rotation = Quaternion.Euler(90, coinRotationY[i], 90);
        }
        
        if ((Input.GetKey(KeyCode.UpArrow))&&start==1)
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
           
            for (int i=0;i<4;i++)
            {
                if(System.Math.Abs(roadPositionX[first]- cornerPositionX[i])+ System.Math.Abs(roadPositionZ[first] - cornerPositionZ[i])<=6.1)
                {
                    cornerPositionX[i] = 10000;
                    cornerPositionZ[i] = 10000;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (System.Math.Abs(roadPositionX[first] - coinPositionX[i]) + System.Math.Abs(roadPositionZ[first] - coinPositionZ[i]) <= 6.1)
                {
                    coinPositionX[i] = 10000;
                    coinPositionZ[i] = 10000;
                }

                if (System.Math.Abs(roadPositionX[first] - sementPositionX[i]) + System.Math.Abs(roadPositionZ[first] - sementPositionZ[i]) <= 6.1)
                {
                    sementPositionX[i] = 10000;
                    sementPositionZ[i] = 10000;
                }
            }
            if (trans > 0) trans--;
            float last_X = roadPositionX[(first + 11) % 12];
            float last_Z = roadPositionZ[(first + 11) % 12];
            if (Random.value > 0.8)
            {
                coinPositionX[coinid] = last_X;
                coinPositionZ[coinid] = last_Z;
                if (Random.value > 0.5)
                    coin[coinid].transform.position = new Vector3(last_X, Random.value * 6 + 2, last_Z);
                else
                    coin[coinid].transform.position = new Vector3(last_X, 2, last_Z);
                coinid++;
                coinid = coinid % 12;
            }

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
            else if (Random.value > 0.8 && trans <= 0)
            {
                trans += 3;
                sementPositionX[sementid] = last_X;
                sementPositionZ[sementid] = last_Z;
                if (Random.value > 0.5)
                    sement[sementid].transform.position = new Vector3(last_X, Random.value * 6 + 2, last_Z);
                else
                    sement[sementid].transform.position = new Vector3(last_X, 2, last_Z);
                sement[sementid].transform.rotation = Quaternion.Euler(0, curentY-90, 0);
                sementid++;
                sementid = sementid % 12;
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

