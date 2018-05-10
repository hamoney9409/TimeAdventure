using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using Lean.Pool;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject foePrefeb;
    public GameObject bulletPrefeb;
    public GameObject killEffectPrefeb;
    public static GameManager instance;

    double mGameTime;
    float timeScalebeforePause = 1.0f;
    bool mPressCancelInput = true;
    int mCurScreenHeight;
    int mCurScreenWidth;

    public string stageFileName;
    
    UnityEvent<bool> m_pauseEvent;
    UnityEvent<int, int> m_updateResolutionEvent;
    
    public class NewUnityEvent<T> : UnityEvent<T>
    {
    }

    public class NewUnityEvent<T0, T1> : UnityEvent<T0, T1>
    {
    }

    void Awake()
    {
        if (GameManager.instance != null)
        {
            return;
        }

        GameManager.instance = this;

        if (m_pauseEvent == null)
            m_pauseEvent = new NewUnityEvent<bool>();

        if (m_updateResolutionEvent == null)
            m_updateResolutionEvent = new NewUnityEvent<int, int>();

        DatatableManager.InitDatatableManager();
        SoundManager.InitSoundManager(GetComponent<AudioSource>());
    }

    // Use this for initialization
    void Start ()
    {
        mCurScreenHeight = Screen.height;
        mCurScreenWidth = Screen.width;
        // 이건 플레이씬에서 플레이매니저가 따로 해주도록 할거임;
        // StartCoroutine(InputCoroutine());
        
        // Spawn Foe
        //var position = (Vector3)UnityEngine.Random.insideUnitCircle * 6.0f;
        //var clone = LeanPool.Spawn(foePrefeb, position, Quaternion.identity, null);

    }

    // Update is called once per frame
    void Update ()
    {
        mGameTime += Time.deltaTime;
        // width와 height이 동시에 바뀔 경우, height 쪽이 우선도를 갖게 하였다.
        // height가 더 큰 게임이라 편해보이기 위함
        if (mCurScreenHeight != Screen.height) 
        {
            // 8에 나눠떨어지는 값으로 수정
            int height = Screen.height - (Screen.height % 8);
            int width = height / 8 * 5;

            ChangeResolution(width, height);

        }
        else if (mCurScreenWidth != Screen.width)
        {

            // 5에 나눠떨어지는 값으로 수정
            int width = Screen.width - (Screen.width % 5);
            int height = width / 5 * 8;


            
            ChangeResolution(width, height);
        }
    }

    void ChangeResolution(int width, int height)
    {
        int maxSize = Math.Min(Screen.currentResolution.width / 5, Screen.currentResolution.height / 8);
        width = Math.Min(width, maxSize * 5);
        height = Math.Min(height, maxSize * 8);

        Screen.SetResolution(width, height, false);

        mCurScreenWidth = width;
        mCurScreenHeight = height;

        m_updateResolutionEvent.Invoke(width, height);
    }

    IEnumerator InputCoroutine()
    {
        while (true)
        {
            if (0.1 < Input.GetAxisRaw("Cancel"))
            {
                if (!mPressCancelInput)
                {
                    mPressCancelInput = true;
                    Pause(!BasicProperties.IsPaused);
                }
            }
            else
            {
                if (mPressCancelInput)
                    mPressCancelInput = false;
            }

            yield return null;
        }
    }
    public void AddUpdatePauseListener(UnityAction<bool> func)
    {
        m_pauseEvent.AddListener(func);
    }

    public void AddUpdateResolutionListener(UnityAction<int, int> func)
    {
        m_updateResolutionEvent.AddListener(func);
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            if (!BasicProperties.IsPaused)
            {
                timeScalebeforePause = Time.timeScale;
                m_pauseEvent.Invoke(true);
                Time.timeScale = 0;
            }
        }
        else
        {
            if (BasicProperties.IsPaused)
            {
                Time.timeScale = timeScalebeforePause;
                m_pauseEvent.Invoke(false);
            }
        }
    }

    public double gameTime
    {
        get
        {
            return mGameTime;
        }
    }
}
