using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public void OnMusic(){
        Debug.Log("Desmutado");
        music.Play();
    }

    public void OffMusic(){
        Debug.Log("Mutado");
        music.Stop();
    }
}
