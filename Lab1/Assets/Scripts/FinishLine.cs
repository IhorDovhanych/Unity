using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FinishLine : MonoBehaviour
{
    public UIDocument uiDocument;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var root = uiDocument.rootVisualElement;
            var finishMessage = root.Q<Label>("FinishMessage");
            finishMessage.text = "Player crossed the finish line!";
            finishMessage.style.visibility = Visibility.Visible;

            Debug.Log("Player crossed the finish line!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
