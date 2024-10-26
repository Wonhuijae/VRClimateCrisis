using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string nextSceneName;

    public TextMeshProUGUI introText;
    public string[] scripts;
    int idx = 0;

    public GameObject lodingIcon;
    public GameObject introPanel;

    public GameObject OutBtns;

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
            introPanel.SetActive(false);

            if (nextSceneName == "MainScene")
            {
                lodingIcon.SetActive(true);
                
                GetComponent<SceneLoader>().LoadScene(nextSceneName);
                return;
            }
            else
            {
                OutBtns.SetActive(true);
                return;
            }
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