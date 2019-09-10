using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CubeGenerator : MonoBehaviour {

    [SerializeField] Cube cubePrefab;
    CubePool cubePool;
    int xPos = 0;
    float count = 0;
    int spawnCount = 0;

    void Start() {
        cubePool = new CubePool(cubePrefab);
        cubePool.PreloadAsync(10, 1).Subscribe();
    }

    void FixedUpdate() {
        count += Time.fixedDeltaTime;
        if (count > 0.1) {
            var newCube = cubePool.Rent();
            newCube.transform.position = new Vector3(xPos, 0, 0);
            newCube.transform.SetParent(transform);
            spawnCount++;
            Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ => cubePool.Return(newCube));
            count = 0;
            xPos += 2;
            if (spawnCount == 10) {
                xPos = 0;
                spawnCount = 0;
            }
        }

    }
}
