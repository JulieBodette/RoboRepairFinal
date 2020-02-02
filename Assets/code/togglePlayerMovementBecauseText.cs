using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglePlayerMovementBecauseText : MonoBehaviour
{
    public GameObject TextBox; //reference to the textbox
    //DO NOT FORGET TO PUT A REFERENCE TO THE TEXT BOX OR THIS GAME WILL NOT WORK!!

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<player>().setplayercanMove(false);//player starts out unable to move 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        { //if the player presses enter or clicks
            TextBox.SetActive(false);//deactivate text
            GameObject.FindObjectOfType<player>().setplayercanMove(true);//player can move
        }
    }
}
