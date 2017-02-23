using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  Data from:
  https://www.kaggle.com/rush4ratio/video-game-sales-with-ratings/
 */

public class DataLoader : MonoBehaviour {

    private const string fileToLoadName = "VideoGamesSalesUntil22Dec2016";
	void Start () {

	}


    private void ParseFile() {
        TextAsset fileContents = Resources.Load(fileToLoadName) as TextAsset;
        string[] lines = fileContents.text.Split(char.Parse("\n"));

        try {


        } catch (System.Exception e) {

            UnityEngine.Debug.LogError("ERROR: " + e.ToString());
        }
    }
}
