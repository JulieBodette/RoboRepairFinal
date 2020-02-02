using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Vector3 movementvector = new Vector3(1, 0, 0);
    public int direction = 1;
    public float speed = 5f;
    //-1 is left, 1 is right
    //set to move to the right by default

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*movementvector* Time.deltaTime * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destructible")
        {
            Destroy(other.gameObject);
        }
    }
}
