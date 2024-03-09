using System;
using System.Collections;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    public float proyectileSpeed = 8f;
    public float reload = 3f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private  Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.up = (player.transform.position - transform.position).normalized;
        StartCoroutine(Disparo());
    }

    private void Update()
    {
        transform.up = (player.transform.position - transform.position).normalized;
    }
    private IEnumerator Disparo()
    {
        while (true)
        {
            target = (player.transform.position - transform.position).normalized;
            GameObject bullet = Instantiate(bala, spawnPoint.transform);
            bullet.transform.SetParent(null);
            bullet.GetComponent<Rigidbody2D>().velocity = target.normalized * proyectileSpeed;
            yield return new WaitForSeconds(reload);
        }
    }
}
