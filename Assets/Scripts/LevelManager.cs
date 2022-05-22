using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int[] bolumunBelirlenmisSeviyeIdleri;
    [SerializeField]
    int mevcutBolumSayisi = 3;
    private void Awake()
    {
        bolumunBelirlenmisSeviyeIdleri = new int[3];
        bolumunBelirlenmisSeviyeIdleri[0] = PlayerPrefs.GetInt("birinciBolum", 0);
        bolumunBelirlenmisSeviyeIdleri[1] = PlayerPrefs.GetInt("ikinciBolum", 0);
        bolumunBelirlenmisSeviyeIdleri[2] = PlayerPrefs.GetInt("ucuncuBolum", 0);
    }
  

    public int[] MevcutBolumuDondur()
    {
        return bolumunBelirlenmisSeviyeIdleri;
    }

    public void SonrakiBolumuOlustur()
    {
        int rand = 0;
        
        rand = GetRandomNumber();
        bolumunBelirlenmisSeviyeIdleri[0] = rand;
        PlayerPrefs.SetInt("birinciBolum", rand);

        rand = GetRandomNumber();
        bolumunBelirlenmisSeviyeIdleri[1] = rand;
        PlayerPrefs.SetInt("ikinciBolum", rand);

        rand = GetRandomNumber();
        bolumunBelirlenmisSeviyeIdleri[2] = rand;
        PlayerPrefs.SetInt("ucuncuBolum", rand);

    }

    int GetRandomNumber()
    {
        return Random.Range(0, mevcutBolumSayisi);
    }
}
