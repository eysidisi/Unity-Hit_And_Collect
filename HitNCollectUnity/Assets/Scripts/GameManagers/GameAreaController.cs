using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaController : MonoBehaviour
{

    [SerializeField]
    private GameObject ammoPackagePrefab;
    [SerializeField]
    private GameObject healthPackagePrefab;

    [SerializeField]
    private int numOfAmmoPacks;

    [SerializeField]
    private int numOfHealthPacks;

    public const int planeBorderPoint = 10;
    private List<GameObject> ammoPackages;
    private List<GameObject> healthPackages;



    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ammoPackages = new List<GameObject>();
        healthPackages = new List<GameObject>();

        for (int i = 0; i < numOfAmmoPacks; i++)
        {
            GameObject newAmmoPackage = Instantiate(ammoPackagePrefab, transform);

            LocatePackage(newAmmoPackage);

            ammoPackages.Add(newAmmoPackage);
        }

        for (int i = 0; i < numOfHealthPacks; i++)
        {
            GameObject newHealthPackage = Instantiate(healthPackagePrefab, transform);

            LocatePackage(newHealthPackage);

            healthPackages.Add(newHealthPackage);
        }
    }

    static public void PackageIsPicked(Package package)
    {
        LocatePackage(package.gameObject);
    }

    private static void LocatePackage(GameObject package)
    {
        float xCoord = Random.Range(-planeBorderPoint, planeBorderPoint);
        float zCoord = Random.Range(-planeBorderPoint, planeBorderPoint);
        float yCoord = 0f;

        Vector3 pos = new Vector3(xCoord, yCoord, zCoord);

        package.transform.position = pos;

    }
}
