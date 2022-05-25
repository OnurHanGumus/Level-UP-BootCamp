using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    LevelPanel levelPanel;
    LevelManager levelManager;
    SceneLoader sceneLoader;
    Menu menu;
    [SerializeField]
    public bool topSayisinaUlasildi = false;




    [SerializeField]
    string kazananOyuncuyaGosterilecekMesaj = "Tebrikler!";

    public bool oyunKazanildi = false;
    public bool oyunKaybedildi = false;

    public int oyuncununEristigiSeviye = 0;

    private void Awake()
    {
        levelPanel = FindObjectOfType<LevelPanel>().GetComponent<LevelPanel>();
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        menu = FindObjectOfType<Menu>().GetComponent<Menu>();

    }

    
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>();

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
        topSayisinaUlasildi = true;
        EkraniGuncelle();
       
    }

    void EkraniGuncelle()
    {
        levelPanel.SeviyeyiGuncelle(oyuncununEristigiSeviye);
    }

    void EkraniGuncelle(string mesaj)
    {
        levelPanel.SeviyeyiGuncelle(mesaj);
    }

    public void OyuncuBitisCizgisineUlasti()
    {
        oyunKazanildi = true; //sonraki seviye butonuna týklandýðýnda (Menu script) false edilir.
        menu.MenuAcil(oyunKazanildi);
        Debug.Log("You Won!");
        levelManager.SonrakiBolumuOlustur();
        sceneLoader.OyunBittiSonrakiBolumuYukle();
        EkraniGuncelle(kazananOyuncuyaGosterilecekMesaj);
    }

    public void Basarisiz()
    {
    
        menu.MenuAcil(oyunKazanildi);
      
    }

    public void InitAgain()
    {
        oyuncununEristigiSeviye = 0;
        levelPanel = FindObjectOfType<LevelPanel>().GetComponent<LevelPanel>();
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        menu = FindObjectOfType<Menu>().GetComponent<Menu>();

    }

}
