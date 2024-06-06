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
    private string TextBox = "扉を開くには扉を見続けてください\r\n\r\n一度開けた方はゴーグルを外して\r\n次の人に代わってください";

    [SerializeField] TextMeshProUGUI m_TextMeshPro;
    [SerializeField] Transform raySpawner;
    [SerializeField] private TimelineAsset timelines;
    [SerializeField] PlayableDirector playableDirector;

   private GameObject GameobjectOn;
  private GameObject GameobjectOff;

    //private void Start()
    //{
    //    DontDestroyOnLoad(GameObject.Find("Player"));
    //}


    void Update()
    {
        if (!_playingTimeline) {
            if (_gazeState)
            {
                _gazedTime += Time.deltaTime;
                if (_gazedTime > 1)
                {
                    var jiji = 8 - _gazedTime;
                    TextBox = ((int)jiji).ToString();
                    if (_gazedTime > 8)
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
                TextBox = "扉を開くには扉を見続けてください\r\n\r\n一度開けた方はゴーグルを外して\r\n次の人に代わってください";
            }

            m_TextMeshPro.text = TextBox;
        }
    }
    void OnEnable()
    {
        _gazeState = false;
        playableDirector.stopped += OnPlayableDirectorStopped;
    }


    void OnPlayableDirectorStopped( PlayableDirector aDirector)
    {

        
        SceneManager.LoadScene("Statue");
        
       
    }

   

}
