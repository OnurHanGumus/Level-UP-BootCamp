using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] Text levelTxt = null;


    private void Awake()
    {
        levelTxt = transform.GetChild(0).GetComponent<Text>();
    }
    void Start()
    {
        levelTxt.text = 0.ToString();
     
    }

    public void SeviyeyiGuncelle(int yeniSeviye)
    {
        levelTxt.text = yeniSeviye.ToString();
    }
    public void SeviyeyiGuncelle(string mesaj)
    {
        levelTxt.text = mesaj;
    }

}
