using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour
{
    private Image WhiteImage;
    private AudioSource WhiteNoise;
    private AudioSource Bang;

    private void Start()
    {
        WhiteImage = GameObject.FindGameObjectWithTag("WhiteImage").GetComponent<Image>();
        WhiteNoise = GameObject.FindGameObjectWithTag("WhiteNoise").GetComponent<AudioSource>();
        Bang = GameObject.FindGameObjectWithTag("Bang").GetComponent<AudioSource>();
    }

    public void Flash()
    {
        StartCoroutine(WhiteFade());
    }

    private IEnumerator WhiteFade()
    {
        yield return new WaitForSeconds(1f);
        WhiteImage.color = new Vector4(1, 1, 1, 1);        
        Bang.Play();
        WhiteNoise.Play();
        float FadeSpeed = 1f;
        float Modifier = 0.01f;
        float WaitTime = 0;

        for(int i = 0; WhiteImage.color.a > 0; i++)
        {
            WhiteImage.color = new Vector4(1, 1, 1, FadeSpeed);
            FadeSpeed = FadeSpeed - 0.025f;
            Modifier = Modifier * 1.5f;
            WaitTime = 0.5f - Modifier;
            if (WaitTime < 0.1f) WaitTime = 0.1f;
            WhiteNoise.volume -= 0.05f;
            yield return new WaitForSeconds(WaitTime);
        }

        WhiteNoise.Stop();
        WhiteNoise.volume = 1;
        SceneManager.LoadScene(1);
    }
}
