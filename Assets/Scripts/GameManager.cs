using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    LevelPanel levelPanel;
    LevelManager levelManager;

    [SerializeField]
    string kazananOyuncuyaGosterilecekMesaj = "Tebrikler!";
    int oyuncununEristigiSeviye = 0;

    private void Awake()
    {
        levelPanel = FindObjectOfType<LevelPanel>().GetComponent<LevelPanel>();
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();


    }
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SeviyeyiArttir()
    {
        ++oyuncununEristigiSeviye;
        EkraniGuncelle();
        if (oyuncununEristigiSeviye >= 3)
        {
            Debug.Log("You Won!");
            levelManager.SonrakiBolumuOlustur();
            EkraniGuncelle(kazananOyuncuyaGosterilecekMesaj);
        }
    }

    void EkraniGuncelle()
    {
        levelPanel.SeviyeyiGuncelle(oyuncununEristigiSeviye);
    }

    void EkraniGuncelle(string mesaj)
    {
        levelPanel.SeviyeyiGuncelle(mesaj);
    }

}
