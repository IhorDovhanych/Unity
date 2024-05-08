using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    
    private static GameManager _instance;
    
    public UIDocument uiDocument;
    private Label collisionLabel;
    private Label timeLabel;

    private int collisionCount = 0;
    private float startTime;
    public string login;
    public int maxScore = 0;
    public int maxTime = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        collisionLabel = root.Q<Label>("CollisionCount");
        timeLabel = root.Q<Label>("TimeElapsed");

        startTime = Time.time;
        
        maxScore = PlayerPrefs.GetInt($"{login}maxScore", 0);
        maxTime = PlayerPrefs.GetInt($"{login}maxTime", 0);
    }

    void Update()
    {
        UpdateTimer();
    }

    public void IncrementCollisionCount()
    {
        collisionCount++;
        collisionLabel.text = $"Collisions: {collisionCount}";
    }

    private void UpdateTimer()
    {
        float timeElapsed = Time.time - startTime;
        timeLabel.text = $"Time: {timeElapsed:F2}s";
    }

    public void Finish()
    {
        if (collisionCount < maxScore)
        {
            maxScore = collisionCount;
            PlayerPrefs.SetInt($"{login}maxScore", maxScore);
        }
        if (Time.time - startTime < maxTime)
        {
            maxTime = (int)(Time.time - startTime);
            PlayerPrefs.SetInt($"{login}maxTime", maxTime);
        }
        
    }
}
