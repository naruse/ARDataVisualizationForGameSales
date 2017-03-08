/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This class is used for sorting GameData objs by year in the Platform array of GameData objs
*/

using System;
using System.Collections.Generic;
public class GameDataYearComparer : IComparer<GameData> {

    public int Compare(GameData gameA, GameData gameB) {
        if(gameA == null) return -1;
        if(gameB == null) return 1;

        if(gameA.YearOfRelease == gameB.YearOfRelease) return 0;

        return gameA.YearOfRelease > gameB.YearOfRelease ? 1 : -1;
    }
}