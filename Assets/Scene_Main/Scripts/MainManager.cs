using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using TMPro;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    //number
    static public bool _gazeState = false; //Gazing or not. 
    private bool _playingTimeline = false;
    private float _gazedTime = 0f;
    private string TextBox = "�S�[�O�����O����\r\n���̐l�ɑ����Ă�������";

    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] Transform raySpawner;
    [SerializeField] private TimelineAsset timelines;
    [SerializeField] PlayableDirector playableDirector;

    void Update()
    {
        if (!_playingTimeline) {
            if (_gazeState)
            {
                _gazedTime += Time.deltaTime;
                if (_gazedTime > 3)
                {
                    var jiji = 6 - _gazedTime;
                    TextBox = ((int)jiji).ToString();
                    if (_gazedTime > 6)
                    {
                        Debug.Log("Nya");
                        playableDirector.Play(timelines);
                        _playingTimeline = true;
                    }
                }
            }
            else
            {
                _gazedTime = 0f;
                TextBox = "�S�[�O�����O����\r\n���̐l�ɑ����Ă�������";
            }

            m_TextMeshPro.text = TextBox;
        }
    }
    void OnEnable()
    {
        _gazeState = false;
        playableDirector.stopped += OnPlayableDirectorStopped;
    }


    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        
            SceneManager.LoadScene("Statue");
       
    }



}
