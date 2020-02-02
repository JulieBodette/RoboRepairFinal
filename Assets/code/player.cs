using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jumpspeed = 50f;
    Rigidbody2D rb;
    public float speed = 5f;
    Vector3 moveleft = new Vector3(-1, 0, 0);
    Vector3 moveright = new Vector3(1, 0, 0);
    Vector3 moveup = new Vector3(0, 1, 0);
    Vector3 movedown = new Vector3(0, -1, 0);
    SpriteRenderer spriterenderer;
    int numBolts = 0;//set to 0 by default
    public bool playercanMove = true;//the player cant move when text is displayed
    bool facingRight = true; //starts out facing right ofc
    // Start is called before the first frame update
    public GameObject Leftlaser;//set this to the laser prefab, the laser prefab has the info about what direction it goes
    public GameObject Rightlaser;//set this to the laser prefab, the laser prefab has the info about what direction it goes
    void Start()
    {
        //THIS IS GOOD CODE TO USEEEEEEEE
        //****************************
        //*********************************************
        //FindObjectOfType<EnemySpawner>().SpawnWaves();
        spriterenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //the number of bolts on the screen-how many the player has to collect to get to exit
        numBolts = GameObject.FindGameObjectsWithTag("Bolt").Length;
    }
    public void setplayercanMove(bool cantmove)
    {
        playercanMove = cantmove;
    }
    // Update is called once per frame
    void Update()
    {
        //press esc to quit
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{Application.Quit(); }
        //press esc to quit code is on pressEsctoQuit.cs
        if (playercanMove == true)//only update the player position if the player can move
                                  //ie only update player position if it has not been disabled by text appearing onscreen
        {
            //always move to the right no matter what
            transform.position += moveright * Time.deltaTime * speed;
            //face right
            bool facingRight = true;
            spriterenderer.flipX = false;//flips the sprite only- not any colliders
                                         //this code (2 lines above) should be overriden by go backwards (faces left)-fingers crossed
            if (FindObjectOfType<RetainData>().LevelNum >= 6)//can do this ability at level 6 and later
            {
                //a is go backwards
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += moveleft * Time.deltaTime * speed * 2;
                    //face left
                    facingRight = false;
                    spriterenderer.flipX = true; //flips the sprite only- not any colliders
                }
            }

            if (FindObjectOfType<RetainData>().LevelNum >= 4)//can do this ability at level 4 and later
            {
                //s is stop
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += moveleft * Time.deltaTime * speed;
                }
            }
            if (FindObjectOfType<RetainData>().LevelNum >= 2)//can do this ability at level 2 and later
            {
                ///jump a little bit (not very high)
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += moveup * Time.deltaTime * speed;
                }
            }

            //move downwards
            //if (Input.GetKey(KeyCode.X))
            //{ transform.position += movedown* Time.deltaTime * speed;  }
            //jump very high aka yeet yourself to the ceiling-this is glitchy AF
            //rb.AddForce(new Vector2(0, jumpspeed) * speed * Time.deltaTime, ForceMode2D.Impulse);
            if (FindObjectOfType<RetainData>().LevelNum >= 9)//can do this ability at level 9 and later
            {

                if (Input.GetKey(KeyCode.Space))
                {
                    //shoot laser
                    //if facing left shoot to left if right right
                    Debug.Log("shooting laser");
                    if (facingRight == true)
                    {
                        Instantiate(Rightlaser, this.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        Instantiate(Leftlaser, this.transform.position, this.transform.rotation);
                    }

                }
            }

        }
    }
                
            
        

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bolt")
        {
            Destroy(other.gameObject);
            numBolts -= 1;
            Debug.Log("Bolts left to collect this level:" + numBolts.ToString());
            if (numBolts <= 0)
            {
                //if numbolts = 0, then open door
                OpenAllDoors();
            }
        }
        
        if (other.gameObject.tag == "Spikes")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //hit spikes and die
            //reload the current scene

        }
    }

    void OpenAllDoors()
    //note: this technically finds all doors in the level
    //if multiple doors are added, mess with this code-it might cause bugs
    //cause it will affect all the doors
    {
        Door[] doors = GameObject.FindObjectsOfType<Door>();
        //Door nearestEnemy = null;
        foreach (Door d in doors)
        {
            d.isOpen = true;
        }
    }
}
