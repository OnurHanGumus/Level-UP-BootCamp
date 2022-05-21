using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSc : MonoBehaviour
{
    public FixedJoystick joystick;

    Rigidbody rb;



    public float baslangicKenarSinirDegeri = 0.4f;
    public PlayerMovementScScriptableObject scriptableObject;

    private void Awake()
    {
        Debug.Log("Debug message for commit.");
        rb = GetComponent<Rigidbody>();
        baslangicKenarSinirDegeri = scriptableObject.baslangicKenarSinirDegeri;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if ((transform.position.x < -baslangicKenarSinirDegeri) && joystick.Horizontal < 0f)
        {
            rb.velocity = new Vector3(0, 0, scriptableObject.speed);

        }
        else if ((transform.position.x > baslangicKenarSinirDegeri) && joystick.Horizontal > 0f)
        {
            rb.velocity = new Vector3(0, 0, scriptableObject.speed);

        }
        else
        {
            rb.velocity = new Vector3(joystick.Horizontal, 0, scriptableObject.speed);

        }
    }
}
