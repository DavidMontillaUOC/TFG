using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{

    public Animator animator;
    public float cooldown = 0.5f;
    private bool attackOnCd = false;
    public float attackAnimationDuration = 0.5f;
    public float staminaCost = 10f;
    public float staminaRegenRate = 2f;
    public float currentStamina = 2f;
     public Slider staminaBar;

    public Transform circleOrigin;
    public float radius;

    public bool IsAttacking {get; set;}

    public void ResetIsAttacking(){
        IsAttacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = staminaBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentStamina = Mathf.Clamp(currentStamina + staminaRegenRate * Time.deltaTime, 0f, staminaBar.maxValue);
        staminaBar.value = currentStamina;
    }

    public void Attack()
    {
        if(currentStamina < staminaCost) return;
        if(attackOnCd) return;

        IsAttacking = true;
        animator.SetTrigger("Attack");
        attackOnCd = true;
        currentStamina -= staminaCost;
        staminaBar.value = currentStamina;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attackOnCd = false;
    }


    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;

        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectCollider()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            //Debug.Log(collider.name);
            EnemyHealth health;
            if(health = collider.GetComponent<EnemyHealth>())
            {
                health.GetHit(5, transform.parent.gameObject);
            }
        }
    }

}
