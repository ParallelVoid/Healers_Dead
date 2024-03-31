using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelChange : MonoBehaviour
{
    
    public int sceneBuildIndex;
    private bool canChangeScene;

    public TextMeshProUGUI exitscenetext;

    // Start is called before the first frame update
    void Start()
    {
        exitscenetext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && this != null)
        {
            if (canChangeScene)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        }
    }
    
    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player") {
            canChangeScene = true;
            exitscenetext.text = "Press Q to Exit Scene";
            exitscenetext.enabled = true;
            
        }
        else
        {
            canChangeScene = false;
            exitscenetext.enabled = false;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        canChangeScene = false;
        exitscenetext.enabled = false;
    }
}
