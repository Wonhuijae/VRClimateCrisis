using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string _sceneName)
    {
        StartCoroutine(LoadSceneProgress(_sceneName));   
    }

    IEnumerator LoadSceneProgress(string _sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(_sceneName);
        loading.allowSceneActivation = false;

        float timer = 3f;

        while(!loading.isDone)
        {
            yield return null;
            timer -= Time.deltaTime;

            if(loading.progress >= 0.9f && timer <= 0f)
            {
                loading.allowSceneActivation = true;
            }
        }
    }
}
