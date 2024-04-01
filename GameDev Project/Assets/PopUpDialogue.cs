using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDialogue : MonoBehaviour
{
    public TextMeshProUGUI popuptext;

    private string[] _response;
    private string finalResponse;

    // Start is called before the first frame update
    void Start()
    {
        popuptext.enabled = false;
        _response = new string[]
        {
            "May the Light protect us.",
            "The door to the Cemetery is on the east side",
            "You should deal with those skeletons",
        };
        
        // response[0] = "May the Light protect us.";
        // response[1] = "The door to the Cemetery is on the east side";
        // response[2] = "You should deal with those skeletons";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetRandomResponseString()
    {
        return _response[Random.Range(0, _response.Length)];
        
    }



    private void OnTriggerEnter2D (Collider2D other) {

        if (other.tag == "Player") 
        {
           popuptext.enabled = true;
           popuptext.text = GetRandomResponseString();
        }
        else
        {
            popuptext.enabled = false;
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        popuptext.enabled = false;
    }
}
