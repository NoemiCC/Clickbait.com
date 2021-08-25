using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform player;

    public float speed = 4f;
    public int damage = 10;
    public float attackRange = 0.6f;
    public float hitRate = 1f;
    private float hitCountdown = 0f;
    public float maxHealth = 30;
    float currentHealth;
    private Vector3 prevPosition;


    public void TakeDamage(int damage) {
        animator.SetBool("Hurt", true);
        currentHealth -= damage;

        // Play hurt animation

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        // Die animation
        player.GetComponent<PlayerMove>().killCount -= 1;
        Destroy(gameObject);
    }

    void HitTarget(RaycastHit hit) {
        if (hit.collider.gameObject.tag == "Player") {
            hit.collider.gameObject.GetComponent<PlayerMove>().TakeDamage(damage);
        }
    }

    void Start() {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        player = playerObject[0].transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        prevPosition = transform.position;
        Vector3 direction = player.position - transform.position;
        controller.Move(direction.normalized * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(prevPosition, direction.normalized, out hit, attackRange)) {
            if (hitCountdown <= 0f) {
                HitTarget(hit);
                hitCountdown = 1f / hitRate;
            }

            hitCountdown -= Time.deltaTime;
        }
        animator.SetBool("Hurt", false);
    }
}
