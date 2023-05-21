using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int currentHealth, maxHealth;
    public Text DamageNumber;
    public Text DamageNumberPrefab;
    public Transform DamageNumberSpawnPoint;
    [SerializeField]
    public CharacterStats characterStats;

    public UnityEvent<GameObject> OnHitWithReference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InitializeHealth(int initialHealthValue)
    {
        currentHealth = initialHealthValue;
        maxHealth = initialHealthValue;

    }

    public void GetHit(int amount, GameObject sender)
    {
        if(sender.layer == gameObject.layer) return;

        else
        {
            amount = amount + characterStats.strength.getValue();
            //Text DamageNumber = Instantiate(DamageNumberPrefab, DamageNumberSpawnPoint.position, Quaternion.identity);
            //amageNumber.text = amount.ToString();
            Debug.Log(amount);
            OnHitWithReference?.Invoke(sender);
            StartCoroutine(FlashColorOnHit());
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                DestroyEntity();
            }
        }
    }

    IEnumerator FlashColorOnHit()
    {
        var renderer = GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        renderer.material.color = originalColor;
    }

    private void DestroyEntity()
    {
        Destroy(gameObject);
    }

}
