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
        ParseFile();
	}


    List<string> platforms;
    private void ParseFile() {
        platforms = new List<string>();
        TextAsset fileContents = Resources.Load(fileToLoadName) as TextAsset;
        string[] lines = fileContents.text.Split(char.Parse("\n"));
        string stringToParse = "";

        //try {
            for(int i = 0; i < lines.Length; i++) {
                if(lines[i] == "")
                    continue;
                stringToParse = lines[i];
                if(lines[i].Contains("\"")) {
                    stringToParse = RemoveCommasFromSubstring(lines[i]);
                }
                string[] dataValues = stringToParse.Split(char.Parse(","));

                //Debug.Log("Line: " + i.ToString() + " " +  stringToParse + " " + dataValues.Length);
                if(!ValueExists(platforms, dataValues[3]))
                    platforms.Add(dataValues[3]);
            }
            for(int i = 0 ; i < platforms.Count;i++)
                Debug.Log(platforms[i]);
        //} catch (System.Exception e) {

        //    UnityEngine.Debug.LogError("ERROR: " + e.ToString());
        //}
    }

    private bool ValueExists(List<string> values, string val) {
        for(int i = 0; i < values.Count; i++) {
            if(values[i] == val)
                return true;
        }
        return false;
    }

    //Given a string, removes the commas from the substring inside \" \"
    private string RemoveCommasFromSubstring(string line) {
        int initialQuotationMarkIndex = -1;
        bool firstQuotation = true;
        string processedLine = line;
        for(int i = 0; i < processedLine.Length; i++) {
            if(processedLine[i] == '"') {
                if(firstQuotation) {
                    initialQuotationMarkIndex = i;
                    firstQuotation = false;
                } else {
                    firstQuotation = true;
                    string originalSubstring = processedLine.Substring(initialQuotationMarkIndex+1, i-initialQuotationMarkIndex-1);
                    string replacedSubstring = originalSubstring.Replace(',', '|');
                    processedLine = processedLine.Replace(originalSubstring, replacedSubstring).Replace("\"","");
                    i = 0;//redo the whole process again (think about optimizing this.)
                }
            }
        }
        return processedLine;
    }
}
