using UnityEngine;


public class GameManager : MonoBehaviour {

    [SerializeField] Texture2D iconoCursor;

    void Start() {
        AudioManager.instance.PlayMusic("MainTheme");
        AudioManager.instance.PlaySFX("StartLevelJingle");
        Cursor.SetCursor(iconoCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update() { 
    }
}
