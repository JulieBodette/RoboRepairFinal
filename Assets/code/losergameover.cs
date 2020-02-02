using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class losergameover : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("CapsuleCollider2D");
        if (collision.gameObject.tag =="Player")
        { SceneManager.LoadScene("Gameover");

            Debug.Log("game over");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
