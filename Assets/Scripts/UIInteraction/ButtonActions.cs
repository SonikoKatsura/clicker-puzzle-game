using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public void Play() {
        AudioManager.instance.PlaySFX("Click");
        AudioManager.instance.PlayMusic("MainTheme");
        StopCoroutine("ReduceHPProcedural");
        GameManager.instance.SetClics(15);
        GameManager.instance.SetLife(100);
        GameManager.instance.SetIsPlaying(true);
        GameManager.instance.HPBar = null;
        SCManager.instance.LoadScene("Level1Scene");
    }

    public void Quit() {
        AudioManager.instance.PlaySFX("Click");
        Application.Quit();
    }

    public void BackToMenu()
    {
        AudioManager.instance.PlaySFX("Boton");
        StopCoroutine("ReduceHPProcedural");
        SCManager.instance.LoadScene("MenuScene");
        GameManager.instance.SetIsPlaying(false);

    }
}
