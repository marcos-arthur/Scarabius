using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class PossesedCultist : MonoBehaviour
{
    [SerializeField] private GameObject demonOcultistPrefab;

    EnemyController ec;


    void Start()
    {
        ec = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ec.health <= 2)
        {
            Instantiate(demonOcultistPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
