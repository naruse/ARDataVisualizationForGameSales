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

    private uint platformReleaseYear = 9999;
    private uint platformLastYear = 0;

    private GameDataYearComparer gameYearComp;
    public Platform(PLATFORM _platformType, string name) {
        gameYearComp = new GameDataYearComparer();

        games = new List<GameData>();

        platformType = _platformType;
        completeName = name;
    }

    public void AddGame(GameData gameToAdd) {
        platformReleaseYear = (gameToAdd.YearOfRelease < platformReleaseYear) &&  (gameToAdd.YearOfRelease != 0) ? gameToAdd.YearOfRelease : platformReleaseYear;
        platformLastYear = gameToAdd.YearOfRelease > platformLastYear ? gameToAdd.YearOfRelease : platformLastYear;
        int index = games.BinarySearch(gameToAdd, gameYearComp);
        if (index < 0) index = ~index;
        games.Insert(index, gameToAdd);
    }

    public void PrintGames() {
        for(int i = 0; i < games.Count; i++)
            Debug.Log(games[i].YearOfRelease);
        //games[i].DrawGameSales();
    }

    public void DrawPlatform(int gamesPerYearPlacedHorizontally = 5) {
        Vector2 gameDataDimensions = GameData.GetDimensions();
        float width = gameDataDimensions.x;
        float depth = gameDataDimensions.y;

        float centerOffset = (float)gamesPerYearPlacedHorizontally/2.0f+width/2;//used to center the platform pivot

        GameObject platform = GeneratePlatformRoot();
        int x = 0;
        int y = 0;
        uint lastProcessedYear = 1;//not 0 because unknown years for games have the 0 year
        for(int i = 0; i < games.Count; i++) {
            if(lastProcessedYear != games[i].YearOfRelease || x == (gamesPerYearPlacedHorizontally)) {
                x = 0;
                y = (lastProcessedYear != games[i].YearOfRelease) ? y+2 : y+1;//add more spacing on year change
            }
            GameObject drawnData = games[i].DrawGameSales();
            drawnData.transform.position = new Vector3((width * (float)x) - centerOffset, 0, depth * (float)y);
            drawnData.transform.parent = platform.transform;
            lastProcessedYear = games[i].YearOfRelease;
            x++;
        }
    }

    private GameObject GeneratePlatformRoot() {
        GameObject platform = new GameObject(platformType.ToString());
        Quaternion platformRot = Quaternion.identity;
        platformRot.eulerAngles = new Vector3(90,0,0);
        platform.transform.rotation = platformRot;
        platform.AddComponent<TextMesh>().text = completeName + "\n" + platformReleaseYear + " - " + platformLastYear;
        platform.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
        platform.GetComponent<TextMesh>().alignment = TextAlignment.Center;
        platform.GetComponent<TextMesh>().characterSize = 0.7f;
        platform.transform.position = Vector3.zero;

        return platform;
    }
}
