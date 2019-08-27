﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniblocks;
public class MapManager : MonoBehaviour {

    private Transform playerTrans;
    private Vector3 lastPosition;
    private Index lastIndex;

    private void Start()
    {
        playerTrans = GameObject.Find("Player").transform;

        InvokeRepeating("InitMap", 1, 0.5f);
    }

    // Update is called once per frame
    void Update ()
    {

    }

    private void InitMap()
    {
        if (Engine.Initialized == false || ChunkManager.Initialized == false) return;

        Index curIndex = Engine.PositionToChunkIndex(playerTrans.position);

        if (lastIndex != curIndex)
        {
            ChunkManager.SpawnChunks(playerTrans.position);
            lastIndex = curIndex;
        }
    }
}
