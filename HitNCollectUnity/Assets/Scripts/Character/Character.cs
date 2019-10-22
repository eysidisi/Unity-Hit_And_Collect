using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // TODO: Implement a method to get unique IDs for each Character

    int characterID;
    public int CharacterID { get { return characterID; } }
    EnvironmentInfoManager environmentInfoManager;
    FireManager fireManager;
    MovementManager movementManager;
    StatusManager statusManager;
    private void Awake()
    {
        characterID = Random.Range(int.MinValue, int.MaxValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        movementManager = GetComponent<MovementManager>();
        statusManager = GetComponent<StatusManager>();
        fireManager = GetComponent<FireManager>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            movementManager.SetTargetPos(Vector3.zero);
        }
    }

}
