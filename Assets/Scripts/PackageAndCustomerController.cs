using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageAndCustomerController : MonoBehaviour
{

    [SerializeField] GameObject arrowUI;
    private GameObject car;
    private GameObject[] packages;
    private GameObject customer;
    private int packagesLength = 0;
    private Transform follow;
    private List<int> Numbers;
    private List<GameObject> paths;
    private bool hasFollow = false;


    void Start()
    {
        packages = GameObject.FindGameObjectsWithTag("Package");
        customer = GameObject.FindGameObjectWithTag("Customer");
        car = GameObject.FindGameObjectWithTag("Driver");
        paths = FindObjectOfType<Path>().GetPaths();
        packagesLength += packages.Length;
        RandomDifferentNumber(0, paths.Count, packagesLength);
        customer.SetActive(false);
        arrowUI.SetActive(false);
        PackageGenerator();
    }
    void Update()
    {
        if (hasFollow)
        {
            float angle = Mathf.Atan2(follow.position.y - car.transform.position.y, follow.position.x - car.transform.position.x) * Mathf.Rad2Deg;
            arrowUI.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
    private void RandomDifferentNumber(int startRange, int endRange, int numberAmount)
    {
        Numbers = new List<int>();
        int x;
        while(Numbers.Count < numberAmount)
        {
            do
            {
                x = Random.Range(startRange, endRange);
            } while ((Numbers.Contains(x)));
            Numbers.Add(x);
        }
    }
    private void PackageGenerator()
    {
        for (int i = 0; i < packagesLength; i++)
        {
            packages[i].transform.position = paths[Numbers[i]].transform.position;
            packages[i].GetComponent<Package>().packagePathId = Numbers[i];
        }
    }
    private void CustomerGenerator()
    {
        int number;
        do
        {
            number = Random.Range(0, paths.Count);
        } while (Numbers.Contains(number));
        customer.SetActive(true);
        customer.transform.position = paths[number].transform.position;
        customer.GetComponent<Customer>().customerPathId = number;
        follow = paths[number].transform;
    }
    public void PackagePickUp(int packagePathId)
    {
        CustomerGenerator();
        Numbers.Remove(packagePathId);
        RandomDifferentNumber(0, paths.Count, packagesLength);
        PackageGenerator();
        foreach (var package in packages)
        {
            package.SetActive(false);
        }
        customer.SetActive(true);
        arrowUI.SetActive(true);
        hasFollow=true;
    }
    public void DeliveredToCustomer()
    {
        customer.SetActive(false);
        foreach (var package in packages)
        {
            package.SetActive(true);
        }
        arrowUI.SetActive(false);
        hasFollow=false;
    }

}
