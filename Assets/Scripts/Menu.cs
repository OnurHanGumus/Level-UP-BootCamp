using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    [SerializeField] Text mesajTxt;
    [SerializeField] Button eylemBtn, cikBtn;
    [SerializeField] Transform fader;

    private void Start()
    {
        GameManager.gameManager.InitAgain();
        FadeOut(fader);

    }
    public void FadeIn(Transform menu, float time = 0.5f)
    {
        menu.GetComponent<CanvasGroup>().DOFade(1, time);
        menu.GetComponent<CanvasGroup>().blocksRaycasts = true;


    }
    public void FadeOut(Transform menu, float time = 0.5f)
    {
        menu.GetComponent<CanvasGroup>().DOFade(0, time);
        menu.GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    public void MenuAcil(bool oyunKazanildi)
    {
        FadeIn(transform);
        if (oyunKazanildi)
        {
            mesajTxt.text = "Tebrikler:\nBölümü tamamladýnýz.";
            eylemBtn.transform.GetChild(0).GetComponent<Text>().text = "Sonraki Bölüm";
            eylemBtn.onClick.AddListener(SonrakiBolumBtn);

        }
        else
        {
            mesajTxt.text = "Baþarýsýz:\nTekrar deneyiniz.";
            eylemBtn.transform.GetChild(0).GetComponent<Text>().text = "Tekrar Dene";
            eylemBtn.onClick.AddListener(TekrarDeneBtn);
        }
    }

    public void SonrakiBolumBtn()
    {
        FadeOut(transform);
        Invoke("SahneyiYukle", 1f);
    }

    public void TekrarDeneBtn()
    {
        FadeIn(fader);
        FadeOut(transform);
        Invoke("SahneyiYukle", 1f);
    }



    void SahneyiYukle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void CikisBtn()
    {
        Application.Quit();
    }

}
