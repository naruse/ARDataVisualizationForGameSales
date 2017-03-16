/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This class represents the big console manufacturers i.e: Sony, Microsoft, Nintendo, PC and others
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Console {

    private string consoleName;
    private List<Platform> platforms;
    public List<Platform> Platforms { get { return platforms; } }

    //contains the already drawn platforms
    private Dictionary<PLATFORM, GameObject> cachedPlatforms;
    public GameObject GetCachedPlatform(PLATFORM plat) {
        if(cachedPlatforms.ContainsKey(plat))
            return cachedPlatforms[plat];
        return null;
    }

    public Console(string name, List<Platform> _platforms) {
        platforms = _platforms;
        consoleName = name;

        cachedPlatforms = new Dictionary<PLATFORM, GameObject>();
    }

    public void AddGame(PLATFORM gamePlatform, GameData gameData) {
        //can be optimized with a binary search if the enum is in ascending order :-)
        for(int i = 0; i < platforms.Count; i++) {
            if(gamePlatform == platforms[i].PlatformType) {
                platforms[i].AddGame(gameData);
                return;
            }
        }
        Debug.LogError("Console " + consoleName +
                       " Doesnt have platform " + gamePlatform.ToString());
    }

    //draws or hides a platform in either left or right side of an image target
    public void DrawHidePlatform(bool draw, PLATFORM platformType, SIDE drawSide) {
        GameObject targetToDrawPlatform = ImageTargetManager.Instance.GetCurrentMainTarget();
        if(cachedPlatforms.ContainsKey(platformType)) {
            cachedPlatforms[platformType].SetActive(draw);
            if(draw) {
                ParentPlatformRootToImageTarget(targetToDrawPlatform,
                                                cachedPlatforms[platformType],
                                                drawSide);
            }
            return;
        }
        if(!draw) return;

        for(int i = 0; i < platforms.Count; i++)
            if(platformType == platforms[i].PlatformType) {
                cachedPlatforms.Add(platformType, platforms[i].DrawGames(15));
                ParentPlatformRootToImageTarget(targetToDrawPlatform,
                                                cachedPlatforms[platformType],
                                                drawSide);
                return;
            }
        Debug.LogError("Console " + consoleName +
                       " Doesnt have platform: " + platformType.ToString());
    }

    private void ParentPlatformRootToImageTarget(GameObject imgTarget, GameObject platformRoot,
                                                 SIDE drawSide) {
        platformRoot.transform.parent = imgTarget.transform;
        Vector3 targetBounds = imgTarget.GetComponent<BoxCollider>().size;
        float distBtwnPlatforms = 0.1f;//TODO FIX THIS magic number

        platformRoot.transform.rotation = imgTarget.transform.rotation;
        switch(drawSide) {
            case SIDE.LEFT:
                platformRoot.transform.localPosition = new Vector3((-targetBounds.z)/4-distBtwnPlatforms,
                                                                   0,
                                                                   -(targetBounds.x)/2);
                break;
            case SIDE.RIGHT:
                platformRoot.transform.localPosition = new Vector3((targetBounds.z)/4+distBtwnPlatforms,
                                                                   0,
                                                                   -(targetBounds.x)/2);
                break;
            default:
                Debug.LogError("Unknown side: " + drawSide + " When placing platform root on target");
                break;
        }

    }
}