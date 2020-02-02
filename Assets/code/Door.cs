using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool isOpen = false;//if door is open, looks different and player can go thru it to next lvl
    public Sprite opendoor;
    //SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        //spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true)
        {
            //Debug.Log("the door is open");
            this.GetComponent<SpriteRenderer>().sprite = opendoor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("Level2");//change this later so it loads a new level every time
            //FindObjectOfType<EnemySpawner>().SpawnWaves();
            if (isOpen == true)
            {
                FindObjectOfType<RetainData>().LoadNextLevel();
            }
        }
    }
}
