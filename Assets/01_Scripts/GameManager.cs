using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowText(string text)
    {
        dialogBox.SetActive(true);
        dialogText.text = text;
    }

    public void HideText()
    {
        dialogBox.SetActive(false);
        dialogText.text = "";
    }

}
