using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    List<GameObject> scenesCanBeLoad, scenesLoaded;
    [SerializeField]
    Transform player;

    public int currentScene = 0;

    LevelManager levelManager;
    int[] bolumunBelirlenmisSeviyeIdleri;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();

    }
    private void Start()
    {
        bolumunBelirlenmisSeviyeIdleri = levelManager.MevcutBolumuDondur();

    }


    private void Update()
    {
        if (player.position.z >= 22.85f * currentScene - 11)
        {
            LoadLevel();
            currentScene++;
        } 
    }

    void LoadLevel()
    {
        if (currentScene >= 3)
        {
            Debug.Log("You Won!");
            levelManager.SonrakiBolumuOlustur();
        }
        else
            scenesLoaded.Add(Instantiate(scenesCanBeLoad[bolumunBelirlenmisSeviyeIdleri[currentScene]], new Vector3(0, -0.01f * currentScene, 22.85f * currentScene), Quaternion.identity));
    }

  



   

}
