using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour {
    
    public void changeMenuScreen()
    {
        SceneManager.LoadScene("GameScheme");

    }
}
