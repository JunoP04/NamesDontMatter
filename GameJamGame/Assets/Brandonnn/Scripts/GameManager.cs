using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public float volume = .7f;
    [SerializeField] private AudioSource audioSrc;
    // Start is called before the first frame update
    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        audioSrc =  gameObject.GetComponent<AudioSource>();
    }
    public void volumeChange(float sliderValue)
    {
        audioSrc.volume = sliderValue;
        volume = sliderValue;
    }

}
