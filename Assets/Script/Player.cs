using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float forwardforces = 1000f;
    public float sideways = 500f;
    public Rigidbody rb;
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardforces * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce( sideways * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a"))
        {
            rb.AddForce(-sideways * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }
}
