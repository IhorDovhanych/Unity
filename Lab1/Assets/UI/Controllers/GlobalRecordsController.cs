using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalRecordsController : MonoBehaviour
{
    public static GlobalRecordsController Instance;

    public List<Record> records = new List<Record>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveRecord(string username, float time, int score)
    {
        records.Add(new Record { username = username, time = time, score = score });
    }

    public List<Record> GetSortedRecordsByTime()
    {
        return records.OrderBy(r => r.time).ToList();
    }
}
public class Record
{
    public string username;
    public float time;
    public int score;
}