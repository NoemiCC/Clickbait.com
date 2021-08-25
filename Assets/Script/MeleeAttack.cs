using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator;

    private Attack attack;
    
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayer;

    public float maxStamina = 50;
    float currentStamina;
    public Image staminaBar;
    private float staminaTimer = 5f;

    public float StaminaTimer { get => staminaTimer; set => staminaTimer = value; }

    void Start()
    {
        attack = GetComponentInChildren<Attack>();
        currentStamina = maxStamina;
    }
    void Update()
    {
        if (currentStamina > 0 && Input.GetKeyDown(KeyCode.Space)) {
            currentStamina -= 10;
            staminaBar.fillAmount = currentStamina / maxStamina;
            Attack();
        }
        else
            animator.SetBool("Attack", false);
        
        if (currentStamina <= 0)
            StaminaTimer -= Time.deltaTime;
        if (StaminaTimer <= 0) {
            currentStamina = maxStamina;
            staminaBar.fillAmount = 1;
            StaminaTimer = 5f;
        }
    }

    void Attack() {
        // Animation
        animator.SetBool("Attack", true);

        // Detect enemies
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        foreach (var enemy in hitEnemies) {
            enemy.GetComponent<EnemyMove>().TakeDamage(attackDamage);
        }
        GameObject[] hitBoss = GameObject.FindGameObjectsWithTag("Boss");
        foreach (var boss in hitBoss) {
            boss.GetComponent<Boss>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Ataque()
    {
        attack.ReproducirSonido();
    }
}
