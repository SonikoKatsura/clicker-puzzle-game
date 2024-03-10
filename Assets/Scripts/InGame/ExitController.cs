using UnityEngine;

public class ExitController : MonoBehaviour {
    [SerializeField] string nextScene;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            AudioManager.instance.PlaySFX("NextLevel");
            if (nextScene == "VictoryScene") GameManager.instance.SetIsPlaying(false);
            SCManager.instance.LoadScene(nextScene);
        }
    }
}
