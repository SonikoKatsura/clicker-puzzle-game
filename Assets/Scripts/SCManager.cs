using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour {
    public static SCManager instance;
    void Start() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
    }

    void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
