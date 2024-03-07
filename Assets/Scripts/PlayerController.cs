using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    float speed = 10f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) Move();
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

    private void OnCollisionEnter2D(Collision2D collision) {
        rb.velocity = default(Vector2);
    }
}
