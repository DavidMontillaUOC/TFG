using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerScript : MonoBehaviour
{

    int numWeapons;
    public int weaponIndex;

    public GameObject[] weapons;
    public GameObject weaponObject;
    public GameObject weaponInUse;
    
    public Vector2 cursorPosition { get; set; }

    [SerializeField]
    private WeaponScript weaponScript;

    // Start is called before the first frame update
    void Start()
    {
        numWeapons = weaponObject.transform.childCount;
        weapons = new GameObject[numWeapons];
        for (int i = 0; i < numWeapons; i++)
        {
            weapons[i] = weaponObject.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        weaponInUse = weapons[0];
        weaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponScript.IsAttacking) {
            return;
        }
        transform.right = (cursorPosition - (Vector2)transform.position).normalized;
    }
}
