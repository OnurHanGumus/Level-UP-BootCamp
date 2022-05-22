using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;
    public PlayerMovementScScriptableObject scriptableObject;


    Rigidbody rb;


    public float baslangicKenarSinirDegeri = 0.4f;
    int speed = 5;
    bool bekle = false;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baslangicKenarSinirDegeri = scriptableObject.baslangicKenarSinirDegeri;
        speed = scriptableObject.speed;


    }

    void FixedUpdate()
    {
        if (bekle)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }

        if ((transform.position.x < -baslangicKenarSinirDegeri) && joystick.Horizontal < 0f)
        {
            rb.velocity = new Vector3(0, 0, speed);

        }
        else if ((transform.position.x > baslangicKenarSinirDegeri) && joystick.Horizontal > 0f)
        {
            rb.velocity = new Vector3(0, 0, speed);

        }
        else
        {
            rb.velocity = new Vector3(joystick.Horizontal, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gate")
        {
            StartCoroutine(KarakteriDuraklat());
        }
        if (other.tag == "bitisCizgisi")
        {
            StartCoroutine(KarakteriDurdur());

        }
    }

    IEnumerator KarakteriDuraklat()
    {
        bekle = true;
        yield return new WaitForSeconds(2);
        bekle = false;
    }

    IEnumerator KarakteriDurdur()
    {
        bekle = true;
        yield return new WaitForSeconds(1);
    }
}
