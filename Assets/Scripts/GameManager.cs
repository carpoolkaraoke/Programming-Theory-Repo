using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SphereController cometPrefab;
    [SerializeField] private SphereController bumperPrefab;


    public static GameManager main;

    private void Awake()
    {
        if (main != null)
        {
            Destroy(gameObject);

            return;
        }

        main = this;
        DontDestroyOnLoad(main);
    }

    private void Start()
    {
        /*var b1 = Instantiate(spherePrefab, 15 * Vector3.right, Quaternion.identity);
        b1.direction = Vector3.left;
        var b2 = Instantiate(spherePrefab, -15 * Vector3.right, Quaternion.identity);
        b2.direction = Vector3.right;*/




        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 9));
            Instantiate(cometPrefab, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 9));
            Instantiate(bumperPrefab, spawnPos, Quaternion.identity);
        }
    }
}
