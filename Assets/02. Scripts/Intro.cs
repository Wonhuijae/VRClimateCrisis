using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public string[] scripts;
    int idx = 0;

    public GameObject lodingIcon;
    public GameObject introPanel;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayText();
    }

    public void PlayText()
    {
        if (idx >= scripts.Length)
        {
            lodingIcon.SetActive(true);
            introPanel.SetActive(false);
            GetComponent<SceneLoader>().LoadScene("MainScene");
            return;
        }
        
        introText.text = "";
        DOTween.Kill(introText);
        introText.DOText(scripts[idx++], 3f);
        audioSource.Play();
        Invoke("StopAudio", 3f);
    }

    void StopAudio()
    {
        audioSource.Stop();
    }
}