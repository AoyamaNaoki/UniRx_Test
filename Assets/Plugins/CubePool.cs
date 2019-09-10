using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

public class CubePool : ObjectPool<Cube> {

    public Cube cubePrefab;

    public CubePool(Cube cubePrefab) {
        this.cubePrefab = cubePrefab;
    }

    protected override Cube CreateInstance() {
        return Object.Instantiate(cubePrefab);
    }

}
