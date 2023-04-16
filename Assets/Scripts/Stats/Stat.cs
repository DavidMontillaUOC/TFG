using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    [SerializeField]
    private int currentValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = baseValue;
    }
    public int getValue(){
        return currentValue;
    }

    public void augmentValue(){
        currentValue = currentValue++;
    }

    public void decreseValue(){
        currentValue = currentValue--;
    }





}
