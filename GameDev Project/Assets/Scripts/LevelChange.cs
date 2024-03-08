using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    
    public int sceneBuildIndex;

    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player") {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
