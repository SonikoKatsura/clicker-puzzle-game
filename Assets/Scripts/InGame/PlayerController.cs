using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    float speed = 10f;
    [SerializeField] int clicks;
    TMP_Text clicksText;
    [SerializeField] GameObject blood;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        clicksText = GameObject.Find("Counter").GetComponent<TMP_Text>();
        clicksText.text = $"clics: {GameManager.instance.GetClicks()}";
        clicks = GameManager.instance.GetClicks();
        GameObject.Find("Fill").GetComponent<Image>().fillAmount = GameManager.instance.lifeShown / GameManager.instance.maxLife;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.canMove)
        {
            GameManager.instance.SetClics(--clicks);
            if (clicksText != null) clicksText.text = $"clics: {GameManager.instance.GetClicks()}";
            Move();
        }
    }

    void Move() {
        Vector2 mousePosition, worldMousePosition, direction;
        mousePosition = Input.mousePosition;
        worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        direction = (worldMousePosition - (Vector2)transform.position).normalized;

        rbSprite.flipX = 
            (worldMousePosition.x > transform.position.x) ? false : true;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        rb.velocity = default(Vector2);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Exit") return;
        StartCoroutine(Die());
        //audio
    }

    void InstantBlood() {
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    public IEnumerator Die() {
        InstantBlood();
        GameManager.instance.canMove = false;
        GameManager.instance.SetIsPlaying(false);
        yield return new WaitForSeconds(1f);
        SCManager.instance.LoadScene("LoseScene");
    }
}
