using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetainData : MonoBehaviour
{
    public static RetainData data;
    public int LevelNum = 1;//the current level the player is playing
    //each scene/level the player unlocks a new ability
    //add if-then stuff to activate new abilities based on level

    // Start is called before the first frame update
    public void Start()
    {
        data = this; //set this object to the static instance
                     //retaindata.data.FunctionName(); to call functions
        //messageObject = GameObject.Find("messagebox");
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
        /*
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}*/ 
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        LevelNum += 1;//if on level1, go to level 2, if on level 2, go to level 3, etc
        SceneManager.LoadScene("Level"+LevelNum);
    }

}
