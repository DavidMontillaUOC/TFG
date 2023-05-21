using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHelper : MonoBehaviour
{

    public UnityEvent OnAttack;

    public UnityEvent OnSecondAttack;

    public UnityEvent animationTriggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAttack()
    {
        OnAttack?.Invoke();
    }

    public void TriggerOnAttack()
    {
        animationTriggered?.Invoke();
    }

    public void TriggerOnSecondAttack()
    {
        animationTriggered?.Invoke();
    }

}
