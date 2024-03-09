using UnityEngine;

public class ExitController : MonoBehaviour {
    [SerializeField] string nextScene;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") SCManager.instance.LoadScene(nextScene);
    }
}
