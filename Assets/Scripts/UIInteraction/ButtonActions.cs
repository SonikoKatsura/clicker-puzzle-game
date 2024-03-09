using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public void Play() {
        SCManager.instance.LoadScene("Level1Scene");
    }

    public void Quit() {
        Application.Quit();
    }
}
