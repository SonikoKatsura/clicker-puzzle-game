using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null && collision.gameObject.name != "Water") StartCoroutine("Stuck");
    }
    IEnumerator Stuck() {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
