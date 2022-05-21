using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstantiator : MonoBehaviour
{
    [SerializeField] int maksimumTopOlusturmaMesafesi = 10, topSayisiXekseni = 2, topSayisiYekseni = 10, sonTopKonulanNoktaZ = 0;
    [SerializeField] GameObject collectablePrefab = null;
    [SerializeField] float toplarinBirbiriyleMesafesi = 0.1f; 

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   

    void Update()
    {
        if (transform.position.z - sonTopKonulanNoktaZ >= maksimumTopOlusturmaMesafesi)
        {
            ToplariYerlestir();

        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 5);

    }

    void ToplariYerlestir()
    {
        sonTopKonulanNoktaZ = (int)transform.position.z;
        RastgeleSayidaTopOlusturEksenZ();
        float xEkseni = RastgeleKonumOlusturEksenX();

        Vector3 uzaklik = new Vector3(xEkseni, transform.position.y, transform.position.z);
        for (int i = 0; i < topSayisiXekseni; i++)
        {
            for (int j = 0; j < topSayisiYekseni; j++)
            {
                Instantiate(collectablePrefab, uzaklik, Quaternion.identity);
                Debug.Log(uzaklik);
                uzaklik = new Vector3(uzaklik.x, uzaklik.y, uzaklik.z + toplarinBirbiriyleMesafesi);
            }
            uzaklik = new Vector3(uzaklik.x + toplarinBirbiriyleMesafesi, transform.position.y, uzaklik.z - (toplarinBirbiriyleMesafesi * topSayisiYekseni));

        }
    }


    void RastgeleSayidaTopOlusturEksenZ()
    {
        int rand = Random.Range(1, 10);
        topSayisiYekseni = rand;
    }

    float RastgeleKonumOlusturEksenX()
    {
        return Random.Range(-0.4f, 0.4f);
        
    }

}