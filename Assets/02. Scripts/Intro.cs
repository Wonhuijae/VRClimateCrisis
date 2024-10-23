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
    public int idx = 0;

    private void Start()
    {
        PlayText();   
    }

    public void PlayText()
    {
        if (idx >= scripts.Length)
        {
            SceneManager.LoadScene("MainScene");
            return;
        }
        introText.text = "";
        introText.DOText(scripts[idx++], 3f);
    }
}
