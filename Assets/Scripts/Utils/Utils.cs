/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Utils {

    public static GENRE ConvertStrToGenre(string s) {
        GENRE detectedGenre = GENRE.UNKNOWN;
        switch(s.Trim()) {
            case "Sports":
                detectedGenre = GENRE.SPORTS;
                break;
            case "Platform":
                detectedGenre = GENRE.PLATFORM;
                break;
            case "Racing":
                detectedGenre = GENRE.RACING;
                break;
            case "Role-Playing":
                detectedGenre = GENRE.ROLE_PLAYING;
                break;
            case "Puzzle":
                detectedGenre = GENRE.PUZZLE;
                break;
            case "Shooter":
                detectedGenre = GENRE.SHOOTER;
                break;
            case "Simulation":
                detectedGenre = GENRE.SIMULATION;
                break;
            case "Action":
                detectedGenre = GENRE.ACTION;
                break;
            case "Fighting":
                detectedGenre = GENRE.FIGHTING;
                break;
            case "Adventure":
                detectedGenre = GENRE.ADVENTURE;
                break;
            case "Strategy":
                detectedGenre = GENRE.STRATEGY;
                break;
            case "":
            case "Misc":
                detectedGenre = GENRE.MISC;
                break;
            default:
                Debug.LogError("Unknown genre: " + s);
                break;
        }
        return detectedGenre;
    }

    public static GameData GenerateGame(string _name, string _year, string _genre, string _publisher,
                                 string _usSales, string _euSales, string _jpSales, string _otherSales, string _globalSales,
                                 string _criticScore, string _criticCount, string _userScore, string _userCount,
                                 string _developer, string _rating) {

        uint year = _year != "N/A" ? Convert.ToUInt32(_year) : 0;

        GENRE genre = ConvertStrToGenre(_genre);

        float usSales = Convert.ToSingle(_usSales);
        float euSales = Convert.ToSingle(_euSales);
        float jpSales = Convert.ToSingle(_jpSales);
        float otherSales = Convert.ToSingle(_otherSales);
        float globalSales = Convert.ToSingle(_globalSales);


        float criticScore = (_criticScore != "" && _criticScore != "tbd") ? Convert.ToSingle(_criticScore) : -1;
        uint criticCount = (_criticCount != "" && _criticCount != "tbd") ? Convert.ToUInt32(_criticCount) : 0;
        float userScore = (_userScore != "" && _userScore != "tbd") ? Convert.ToSingle(_userScore) : -1;
        uint userCount = (_userCount != "" && _userCount != "tbd") ? Convert.ToUInt32(_userCount) : 0;

        RATING rating = ConvertStrToRating(_rating);

        return new GameData(_name, year, genre, _publisher, usSales, euSales, jpSales, otherSales, globalSales,
                            criticScore, criticCount, userScore, userCount, _developer, rating);
    }

    public static PLATFORM ConvertStrToPlatform(string s) {
        PLATFORM detectedPlatform = PLATFORM.UNKNOWN;
        switch(s.Trim()) {
            case "NES":
                detectedPlatform = PLATFORM.NES;
                break;
            case "SNES":
                detectedPlatform = PLATFORM.SNES;
                break;
            case "GB":
                detectedPlatform = PLATFORM.GB;
                break;
            case "GBA":
                detectedPlatform = PLATFORM.GBA;
                break;
            case "DS":
                detectedPlatform = PLATFORM.DS;
                break;
            case "3DS":
                detectedPlatform = PLATFORM.N3DS;
                break;
            case "N64":
                detectedPlatform = PLATFORM.N64;
                break;
            case "GC":
                detectedPlatform = PLATFORM.GAME_CUBE;
                break;
            case "Wii":
                detectedPlatform = PLATFORM.WII;
                break;
            case "WiiU":
                detectedPlatform = PLATFORM.WIIU;
                break;

            case "PS":
                detectedPlatform = PLATFORM.PS;
                break;
            case "PS2":
                detectedPlatform = PLATFORM.PS2;
                break;
            case "PS3":
                detectedPlatform = PLATFORM.PS3;
                break;
            case "PS4":
                detectedPlatform = PLATFORM.PS4;
                break;
            case "PSP":
                detectedPlatform = PLATFORM.PSP;
                break;
            case "PSV":
                detectedPlatform = PLATFORM.PS_VITA;
                break;

            case "XB":
                detectedPlatform = PLATFORM.XBOX;
                break;
            case "X360":
                detectedPlatform = PLATFORM.XBOX360;
                break;
            case "XOne":
                detectedPlatform = PLATFORM.XBOXONE;
                break;

            case "SAT":
                detectedPlatform = PLATFORM.SEGA_SATURN;
                break;
            case "SCD":
                detectedPlatform = PLATFORM.SEGA_CD;
                break;
            case "GEN":
                detectedPlatform = PLATFORM.SEGA_GENESIS;
                break;
            case "DC":
                detectedPlatform = PLATFORM.SEGA_DREAMCAST;
                break;
            case "GG":
                detectedPlatform = PLATFORM.SEGA_GAMEGEAR;
                break;

            case "PC":
                detectedPlatform = PLATFORM.PC;
                break;

            case "2600":
                detectedPlatform = PLATFORM.ATARI2600;
                break;
            case "WS":
                detectedPlatform = PLATFORM.WONDER_SWAN;
                break;
            case "NG":
                detectedPlatform = PLATFORM.NEO_GEO;
                break;
            case "TG16":
                detectedPlatform = PLATFORM.TG16;
                break;
            case "3DO":
                detectedPlatform = PLATFORM._3DO;
                break;
            case "PCFX":
                detectedPlatform = PLATFORM.PCFX;
                break;

            default:
                Debug.LogError("Unknown platform " + s);
                detectedPlatform = PLATFORM.UNKNOWN;
                break;
        }
        return detectedPlatform;
    }


    public static RATING ConvertStrToRating(string s) {
        RATING detectedRating = RATING.UNKNOWN;
        switch(s.Trim()) {
            case "E":
            case "K-A":
                detectedRating = RATING.E;
                break;
            case "M":
                detectedRating = RATING.M;
                break;
            case "T":
                detectedRating = RATING.T;
                break;
            case "E10+":
                detectedRating = RATING.E10PLUS;
                break;
            case "AO":
                detectedRating = RATING.AO;
                break;
            case "EC":
                detectedRating = RATING.EC;
                break;
            case "RP":
                detectedRating = RATING.RP;
                break;
            case "":
                detectedRating = RATING.UNKNOWN;
                break;
            default:
                Debug.LogError("Unknown rating: " + s);
                break;
        }
        return detectedRating;
    }
}