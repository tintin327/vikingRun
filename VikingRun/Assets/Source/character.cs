using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public class character : MonoBehaviour
{
    GameObject player;
    public float count;
    public float jumpforce;
    float character_y;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("viking");
        jumpforce = 500f;
        count = 90;
        rb = GetComponent<Rigidbody>();
        character_y = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            count -= 90;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            count += 90;
        }


        if (player.transform.position.y < 1.5001 && player.transform.position.y > 1.4999 && Input.GetKeyDown(KeyCode.Space))
        {     
            rb.AddForce(jumpforce * Vector3.up);
        }
        if (count - character_y > 1)
        {
            character_y += 18f;
            player.transform.rotation = Quaternion.Euler(0, character_y, 0);
        }
        else if (count - character_y < -1)
        {

            character_y -= 18f;
            player.transform.rotation = Quaternion.Euler(0, character_y, 0);
        }
    }



}
