using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public List<Transform> movePoints = new List<Transform>();
    public List<Transform> chillPoints = new List<Transform>();
    public List<Transform> dangerPoints = new List<Transform>();
    private int current = 0;
    public float radius = 1f;
    public float speed = 10f;
    public float maxHealth = 200;
    float currentHealth;


    List<Transform> GetChildren(Transform parent) {
        List<Transform> lista = new List<Transform>();
        foreach (Transform child in parent) {
            lista.Add(child);
        }
        return lista;
    }
    public void TakeDamage(int damage) {
        animator.SetBool("Hurt", true);
        Invoke("StopAnim", 0.5f);
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    private void StopAnim() {
        animator.SetBool("Hurt", false);
    }

    void Die() {
        // Die animation
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }

    void Start()
    {
        currentHealth = maxHealth;

        chillPoints = GetChildren(transform.parent.GetChild(1));
        dangerPoints = GetChildren(transform.parent.GetChild(2));

        movePoints = chillPoints;
    }

    void Update()
    {
        if (currentHealth < 100) {
            movePoints = dangerPoints;
        }

        if (Vector3.Distance(movePoints[current].position, transform.position) < radius) {
            current++;
            if (current >= movePoints.Count)
                current = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoints[current].position, speed * Time.deltaTime);
    }
}
