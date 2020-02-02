using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressEsctoQuit : MonoBehaviour
{
    void Update()
    {
        //press esc to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);//this object will not be destroyed when a new scene loads
        //so this code will always run in the background and you can always press esc to exit
        //ps this code only works on a finished build, not in the editor
        /*
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}*/
    }
}
