/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved
 */

public class GameData {

    private float name;
    private uint releaseYear;
    private float salesUS;
    private float salesEU;
    private float salesJP;
    private float otherSales;
    private float globalSales;

    private float criticScore;
    private int criticCount;

    private float userScore;
    private int userCount;

    private string developer;
    private RATING gameRating;

    private GENRE genre;
    public GameData(string gameName, uint year, GENRE _genre,
                    float USSales, float EUSales, float JPSales, float otherSales, float globalSales,
                    float _criticScore, float _criticCount,
                    float _userScore, float _userCount,
                    string _developer, RATING _gameRating) {

    }
}