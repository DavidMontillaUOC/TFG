using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimiento : MonoBehaviour
{
    [SerializeField] private float movVel;
    [SerializeField] private Vector2 direction;
    [SerializeField] private InputActionReference attack;

    private Rigidbody2D rb2D;

    private float xMovement;

    private float yMovement;

    private WeaponScript weaponScript;

    private Animator animator;

    private Transform weapon;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        weaponScript = GetComponentInChildren<WeaponScript>();
        weapon = transform.Find("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        yMovement = Input.GetAxisRaw("Vertical");
        animator.SetFloat("XMovement", xMovement);
        animator.SetFloat("YMovement", yMovement);

        if(xMovement != 0 || yMovement !=0){
            animator.SetFloat("LastX", xMovement);
            animator.SetFloat("LastY", yMovement);

            //float angle = Mathf.Atan2(yMovement, xMovement) * Mathf.Rad2Deg;
            //weapon.transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);

        }

        direction = new Vector2(xMovement,yMovement ).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direction * movVel * Time.fixedDeltaTime);
        
        

    }

    private void OnEnable()
    {
        if (attack != null)
        {
            attack.action.performed += SwingWeapon;
        }
    }

    private void OnDisable()
    {
        if (attack != null)
        {
            attack.action.performed -= SwingWeapon;
        }
    }

    private void SwingWeapon(InputAction.CallbackContext obj)
    {
        weaponScript.Attack();
         float angle = Mathf.Atan2(animator.GetFloat("LastY"), animator.GetFloat("LastX")) * Mathf.Rad2Deg;
        weaponScript.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        StartCoroutine(ResetWeaponPosition());
}

private IEnumerator ResetWeaponPosition()
{
    yield return new WaitForSeconds(weaponScript.attackAnimationDuration);

    weaponScript.transform.localRotation = Quaternion.identity;
    weaponScript.transform.localPosition = Vector3.zero;
}

}
