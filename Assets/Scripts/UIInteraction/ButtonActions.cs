using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public void Play() {
        SCManager.instance.LoadScene("GameScene");
    }

    public void Quit() {
        Application.Quit();
    }
}
