/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  A Console reference is simply a subreference of a console:
  i.e the super nintendo is a console reference of the nintendo console
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform {

    private List<GameData> games;
    private string completeName;
    public string platformName { get { return completeName; } }

    public Platform(PLATFORM platformType, string name) {
        games = new List<GameData>();
        completeName = name;
    }

}
