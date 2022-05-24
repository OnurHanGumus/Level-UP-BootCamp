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

    public int currentScene = 0;//eklenen son sahnedir.

    LevelManager levelManager;
    int[] bolumunBelirlenmisSeviyeIdleri;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();


    }
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        bolumunBelirlenmisSeviyeIdleri = levelManager.MevcutBolumuDondur();

    }


    private void Update()
    {
        if (player.position.z >= 22.85f * currentScene - 11)
        {
            LoadLevel();
            Debug.Log("yeni b�l�m y�klendi.");
            currentScene++;
        } 
    }

    void LoadLevel()
    {
        if (currentScene > 2)
        {
            return;
        }
        scenesLoaded.Add(Instantiate(scenesCanBeLoad[bolumunBelirlenmisSeviyeIdleri[currentScene]], new Vector3(0, -0.01f * currentScene, 22.85f * currentScene), Quaternion.identity));
    }

    public void OyunBittiSonrakiBolumuYukle()
    {
        foreach (var i in scenesLoaded)
        {
            Destroy(i);
        }
        scenesLoaded.Clear();

        player.position = new Vector3(player.position.x, player.position.y, 0);
        currentScene = 0;
    }





}
