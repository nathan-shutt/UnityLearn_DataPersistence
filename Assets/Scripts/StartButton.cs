using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartButton : MonoBehaviour
{
    Button button;
    public TMP_InputField inputField;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(StartGame);

    }

    public void StartGame()
    {
        DataManager.instance.playerName = inputField.text;
        DataManager.instance.LoadHighScoreData();

        SceneManager.LoadScene(1);
    }

}
