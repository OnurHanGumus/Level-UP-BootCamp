using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public int topSayisi = 0;

    
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

            if (topSayisi == istenenTopSayisi)
            {
                IstenenTopSayisinaUlasildi();
            }
            Destroy(other.gameObject, 1f);
        }
       
    }


    void IstenenTopSayisinaUlasildi()
    {
        parent.position = new Vector3(transform.parent.position.x, -0.01f, transform.parent.position.z);
        GameManager.gameManager.SeviyeyiArttir();
        
    }

    
}
