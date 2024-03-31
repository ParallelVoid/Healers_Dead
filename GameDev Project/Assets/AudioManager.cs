using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource SFXSource;

    public AudioClip UIButton;
    public AudioClip playerAttack;
    public AudioClip playerWalking;
    public AudioClip playerHeal;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SFXSource.PlayOneShot(clip);
    }
}
