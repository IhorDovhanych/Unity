using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    private Button _buttonRestart, _buttonStart, _buttonExit, _buttonRecord, _buttonLogin;
    private Label _recordTime, _recordObstacles;
    private TextField _usernameField;
    private bool _isPaused = false;
    private GlobalRecordsController _recordsController;
    private GameManager _gameManager;
    
    private string _username;

    private void Start()
    {
        _recordsController = FindObjectOfType<GlobalRecordsController>();
    }
    private void Awake()
    {
        _gameManager = GameManager.Instance;

        Time.timeScale = 0f;
        _document = GetComponent<UIDocument>();

        _buttonRestart = _document.rootVisualElement.Q<Button>("Restart");
        _buttonRestart.RegisterCallback<ClickEvent>(Restart);

        _buttonStart = _document.rootVisualElement.Q<Button>("Start");
        _buttonStart.RegisterCallback<ClickEvent>(ResumeGame);
        
        _buttonExit = _document.rootVisualElement.Q<Button>("Quit");
        _buttonExit.RegisterCallback<ClickEvent>(evt => Application.Quit());

        _buttonRecord = _document.rootVisualElement.Q<Button>("Record");
        _buttonRecord.RegisterCallback<ClickEvent>(ShowRecords);

        _usernameField = _document.rootVisualElement.Q<TextField>("Username");

        _buttonLogin = _document.rootVisualElement.Q<Button>("LoginButton");
        _buttonLogin.RegisterCallback<ClickEvent>(Login);

        _recordTime = _document.rootVisualElement.Q<Label>("RecordTime");
        _recordObstacles = _document.rootVisualElement.Q<Label>("RecordObstacles");
        
        #if DEBUG
        PlayerPrefs.DeleteAll();
        #endif
        
        _username = PlayerPrefs.GetString("Username", "");
        if (string.IsNullOrEmpty(_username))
        {
            _buttonStart.SetEnabled(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        _document.rootVisualElement.style.display = DisplayStyle.Flex;
    }
    
    private void ShowRecords(ClickEvent evt)
    {
        if(_username == "")
        {
            Debug.Log("You need to login to see records.");
            return;
        }
        if (_recordsController.records == null)
        {
            float maxTime = PlayerPrefs.GetFloat($"{_username}maxTime", _gameManager.maxTime);
            int maxScore = PlayerPrefs.GetInt($"{_username}maxScore", _gameManager.maxScore);

            _recordTime.text = $"Best Time: {maxTime}s";
            _recordObstacles.text = $"Least Obstacles: {maxScore}";

            _recordsController.SaveRecord(_username, maxTime, maxScore);
        }
        else
        {
            List<Record> res = _recordsController.GetSortedRecordsByTime();

            _recordTime.text = $"Best Time: {res[0].time}s";
            _recordObstacles.text = $"Least Obstacles: {res[0].score}";

            _recordsController.SaveRecord(_username, res[0].time, res[0].score);
        }
    }

    private void Login(ClickEvent evt)
    {
        _username = _usernameField.value;
        PlayerPrefs.SetString("Username", _username);
        GameManager.Instance.login = _username;
        _buttonStart.SetEnabled(true);
    }

    private void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        _document.rootVisualElement.style.display = DisplayStyle.None;
    }
    private void ResumeGame(ClickEvent evt)
    {
        _isPaused = false;
        Time.timeScale = 1f;
        _document.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void Restart(ClickEvent evt)
    {
        _recordsController.SaveRecord(_username, _gameManager.maxTime, _gameManager.maxScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
