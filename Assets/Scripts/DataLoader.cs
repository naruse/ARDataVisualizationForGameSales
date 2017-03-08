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
    private Console nintendo;
    private Console sony;
    private Console microsoft;
    private Console sega;
    private Console pc;
    private Console other;

	void Start () {
        InitializeConsolesAndPlatforms();
        ParseFile();
	}

    private void ParseFile() {
        TextAsset fileContents = Resources.Load(fileToLoadName) as TextAsset;
        string[] lines = fileContents.text.Split(char.Parse("\n"));
        string stringToParse = "";

        for(int i = 1; i < lines.Length; i++) {
            if(lines[i] == "")
                continue;
            stringToParse = lines[i];
            if(lines[i].Contains("\"")) {
                stringToParse = RemoveCommasFromSubstring(lines[i]);
            }
            string[] dataValues = stringToParse.Split(char.Parse(","));
            GameData parsedGame = Utils.GenerateGame(dataValues[0]/*name*/, dataValues[2]/*year*/, dataValues[3]/*genre*/,
                                                     dataValues[4]/*publisher*/,dataValues[5]/*NASales*/,
                                                     dataValues[6]/*EUSales*/, dataValues[7]/*JPSales*/,
                                                     dataValues[8]/*OtherSales*/,dataValues[9]/*GlobalSales*/,
                                                     dataValues[10]/*criticScore*/, dataValues[11]/*criticCount*/,
                                                     dataValues[12]/*userScore*/, dataValues[13]/*userCount*/,
                                                     dataValues[14]/*Developer*/, dataValues[15]/*Rating*/);
            PLATFORM parsedPlatform = Utils.ConvertStrToPlatform(dataValues[1]);
            AddGameToConsole(parsedGame, parsedPlatform);
        }
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


    private void AddGameToConsole(GameData game, PLATFORM consolePlatform) {
        switch(consolePlatform) {
            case PLATFORM.NES:
            case PLATFORM.SNES:
            case PLATFORM.GB:
            case PLATFORM.GBA:
            case PLATFORM.DS:
            case PLATFORM.N3DS:
            case PLATFORM.N64:
            case PLATFORM.GAME_CUBE:
            case PLATFORM.WII:
            case PLATFORM.WIIU:
                nintendo.AddGame(consolePlatform, game);
                break;

            case PLATFORM.PS:
            case PLATFORM.PS2:
            case PLATFORM.PS3:
            case PLATFORM.PS4:
            case PLATFORM.PSP:
            case PLATFORM.PS_VITA:
                sony.AddGame(consolePlatform, game);
                break;

            case PLATFORM.XBOX:
            case PLATFORM.XBOX360:
            case PLATFORM.XBOXONE:
                microsoft.AddGame(consolePlatform, game);
                break;

            case PLATFORM.SEGA_SATURN:
            case PLATFORM.SEGA_CD:
            case PLATFORM.SEGA_GENESIS:
            case PLATFORM.SEGA_DREAMCAST:
            case PLATFORM.SEGA_GAMEGEAR:
                sega.AddGame(consolePlatform, game);
                break;

            case PLATFORM.PC:
                pc.AddGame(consolePlatform, game);
                break;

            case PLATFORM.ATARI2600:
            case PLATFORM.NEO_GEO:
            case PLATFORM.WONDER_SWAN:
            case PLATFORM.TG16:
            case PLATFORM._3DO:
            case PLATFORM.PCFX:
                other.AddGame(consolePlatform, game);
                break;

            default:
                Debug.LogError("Couldnt fit platform" + consolePlatform + " for game");
                break;
        }
    }

     private void InitializeConsolesAndPlatforms() {
        List<Platform> nintendoPlatforms = new List<Platform>();
        nintendoPlatforms.Add(new Platform(PLATFORM.NES, "Original Nintendo"));
        nintendoPlatforms.Add(new Platform(PLATFORM.SNES, "Super Nintendo"));
        nintendoPlatforms.Add(new Platform(PLATFORM.GB, "Gameboy"));
        nintendoPlatforms.Add(new Platform(PLATFORM.GBA, "Gameboy Advance"));
        nintendoPlatforms.Add(new Platform(PLATFORM.DS, "Nintendo DS"));
        nintendoPlatforms.Add(new Platform(PLATFORM.N3DS, "Nintendo 3DS"));
        nintendoPlatforms.Add(new Platform(PLATFORM.N64, "Nintendo 64"));
        nintendoPlatforms.Add(new Platform(PLATFORM.GAME_CUBE, "Game Cube"));
        nintendoPlatforms.Add(new Platform(PLATFORM.WII, "Wii"));
        nintendoPlatforms.Add(new Platform(PLATFORM.WIIU, "Wii U"));
        nintendo = new Console("Nintendo", nintendoPlatforms);

        List<Platform> sonyPlatforms = new List<Platform>();
        sonyPlatforms.Add(new Platform(PLATFORM.PS, "Playstation"));
        sonyPlatforms.Add(new Platform(PLATFORM.PS2, "Playstation 2"));
        sonyPlatforms.Add(new Platform(PLATFORM.PS3, "Playstation 3"));
        sonyPlatforms.Add(new Platform(PLATFORM.PS4, "Playstation 4"));
        sonyPlatforms.Add(new Platform(PLATFORM.PSP, "PSP"));
        sonyPlatforms.Add(new Platform(PLATFORM.PS_VITA, "Playstation Vita"));
        sony = new Console("Sony", sonyPlatforms);

        List<Platform> microsoftPlatforms = new List<Platform>();
        microsoftPlatforms.Add(new Platform(PLATFORM.XBOX, "XBox"));
        microsoftPlatforms.Add(new Platform(PLATFORM.XBOX360, "XBox 360"));
        microsoftPlatforms.Add(new Platform(PLATFORM.XBOXONE, "XBox one"));
        microsoft = new Console("Microsoft", microsoftPlatforms);

        List<Platform> segaPlatforms = new List<Platform>();
        segaPlatforms.Add(new Platform(PLATFORM.SEGA_SATURN, "Saturn"));
        segaPlatforms.Add(new Platform(PLATFORM.SEGA_CD, "CD"));
        segaPlatforms.Add(new Platform(PLATFORM.SEGA_GENESIS, "Genesis"));
        segaPlatforms.Add(new Platform(PLATFORM.SEGA_DREAMCAST, "Dreamcast"));
        segaPlatforms.Add(new Platform(PLATFORM.SEGA_GAMEGEAR, "Game Gear"));
        sega = new Console("Sega", segaPlatforms);

        List<Platform> pcPlatforms = new List<Platform>();
        pcPlatforms.Add(new Platform(PLATFORM.PC, "PC"));
        pc = new Console("PC", pcPlatforms);

        List<Platform> otherPlatforms = new List<Platform>();
        otherPlatforms.Add(new Platform(PLATFORM.ATARI2600, "Atari 2600"));
        otherPlatforms.Add(new Platform(PLATFORM.NEO_GEO, "Neo Geo"));
        otherPlatforms.Add(new Platform(PLATFORM.TG16, "TurboGrafx 16"));
        otherPlatforms.Add(new Platform(PLATFORM._3DO, "Panasonic 3DO"));
        otherPlatforms.Add(new Platform(PLATFORM.PCFX, "PC FX"));
        otherPlatforms.Add(new Platform(PLATFORM.WONDER_SWAN, "Wonder Swan"));
        other = new Console("Other", otherPlatforms);
    }
}
