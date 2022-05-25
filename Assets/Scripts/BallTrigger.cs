using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public int topSayisi = 0;

    float platformSpeed = 1f;
    public int istenenTopSayisi = 5;



    Transform parent;
    [SerializeField] PlatformCanvas platformCanvas;
    private void Awake()
    {

        parent = transform.parent;

    }

    private void Start()
    {
        platformCanvas.GuncellenenTextiGoster(topSayisi, istenenTopSayisi);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectable") 
        {
            ++topSayisi;
            platformCanvas.GuncellenenTextiGoster(topSayisi, istenenTopSayisi);

            Destroy(other.gameObject, 1f);


        }

        if (other.tag == "Player")
        {
            StartCoroutine(TopSayisiniKontrolEt());

        }

    }




    void IstenenTopSayisinaUlasildi()
    {
        parent.position = Vector3.MoveTowards(parent.position, new Vector3(transform.parent.position.x, -0.015f, transform.parent.position.z), 1f) ;
        GameManager.gameManager.SeviyeyiArttir();

    }

    void IstenenTopSayisinaUlasilamadi()
    {
        GameManager.gameManager.Basarisiz();

    }

    IEnumerator TopSayisiniKontrolEt()
    {
        yield return new WaitForSeconds(0.5f);

        if ((topSayisi >= istenenTopSayisi))
        {
            IstenenTopSayisinaUlasildi();
        }
        else
        {
            IstenenTopSayisinaUlasilamadi();
        }

       
    }


}
