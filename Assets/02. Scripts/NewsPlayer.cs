using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPlayer : MonoBehaviour
{
    GameManager gmInstance;
    AudioSource audioSource;

    List<AudioClip>[] newsAudioGroup;

    private void Awake()
    {
        gmInstance = GameManager.instance;
        if(gmInstance != null) gmInstance.OnTurnEnd += playNews;

        audioSource = GetComponent<AudioSource>();

        newsAudioGroup = new List<AudioClip>[6];

        for (int i = 0; i < newsAudioGroup.Length; i++)
        {
            AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio" + i);
            newsAudioGroup[i] = new();

            foreach (var c in clips)
            {
                newsAudioGroup[i].Add(c);
            }
        }
    }

    public void playNews(int _result)
    {
        audioSource.Stop();
        if (newsAudioGroup[_result].Count <= 0) return;

        int idx = Random.Range(0, newsAudioGroup[_result].Count);
        audioSource.PlayOneShot(newsAudioGroup[_result][idx]);
        newsAudioGroup[_result].RemoveAt(idx);
    }
}
