using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int playerLevel = 1;

    public int experience;

    public int statPoints = 5;

    public Stat vitality;
    public Stat stamina;
    public Stat strength;
    public Stat agility;
    public Stat inteligence;

    public TMP_Text vitalityText;
    public TMP_Text staminaText;
    public TMP_Text strenghtText;
    public TMP_Text agilityText;
    public TMP_Text inteligenceText;
    public TMP_Text playerLevelText;
    public TMP_Text statPointsText;
    public TMP_Text playerHealthText;
    public TMP_Text playerStaminaText;

    public Slider healthBar;
    public Slider energyBar;
    public RectTransform healthBarTransform;
    public RectTransform energyBarTransform;

    private int maxHealth;
    private int maxEnergy;

    void Start()
    {
        UpdateMaxHealthAndEnergy();
        healthBar.value = maxHealth;
        energyBar.value = maxEnergy;
        UpdateStatMenu();
    }

    private int CalculateMaxHealth()
    {
        return vitality.getValue() * 10;
    }

    private void UpdateMaxHealthAndEnergy()
    {
        maxHealth = CalculateMaxHealth();
        maxEnergy = CalculateMaxEnergy();
        healthBar.maxValue = maxHealth;
        energyBar.maxValue = maxEnergy;
        healthBar.value = maxHealth;
        energyBar.value = maxEnergy;

        Vector2 healthBarSize = healthBarTransform.sizeDelta;
        healthBarSize.x = Mathf.Max(maxHealth, 0);
        healthBarTransform.sizeDelta = healthBarSize;

        Vector2 energyBarSize = energyBarTransform.sizeDelta;
        energyBarSize.x = Mathf.Max(maxEnergy, 0);
        energyBarTransform.sizeDelta = energyBarSize;
    }

    private int CalculateMaxEnergy()
    {
        return stamina.getValue() * 5;
    }

    public void LvlPlayerLvl()
    {
        playerLevel++;
        statPoints = statPoints + 5;
        //vitality.augmentValue();
        //stamina.augmentValue();
        //strength.augmentValue();
        //agility.augmentValue();
        //inteligence.augmentValue();
        UpdateStatMenu();
        UpdateMaxHealthAndEnergy();
    }

    public void LvlVitality()
    {

        if (statPoints > 0)
        {
            vitality.augmentValue();
            statPoints--;
        }
        UpdateMaxHealthAndEnergy();
        UpdateStatMenu();
    }

    public void LvlStamina()
    {

        if (statPoints > 0)
        {
            stamina.augmentValue();
            statPoints--;
        }
        UpdateMaxHealthAndEnergy();
        UpdateStatMenu();
    }

    public void LvlStrength()
    {
        if (statPoints > 0)
        {
            strength.augmentValue();
            statPoints--;
        }
        UpdateStatMenu();
    }
    public void LvlAgility()
    {

        if (statPoints > 0)
        {
            agility.augmentValue();
            statPoints--;
        }
        UpdateStatMenu();
    }
    public void LvlInteligence()
    {

        if (statPoints > 0)
        {
            inteligence.augmentValue();
            statPoints--;
        }
        UpdateStatMenu();
    }

    public void UpdateStatMenu() {
        vitalityText.text = vitality.getValue().ToString();
        staminaText.text = stamina.getValue().ToString();
        strenghtText.text = strength.getValue().ToString();
        agilityText.text = agility.getValue().ToString();
        inteligenceText.text = inteligence.getValue().ToString();
        statPointsText.text = statPoints.ToString();
        playerLevelText.text = playerLevel.ToString();
        playerHealthText.text = maxHealth.ToString();
        playerStaminaText.text = maxEnergy.ToString();
    }


    public void TakeDamage(int dmg) {
        healthBar.value = healthBar.value - dmg;
        Debug.Log("Player took "+ dmg+" dmg");
    }



}
