using System.Collections;
using UnityEngine;


public class TurretController : MonoBehaviour {
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float proyectileSpeed = 8f;
    [SerializeField] float reload = 1.5f;
    GameObject spawnPoint, player;
    Vector2 target;

    private void Start() {
        player = GameObject.Find("Player");
        spawnPoint = transform.GetChild(0).gameObject;
        transform.up = (player.transform.position - transform.position).normalized;
        StartCoroutine(Shoot());
    }

    private void Update() {
        transform.up = (player.transform.position - transform.position).normalized;
    }

    private IEnumerator Shoot() {
        while (true) {
            yield return new WaitForSeconds(reload);
            AudioManager.instance.PlaySFX("Shot");
            target = (player.transform.position - transform.position).normalized;
            GameObject missile = Instantiate(missilePrefab, spawnPoint.transform);
            missile.transform.SetParent(null);
            missile.GetComponent<Rigidbody2D>().velocity = target.normalized * proyectileSpeed;
        }
    }
}
