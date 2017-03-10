/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved
 */

using UnityEngine;

public class GameData {

    private static readonly float scale = 1f;
    private static readonly float width = 1;
    private static readonly float depth = 1;

    public static Vector2 GetDimensions() {
        return new Vector2((width+width*0.5f)*scale, ((depth < width) ? width : depth)*scale);
    }

    private string name;
    private uint releaseYear;
    public uint YearOfRelease { get { return releaseYear; } }

    private float salesUS;
    private float salesEU;
    private float salesJP;
    private float salesOther;
    private float salesGlobal;

    private float criticScore;
    private uint criticCount;

    private float userScore;
    private uint userCount;

    private string developer;
    private string publisher;

    private RATING gameRating;

    private GENRE genre;
    public GameData(string gameName, uint year, GENRE _genre, string _publisher,
                    float USSales, float EUSales, float JPSales, float otherSales, float globalSales,
                    float _criticScore, uint _criticCount,
                    float _userScore, uint _userCount,
                    string _developer, RATING _gameRating) {
        name = gameName;
        releaseYear = year;
        genre = _genre;

        salesUS = USSales;
        salesEU = EUSales;
        salesJP = JPSales;
        salesOther = otherSales;
        salesGlobal = globalSales;

        criticScore = _criticScore;
        criticCount = _criticCount;
        userScore = _userScore;
        userCount = _userCount;

        developer = _developer;
        publisher = _publisher;
        gameRating = _gameRating;
    }

    private string GenerateInfoForGame() {
        string info =
            "Name:       " + name + "\n" +
            "Year:       " + releaseYear + "\n\n" +
            "Sales US:   " + salesUS + " Millions\n" +
            "Sales EU:   " + salesEU + " Millions\n" +
            "Sales JP:   " + salesJP + " Millions\n" +
            "Sales Other:" + salesOther + " Millions\n" +
            "Total Sales:" + salesGlobal + " Millions\n\n" +
            "Critic score: " + criticScore + " Count: " + criticCount + "\n" +
            "User score  : " + userScore + " Count: " + userCount + "\n\n" +
            "Publisher: " + publisher + "\n" +
            "Developer: " + developer + "\n\n" +
            "Genre: " + genre + "\n" +
            "Rating: " + gameRating;

        return info;
    }

    public GameObject DrawGameSales() {

        //Debug.Log(salesUS + " " + salesEU + " " + salesJP + " " + salesOther + " " + salesGlobal);
        GameObject data = new GameObject(name);
        GameObject usSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        data.transform.position = Vector3.zero;

        usSalesGO.name = "USSales";
        Color paleBlue = new Color(0.19216f, 0.30196f, 0.47451f);
        usSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleBlue);
        usSalesGO.transform.localScale = new Vector3(width, 1+salesUS, depth) * scale;
        usSalesGO.transform.position = new Vector3(0, usSalesGO.transform.localScale.y, 0) * 0.5f;

        GameObject euSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        euSalesGO.name = "EUSales";
        Color paleYellow = new Color(0.46275f, 0.47451f, 0.19216f);
        euSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleYellow);
        euSalesGO.transform.localScale = new Vector3(width, 1+salesEU, depth) * scale;
        euSalesGO.transform.position =
            new Vector3(0,
                        (usSalesGO.transform.position.y+usSalesGO.transform.localScale.y/2)+euSalesGO.transform.localScale.y/2,
                        0);

        GameObject jpSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        jpSalesGO.name = "JPSales";
        Color paleRed = new Color(0.45471f, 0.19216f, 0.19216f);
        jpSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleRed);
        jpSalesGO.transform.localScale = new Vector3(width, 1+salesJP, depth) * scale;
        jpSalesGO.transform.position =
            new Vector3(0,
                        (euSalesGO.transform.position.y+euSalesGO.transform.localScale.y/2)+jpSalesGO.transform.localScale.y/2,
                        0);

        GameObject otherSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        otherSalesGO.name = "OtherSales";
        otherSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(Color.white);
        otherSalesGO.transform.localScale = new Vector3(width, 1+salesOther, depth) * scale;
        otherSalesGO.transform.position =
           new Vector3(0,
                      (jpSalesGO.transform.position.y+jpSalesGO.transform.localScale.y/2)+otherSalesGO.transform.localScale.y/2,
                       0);


        float globalSalesScaleAndPos = (otherSalesGO.transform.position.y+otherSalesGO.transform.localScale.y/2)/2;
        GameObject globalSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        globalSalesGO.name = "GlobalSales";
        Color paleMagenta = new Color(0.38431f, 0.19216f, 0.47451f);
        globalSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleMagenta);
        globalSalesGO.transform.localScale =
            new Vector3(width*0.9f*scale, globalSalesScaleAndPos, width*0.9f*scale);//scale on xz is width as is a cylinder
        globalSalesGO.transform.position =
            new Vector3(width*0.5f*scale,
                        globalSalesScaleAndPos + 0.01f,//avoid z-fight
                        0);//place in corner

        string gameInfo = GenerateInfoForGame();
        usSalesGO.AddComponent<GameInfo>().SetInfo(gameInfo);
        euSalesGO.AddComponent<GameInfo>().SetInfo(gameInfo);
        jpSalesGO.AddComponent<GameInfo>().SetInfo(gameInfo);
        otherSalesGO.AddComponent<GameInfo>().SetInfo(gameInfo);
        globalSalesGO.AddComponent<GameInfo>().SetInfo(gameInfo);

        /*GameObject.Destroy(usSalesGO.GetComponent<Collider>());
        GameObject.Destroy(euSalesGO.GetComponent<Collider>());
        GameObject.Destroy(jpSalesGO.GetComponent<Collider>());
        GameObject.Destroy(otherSalesGO.GetComponent<Collider>());
        GameObject.Destroy(globalSalesGO.GetComponent<Collider>());*/

        usSalesGO.transform.parent = data.transform;
        euSalesGO.transform.parent = data.transform;
        jpSalesGO.transform.parent = data.transform;
        otherSalesGO.transform.parent = data.transform;
        globalSalesGO.transform.parent = data.transform;
        /*GameObject.Destroy(usSalesGO);
        GameObject.Destroy(euSalesGO);
        GameObject.Destroy(jpSalesGO);
        GameObject.Destroy(otherSalesGO);*/

        return data;
    }
}