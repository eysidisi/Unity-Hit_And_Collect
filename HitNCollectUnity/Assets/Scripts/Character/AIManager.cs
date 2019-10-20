using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    // TODO: Implement a method to get unique IDs for each AI

    int aIId;
    public int AIId { get { return aIId; } }
    EnvironmentInfoManager environmentInfoManager;
    FireManager fireManager;
    MovementManager movementManager;
    StatusManager statusManager;
    private void Awake()
    {
        aIId = Random.Range(int.MinValue, int.MaxValue);
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
            fireManager.Fire(Vector3.one, ProjectileType.Snowball);
        }
    }

}
