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
            (releaseYear != 0 ? releaseYear.ToString() : "NoYear") + " - " +
            name +
            (publisher != "N/A"?" - Publisher: " + publisher : " - developer: " + developer) + "\n" +
            //"Year:       " + releaseYear + "\n\n" +
            (salesUS != 0 ?"Sales US: " + salesUS:"") +
            (salesEU != 0 ?" EU: "+salesEU:"") +
            (salesJP != 0 ? " JP: "+salesJP:"") +
            (salesOther != 0 ? " Other: "+salesOther:"") +
            (salesGlobal != 0 ? " Total:$"+salesGlobal+"m":"???") +
            "<color=yellow> Genre: " + genre.ToString().ToLower() + " ESRB: " + gameRating + "</color>\n" +

            "Critic score: " + criticScore + " Count: " + criticCount + "\n" +
            "User score  : " + userScore + " Count: " + userCount;

        return info;
    }

    public GameObject DrawGameSales() {
        //todo: Simplify positions and scales..
        //Debug.Log(salesUS + " " + salesEU + " " + salesJP + " " + salesOther + " " + salesGlobal);
        GameObject data = new GameObject(name);
        data.transform.position = Vector3.zero;

        if(salesUS > 0) {
            GameObject usSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Destroy(usSalesGO.GetComponent<Collider>());
            usSalesGO.name = "USSales";
            Color paleBlue = new Color(0.19216f, 0.30196f, 0.47451f);
            usSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleBlue);
            usSalesGO.transform.localScale = new Vector3(width, salesUS, depth) * scale;
            usSalesGO.transform.position = new Vector3(0, salesUS*scale, 0) * 0.5f;
            usSalesGO.transform.parent = data.transform;
        }
        if(salesEU > 0) {
            GameObject euSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Destroy(euSalesGO.GetComponent<Collider>());
            euSalesGO.name = "EUSales";
            Color paleYellow = new Color(0.46275f, 0.47451f, 0.19216f);
            euSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleYellow);
            euSalesGO.transform.localScale = new Vector3(width, salesEU, depth) * scale;
            euSalesGO.transform.position =
                new Vector3(0,
                            (salesUS*scale*0.5f+salesUS*scale/2)+salesEU*scale/2,
                            0);
            euSalesGO.transform.parent = data.transform;
        }
        if(salesJP > 0) {
            GameObject jpSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Destroy(jpSalesGO.GetComponent<Collider>());
            jpSalesGO.name = "JPSales";
            Color paleRed = new Color(0.45471f, 0.19216f, 0.19216f);
            jpSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleRed);
            jpSalesGO.transform.localScale = new Vector3(width, salesJP, depth) * scale;
            jpSalesGO.transform.position =
                new Vector3(0,
                            ((salesUS*scale*0.5f+salesUS*scale/2)+salesEU*scale/2+salesEU*scale/2)+salesJP*scale/2,
                            0);
            jpSalesGO.transform.parent = data.transform;
        }
        if(salesOther > 0) {
            GameObject otherSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Destroy(otherSalesGO.GetComponent<Collider>());
            otherSalesGO.name = "OtherSales";
            otherSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(Color.white);
            otherSalesGO.transform.localScale = new Vector3(width, salesOther, depth) * scale;
            otherSalesGO.transform.position =
           new Vector3(0,
                       (((salesUS*scale*0.5f+salesUS*scale/2)+salesEU*scale/2+salesEU*scale/2)+salesJP*scale/2+(salesJP*scale)/2)+(salesOther*scale)/2,
                       0);
            otherSalesGO.transform.parent = data.transform;
        }
        float globalSalesScaleAndPos = ((((salesUS*scale*0.5f+salesUS*scale/2)+salesEU*scale/2+salesEU*scale/2)+salesJP*scale/2+(salesJP*scale)/2)+(salesOther*scale)/2+//otherSalesGO.transform.position.y+
                                        salesOther*scale//otherSalesGO.transform.localScale.y
                                        /2)/2;

        GameObject globalSalesGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject.Destroy(globalSalesGO.GetComponent<Collider>());
        globalSalesGO.name = "GlobalSales";
        Color paleMagenta = new Color(0.38431f, 0.19216f, 0.47451f);
        globalSalesGO.GetComponent<Renderer>().material = MaterialManager.Instance.GetMaterial(paleMagenta);
        globalSalesGO.transform.localScale =
            new Vector3(width*0.9f*scale, globalSalesScaleAndPos, width*0.9f*scale);//scale on xz is width as is a cylinder
        globalSalesGO.transform.position =
            new Vector3(width*0.5f*scale,
                        globalSalesScaleAndPos + 0.01f,//avoid z-fight
                        0);//place in corner
        globalSalesGO.transform.parent = data.transform;

        string gameInfo = GenerateInfoForGame();
        data.AddComponent<GameInfo>().SetInfo(gameInfo);


        Vector2 collSize = GetDimensions();
        data.AddComponent<BoxCollider>();
        data.GetComponent<BoxCollider>().center = new Vector3((width*0.5f*scale)/2, (globalSalesScaleAndPos+0.01f), 0);
        data.GetComponent<BoxCollider>().size = new Vector3(collSize.x,
                                                            (globalSalesScaleAndPos+0.01f)*2,
                                                            collSize.y);
        return data;
    }
}