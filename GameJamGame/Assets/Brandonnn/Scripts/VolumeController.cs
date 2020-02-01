using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = GameManager.gameManager.volume;
    }

    public void ChangeVolume()
    {
        GameManager.gameManager.volumeChange(slider.value);
    }
}
