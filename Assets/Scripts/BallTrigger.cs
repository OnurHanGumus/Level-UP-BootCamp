using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public int topSayisi = 0;

    
    public int istenenTopSayisi = 5;

    GameObject anaPlatform;
    Transform parent;
    ColliderToFit colliderToFit;
    [SerializeField] PlatformCanvas platformCanvas;
    private void Awake()
    {
        anaPlatform = GameObject.FindGameObjectWithTag("anaPlatform");
        colliderToFit = anaPlatform.GetComponent<ColliderToFit>();
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

            if (topSayisi >= istenenTopSayisi)
            {
                IstenenTopSayisinaUlasildi();
            }
        }
       
    }


    void IstenenTopSayisinaUlasildi()
    {
        parent.position = new Vector3(transform.parent.position.x, 0, transform.parent.position.z);
        parent.parent = anaPlatform.transform; //kýrýkplatformu da anaplatforma ekleyip anaplatformun colliderini tekrar konumlandýrýyor.
        colliderToFit.FitToChildren();
    }

    
}
