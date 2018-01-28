using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Image))]
public class SplashScreen : MonoBehaviour {

    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }

    float timer = 3.0f;
    bool fading;

	void Update () {
        if(timer < 1.0f && ! fading)
        {
            fading = true;
            img.CrossFadeAlpha(0, 1.0f, true);
        }

		if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                SceneManager.LoadScene("GameScheme");
            }
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameScheme");
        }
	}
}
