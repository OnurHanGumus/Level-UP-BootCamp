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

    private void Start()
    {
        GameManager.gameManager.InitAgain();
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
        }
        else
        {
            mesajTxt.text = "Baþarýsýz:\nTekrar deneyiniz.";
            eylemBtn.transform.GetChild(0).GetComponent<Text>().text = "Tekrar Dene";

        }
        
    }

    public void EylemBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //PlayerMovement.bekle = false;
    }
    public void CikisBtn()
    {
        Application.Quit();
    }

}
