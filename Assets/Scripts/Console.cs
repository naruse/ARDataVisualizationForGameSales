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

    public Console(string name, List<Platform> _platforms) {
        platforms = _platforms;
        consoleName = name;
    }

    public void AddGame(PLATFORM gamePlatform, GameData gameData) {
        for(int i = 0; i < platforms.Count; i++) {
            if(gamePlatform == platforms[i].PlatformType) {
                platforms[i].AddGame(gameData);
                return;
            }
        }
        Debug.LogError("Console " + consoleName +
                       " Doesnt have platform " + gamePlatform.ToString());
    }

    //public void DrawPlatform
}