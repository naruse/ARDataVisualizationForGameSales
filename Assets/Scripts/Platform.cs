/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  A Console reference is simply a subreference of a console:
  i.e the super nintendo is a console reference of the nintendo console
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform {

    private List<GameData> games;

    private string completeName;
    public string platformName { get { return completeName; } }

    private PLATFORM platformType;
    public PLATFORM PlatformType { get { return platformType; } }


    private GameDataYearComparer gameYearComp;
    public Platform(PLATFORM _platformType, string name) {
        //gameYearComp = ;

        games = new List<GameData>();

        platformType = _platformType;
        completeName = name;
    }

    public void AddGame(GameData gameToAdd) {
        int index = games.BinarySearch(gameToAdd, new GameDataYearComparer());
        if (index < 0) index = ~index;
        games.Insert(index, gameToAdd);
    }

    public void PrintGames() {
        for(int i = 0; i < games.Count; i++)
            Debug.Log(games[i].YearOfRelease);
    }

}
