using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    [SerializeField] Texture2D iconoCursor;

    bool isPlaying;

    public GameObject HPBar;
    float life = 100;
    public float maxLife = 100;
    public float lifeShown = 100;
    bool isReducingHP = false;
    int hpReduce = 0;
    [SerializeField] int clicks = 15;
    public bool canMove = false;


    void Start() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);
        hpReduce = Mathf.RoundToInt(maxLife / clicks);
        Cursor.SetCursor(iconoCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && isPlaying && canMove) {
            if (isReducingHP) StopCoroutine(ReduceHPProcedural());
            StartCoroutine(ReduceHPProcedural());
        }
        if ((life <= 0 || clicks == 0) && isPlaying)
            StartCoroutine(GameObject.Find("Player").GetComponent<PlayerController>().Die());
    }

    IEnumerator ReduceHPProcedural() {
        if (HPBar == null) HPBar = GameObject.Find("Fill");
        isReducingHP = true;
        life -= hpReduce;
        for (float i = hpReduce; i > 0; i--) {
            ReduceHP(1);
            yield return new WaitForFixedUpdate();
        }
        
        isReducingHP = false;
    }

    void ReduceHP(float amount) {
        lifeShown -= amount;
        HPBar.GetComponent<Image>().fillAmount = lifeShown / maxLife;
    }

    public void SetClics(int clics)
    {
        this.clicks = clics;
    }

    public int GetClicks()
    {
        return this.clicks;
    }

    public void SetIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
    }

    public bool IsPlaying()
    {
        return this.isPlaying;
    }

    public void SetLife(float amount)
    {
        life = amount;
        maxLife = amount;
        lifeShown = amount;
    }
}
