using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAI : MonoBehaviour
{
    State currentState;
    Character character;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        currentState = new Attack(character);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
