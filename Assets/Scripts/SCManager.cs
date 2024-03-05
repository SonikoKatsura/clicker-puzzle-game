using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour {

    void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
