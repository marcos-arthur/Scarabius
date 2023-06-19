using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtons : MonoBehaviour
{
    private bool IsAudioMuted = false;
    [SerializeField] private Sprite ButtonOn;
    [SerializeField] private Sprite ButtonOff;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleMute);
    }

    public void ToggleMute()
    {
        IsAudioMuted = !IsAudioMuted;
        AudioController.Instance.MuteMaster(IsAudioMuted);

        gameObject.GetComponent<Image>().sprite = IsAudioMuted ? ButtonOff : ButtonOn;
    }
}
