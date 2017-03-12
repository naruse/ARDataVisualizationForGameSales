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

public class Console {

    private string consoleName;
    private List<Platform> platforms;
    public List<Platform> Platforms { get { return platforms; } }

    //contains the already drawn platforms
    private Dictionary<PLATFORM, GameObject> cachedPlatforms;

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
        if(cachedPlatforms.ContainsKey(platformType)) {
            cachedPlatforms[platformType].SetActive(draw);
            return;
        }
        if(!draw)
            return;

        for(int i = 0; i < platforms.Count; i++)
            if(platformType == platforms[i].PlatformType) {
                cachedPlatforms.Add(platformType, platforms[i].DrawGames());
                return;
            }
        Debug.LogError("Console " + consoleName +
                       " Doesnt have platform: " + platformType.ToString());
    }
}