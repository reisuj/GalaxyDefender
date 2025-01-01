﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, 8.0f, 0);
        }
    }
}
