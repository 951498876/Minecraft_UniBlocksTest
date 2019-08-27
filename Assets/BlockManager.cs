using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniblocks;
public class BlockManager : MonoBehaviour {

    public int range = 10;

    private ushort blockID = 0;
    private Transform selectedBlockFrame;
	void Start () {
        selectedBlockFrame = GameObject.Find("selected block graphics").transform;
        selectedBlockFrame.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        SelectBlockID();

        VoxelInfo voxelInfo = Engine.VoxelRaycast(Camera.main.transform.position, Camera.main.transform.forward, range, false);

        if (null != voxelInfo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Voxel.DestroyBlock(voxelInfo);
            }

            if (Input.GetMouseButtonDown(1))
            {
                VoxelInfo targetInfo = new VoxelInfo(voxelInfo.adjacentIndex, voxelInfo.chunk);
                Voxel.PlaceBlock(targetInfo, blockID);
            }
        }
        UpdateSelectedBlock(voxelInfo);
    }

    private void SelectBlockID()
    {
        for (ushort i = 1; i < 10; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                blockID = i;
            }
        }
    }

    private void UpdateSelectedBlock(VoxelInfo info)
    {
        if (null != info)
        {
            selectedBlockFrame.gameObject.SetActive(true);
            selectedBlockFrame.position = info.chunk.VoxelIndexToPosition(info.index);
        }
        else
        {
            selectedBlockFrame.gameObject.SetActive(false);
        }
    }

}
