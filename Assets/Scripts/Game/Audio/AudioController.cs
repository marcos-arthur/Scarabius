using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    Bus Music;
    Bus Master;

    float MusicVolume = 1f;
    float MasterVoume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    public void MuteMaster(bool mute)
    {
        Master.setMute(mute);
    }
}
