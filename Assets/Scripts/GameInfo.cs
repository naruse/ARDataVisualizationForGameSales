/*
 Created by:
 Juan Sebastian Munoz Arango
 naruse@gmail.com
 all rights reserved

 This class serves as info visualization for each game data part
 */

using UnityEngine;

public class GameInfo : MonoBehaviour {

    private string info;

    public void SetInfo(string s) {
        info = s;
    }

    public string GetInfo() {
        return info;
    }
}