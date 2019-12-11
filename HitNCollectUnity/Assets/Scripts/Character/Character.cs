using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // TODO: Implement a method to create unique IDs for each Character
    int characterID;
    [HideInInspector]
    public int CharacterID { get { return characterID; } }
    [HideInInspector]
    public EnvironmentInfoManager environmentInfoManager;
    [HideInInspector]
    public FireManager fireManager;
    [HideInInspector]
    public MovementManager movementManager;
    [HideInInspector]
    public StatusManager statusManager;
    [SerializeField]
    GameObject stateIndicator;

    private void Awake()
    {
        characterID = Random.Range(int.MinValue, int.MaxValue);
        movementManager = GetComponent<MovementManager>();
        statusManager = GetComponent<StatusManager>();
        fireManager = GetComponent<FireManager>();
        environmentInfoManager = GetComponent<EnvironmentInfoManager>();

    }
    public void SetStateColor(Color color)
    {
        stateIndicator.GetComponent<MeshRenderer>().material.color = color;
    }

}
