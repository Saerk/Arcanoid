using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour
{
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        input.characterLimit = 10;
        input.onEndEdit.AddListener(val =>
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) SaveName(input.text);
        });
    }

    void SaveName(string name)
    {
        PlayerPrefs.SetString("CurrentName", name); 
        SceneManager.LoadScene("Level1");
    }
}
