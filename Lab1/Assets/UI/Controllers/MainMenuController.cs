using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    private Button _buttonRestart;
    private Button _buttonStart;
    private bool _isPaused = false;

    private void Awake()
    {
        Time.timeScale = 0f;
        _document = GetComponent<UIDocument>();

        _buttonRestart = _document.rootVisualElement.Q("Restart") as Button;
        _buttonRestart.RegisterCallback<ClickEvent>(Restart);


        _buttonStart = _document.rootVisualElement.Q("Start") as Button;
        _buttonStart.RegisterCallback<ClickEvent>(ResumeGame);

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
