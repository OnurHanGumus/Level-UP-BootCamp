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
    public bool bekle = false;
    public static bool keybedildi = false;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baslangicKenarSinirDegeri = scriptableObject.baslangicKenarSinirDegeri;
        speed = scriptableObject.speed;
        joystick = FindObjectOfType<FixedJoystick>();


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
            other.tag = "Untagged";
            StartCoroutine(KarakteriDuraklat());
            Debug.Log("çalýþtý");
        }
        if (other.tag == "bitisCizgisi")
        {
            GameManager.gameManager.OyuncuBitisCizgisineUlasti();
            KarakteriDurdur();

        }
    }

    IEnumerator KarakteriDuraklat()
    {
        if (bekle)
        {
            yield return new WaitForSeconds(0.1f);

        }

        bekle = true;
        yield return new WaitForSeconds(2);
        if (GameManager.gameManager.topSayisinaUlasildi == true)
        {
            GameManager.gameManager.topSayisinaUlasildi = false;
            bekle = false;

        }


       
       
    }

    public void KarakteriDurdur()
    {   
        bekle = true;
       
    }
}
