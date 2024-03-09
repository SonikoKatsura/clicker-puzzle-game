using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    float speed = 10f;
    [SerializeField] int clicks = 15;
    TMP_Text clicksText;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        clicksText = GameObject.Find("ClicksText").GetComponent<TMP_Text>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && clicks != 0)
        {
            if (clicksText != null) clicksText.text = $"{--clicks}";
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Exit") return;
        //particles
        //audio
        SCManager.instance.LoadScene("LoseScene");
    }
}
