using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class StatueManager : MonoBehaviour
{
    //Static validation 
    static public int _proceedIndex = 0;

    //Manual Set Up
    [SerializeField] private TimelineAsset[] timelines;
    [SerializeField] private float[] waitingTime;
    [SerializeField] private Vector3[] collecterPosition;
    [SerializeField] private float[] collecterRadius;
    [SerializeField] private GameObject[] sceneGameobject;


    //Initialize
    [SerializeField] PlayableDirector playableDirector; //PlayableDirecter We use.
    [SerializeField] GameObject GazeCollecter;

    //number
    static public bool _gazeState = false; //Gazing or not. 
    private bool _playingTimeline = false; //Playing timeline or not.
    private float _gazeLimit = 0f; //Waitingtime[] to gazeLimit.
    private float _gazedTime = 0f;
    private float _time = 0f;

  
    void Update()
    {
        if (!_playingTimeline)
        {
            _time += Time.deltaTime;
            if (_time > 40)
            {
                _gazedTime = 100;
            }
            if (_gazeState)
            {
                _gazedTime += Time.deltaTime;
            }
            if(_gazedTime >= _gazeLimit)
            {
                _playingTimeline = true;
                _time = 0;
                _gazedTime = 0f;
                PlaceSceneAsset(_proceedIndex);
                _gazeState = false;
                playableDirector.Play(timelines[_proceedIndex]);
            }
        }

    }

        void OnEnable()
    {
        _gazeState = false;
        playableDirector.stopped += OnPlayableDirectorStopped;
        PlaceGazeCollecter(_proceedIndex);
    }

    
    void OnDisable()
    {
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }


   
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        _playingTimeline = false;
        if(_proceedIndex == 5)
        {
            SceneManager.LoadScene("MainScene");
        }
        _proceedIndex += 1;
        
        PlaceGazeCollecter(_proceedIndex);
    }


    void PlaceGazeCollecter(int _proceedingIndex)
    {
        _gazeLimit = waitingTime[_proceedIndex];

        if (_proceedingIndex == 0)
        {
            GazeCollecter.SetActive(false);
        }
        else {
            GazeCollecter.SetActive(true);
            GazeCollecter.GetComponent<Transform>().position = collecterPosition[_proceedingIndex];
            GazeCollecter.GetComponent<SphereCollider>().radius = collecterRadius[_proceedingIndex];
        } 
    }

    void PlaceSceneAsset(int _proceedingIndex)
    {
        switch (_proceedingIndex)
        {
            case 0:
                sceneGameobject[0].SetActive(true);
                break;

            case 2:
                sceneGameobject[0].SetActive(false);
                sceneGameobject[1].SetActive(true);
                break;

            case 3:
                sceneGameobject[1].SetActive(false);
                sceneGameobject[2].SetActive(true);
                break;
        }


    }
}