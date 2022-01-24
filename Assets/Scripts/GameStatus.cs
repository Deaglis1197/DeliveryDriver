using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] GameObject Package;
    [SerializeField] GameObject Customer;
    [SerializeField] int maxPackageSize;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject Car;
    private Transform follow;
    private List<int> Numbers;
    private List<GameObject> paths;


    void Start()
    {
        RandomDifferentNumber(9, 0, 3);
        foreach (var number in Numbers)
        {
            Debug.Log(number);
        }
        paths = FindObjectOfType<Path>().GetPaths();
        packageGenerator();
    }
    void Update()
    {
        float angle = Mathf.Atan2(follow.position.y - Car.transform.position.y, follow.position.x - Car.transform.position.x) * Mathf.Rad2Deg;
        Arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    private void RandomDifferentNumber(int startRange, int endRange, int numberAmount)
    {
        Numbers = new List<int>();
        int x;
        for (int i = 0; i < numberAmount; i++)
        {
            do
            {
                x = Random.Range(startRange, endRange);
            } while ((Numbers.Contains(x)));
            Numbers.Add(x);
        }
    }
    public void packageGenerator()
    {
        RandomDifferentNumber(0, paths.Count, 2);
        Instantiate(Package, paths[Numbers[0]].transform.position, Quaternion.identity);
        follow = paths[Numbers[0]].transform;
    }
    public void packagePickUp()
    {
        customerGenerator();
    }
    public void customerDelivery()
    {
        Numbers.Clear();
        packageGenerator();
    }
    public void customerGenerator()
    {
        Instantiate(Customer, paths[Numbers[1]].transform.position, Quaternion.identity);
        follow = paths[Numbers[1]].transform;
    }
}
