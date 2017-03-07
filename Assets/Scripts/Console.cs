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

    public Console(string name) {
        platforms = new List<Platform>();
        consoleName = name;
    }
}
