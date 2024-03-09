using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] Texture2D iconoCursor;

    bool isPlaying = false;

    [SerializeField] int clicks = 15;
    TMP_Text clicksText;

    GameObject HPBar;
    float life, maxLife = 100;
    bool isReducingHP = false;

    void Start() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);

        AudioManager.instance.PlayMusic("MainTheme");
        AudioManager.instance.PlaySFX("StartLevelJingle");
        Cursor.SetCursor(iconoCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && isPlaying) {
            if (clicksText != null) clicksText.text = $"{--clicks}";
            if (isReducingHP) StopCoroutine(ReduceHPProcedural());
            StartCoroutine(ReduceHPProcedural());
        }
    }

    IEnumerator ReduceHPProcedural() {
        if (HPBar == null) yield break;
        isReducingHP = true;
        life -= 20;
        for (float i = life + 20; i > life; i--) {
            ReduceHP(i);
            yield return new WaitForEndOfFrame();
        }
        if (life == 0) SCManager.instance.LoadScene("LoseScene");
        isReducingHP = false;
    }

    void ReduceHP(float amount) {
        HPBar.GetComponent<Image>().fillAmount = amount / maxLife;
    }
}
