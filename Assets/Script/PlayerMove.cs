using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 6f;
    public float maxHealth = 100;
    float currentHealth;
    public GameObject[] hearts;
    public int killCount = 1000;
    public string nextScene = "Level2";

    private pies pies;

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        Debug.Log("Take Damage");

        if (hearts[0] && currentHealth <= 60)
            hearts[0].SetActive(false);
        if (hearts[1] && currentHealth <= 30)
            hearts[1].SetActive(false);

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        // Die animation
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void Start() {
        currentHealth = maxHealth;

        pies = transform.gameObject.GetComponentInChildren<pies>();
    }

    void Update()
    {
        if (killCount <= 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("InputX", horizontal);
        animator.SetFloat("InputY", vertical);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void pisar()
    {
        pies.ReproducirSonido();
    }

}
