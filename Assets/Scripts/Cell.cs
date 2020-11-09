﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    private Vector3 _rot;
    private const float CHANCE_OF_DIVIDING = 3f;
    private const float COLOR_OFFSET = 0.005f;
    private const float OFFSET = 0.05f;
    private const float RANDOM_RANGE = 0.05f;
    private bool _canReplicate = true;

    private float _timer = 0f;

    public float hue = 0.5f;
    private float _sat = 1f;
    private float _val = 1f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        // transform.localEulerAngles= _rot;
        // GetComponentInChildren<MeshRenderer>().material.color = Color.HSVToRGB(hue, _sat, _val);
    }

    private void Replicate()
    {
        float xRan = Random.Range(-RANDOM_RANGE, RANDOM_RANGE);
        float zRan = Random.Range(-RANDOM_RANGE, RANDOM_RANGE);
        
        Vector3 offsetVec = new Vector3(xRan, OFFSET, zRan);

        GameObject replicant = Instantiate(this.gameObject, transform.position, transform.rotation);
        if (hue >= 1f) hue = 0f;
        replicant.GetComponent<Cell>().hue = hue += COLOR_OFFSET;
        replicant.transform.Rotate(Random.Range(0f, 1f) > 0.5f ? Vector3.forward : Vector3.right, Random.Range(-10f, 10f));
        replicant.transform.Translate(offsetVec, Space.Self);
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timer >= 0.1f)
        {
            if (!_canReplicate) return;
            float chance = Random.Range(0f, 100f);
            if (chance <= CHANCE_OF_DIVIDING)
            {
                Replicate();
            }
            Replicate();
            _canReplicate = false;
            _timer = 0f;
        }
        
        _timer += Time.deltaTime;
    }
}
