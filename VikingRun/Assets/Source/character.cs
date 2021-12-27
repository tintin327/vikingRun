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
    public Animator animator;
    float character_y;
    public int rx = 0;
    bool run;
    Rigidbody rb;
    public int coinPoint = 0;
    bool die = false;
    bool jump = false;
    public string latestTrigger = "";
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("viking");
        jumpforce = 500f;
        count = 90;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        character_y = 90;
        run = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        latestTrigger = other.name;
        if (other.name.Length < 10)
        {
            coinPoint++;
        }
        else
            die = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        run = (player.transform.position.y < 1.5001 && player.transform.position.y > 1.4999) && (GameObject.Find("Ground_control").GetComponent<groundControl>().start == 1 )&&(!die);
        jump =!( player.transform.position.y < 1.5001 && player.transform.position.y > 1.4999);

        if (latestTrigger.Length>=10)
        {
            if(rx < 100)
                rx += 1;
            player.transform.rotation = Quaternion.Euler(rx, character_y, 0);
            
        }
        
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
            if(GameObject.Find("Ground_control").GetComponent<groundControl>().start==1)
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

        animator.SetBool("Run",run);
        animator.SetBool("Die", die);
        animator.SetBool("Jump", jump);
    }



}
