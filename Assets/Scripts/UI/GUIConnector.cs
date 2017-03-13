using UnityEngine;
using UnityEngine.UI;

/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This is basically a class that connects the DataLoader class with the Unity UI
 */

[RequireComponent(typeof(DataLoader))]
public class GUIConnector : MonoBehaviour {

    public Camera mainCamera;
    public Text gameDescription;
    private DataLoader dataLoader;

    void Start() {
        dataLoader = GetComponent<DataLoader>();
        if(dataLoader == null)
            Debug.LogError("Cant connect DataLoader to UI");
    }

    private int lastDetectedInstanceID = 0;
    void Update() {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if(lastDetectedInstanceID != hit.transform.GetInstanceID()) {//lets not set values frame by frame
                GameInfo selectedGame = hit.transform.GetComponent<GameInfo>();
                if(selectedGame != null) {
                    gameDescription.transform.parent.gameObject.SetActive(true);
                    gameDescription.text = selectedGame.GetInfo();
                }
                lastDetectedInstanceID = hit.transform.GetInstanceID();
            }
        } else {
            gameDescription.transform.parent.gameObject.SetActive(false);
            lastDetectedInstanceID = 0;
        }
    }

    //UI connections. these functions get called from the GameObjects in the UI
    //Nintendo
    public void DrawNintendoNESLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.NES, SIDE.LEFT);
    }
    public void DrawNintendoSNESLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.SNES, SIDE.LEFT);
    }
    public void DrawNintendoGBLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GB, SIDE.LEFT);
    }
    public void DrawNintendoGBALEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GBA, SIDE.LEFT);
    }
    public void DrawNintendoN64LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N64, SIDE.LEFT);
    }
    public void DrawNintendoGAME_CUBELEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GAME_CUBE, SIDE.LEFT);
    }
    public void DrawNintendoDSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.DS, SIDE.LEFT);
    }
    public void DrawNintendo3DSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N3DS, SIDE.LEFT);
    }
    public void DrawNintendoWIILEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WII, SIDE.LEFT);
    }
    public void DrawNintendoWIIULEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WIIU, SIDE.LEFT);
    }

    //Sony
    public void DrawSonyPSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS, SIDE.LEFT);
    }
    public void DrawSonyPS2LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS2, SIDE.LEFT);
    }
    public void DrawSonyPSPLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PSP, SIDE.LEFT);
    }
    public void DrawSonyPS3LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS3, SIDE.LEFT);
    }
    public void DrawSonyPS_VITALEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS_VITA, SIDE.LEFT);
    }
    public void DrawSonyPS4LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS4, SIDE.LEFT);
    }

    //Microsoft
    public void DrawMicrosoftXBOXLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX, SIDE.LEFT);
    }
    public void DrawMicrosoftXBOX360LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX360, SIDE.LEFT);
    }
    public void DrawMicrosoftXBOXONELEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOXONE, SIDE.LEFT);
    }

    //SEGA
    public void DrawSegaGENESISLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GENESIS, SIDE.LEFT);
    }
    public void DrawSegaGAMEGEARLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GAMEGEAR, SIDE.LEFT);
    }
    public void DrawSegaCDLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_CD, SIDE.LEFT);
    }
    public void DrawSegaSATURNLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_SATURN, SIDE.LEFT);
    }
    public void DrawSegaDREAMCASTLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_DREAMCAST, SIDE.LEFT);
    }

    //PC
    public void DrawPCPCLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.PC).DrawHidePlatform(draw, PLATFORM.PC, SIDE.LEFT);
    }

    //Other
    public void DrawOtherATARI2600LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.ATARI2600, SIDE.LEFT);
    }
    public void DrawOtherNEO_GEOLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.NEO_GEO, SIDE.LEFT);
    }
    public void DrawOtherWONDER_SWANLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.WONDER_SWAN, SIDE.LEFT);
    }
    public void DrawOtherTG16LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.TG16, SIDE.LEFT);
    }
    public void DrawOtherPANASONIC3DOLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM._3DO, SIDE.LEFT);
    }
    public void DrawOtherPCFXLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.PCFX, SIDE.LEFT);
    }




    //RIGHT SIDE UI
    //Nintendo
    public void DrawNintendoNESRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.NES, SIDE.RIGHT);
    }
    public void DrawNintendoSNESRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.SNES, SIDE.RIGHT);
    }
    public void DrawNintendoGBRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GB, SIDE.RIGHT);
    }
    public void DrawNintendoGBARIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GBA, SIDE.RIGHT);
    }
    public void DrawNintendoN64RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N64, SIDE.RIGHT);
    }
    public void DrawNintendoGAME_CUBERIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GAME_CUBE, SIDE.RIGHT);
    }
    public void DrawNintendoDSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.DS, SIDE.RIGHT);
    }
    public void DrawNintendo3DSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N3DS, SIDE.RIGHT);
    }
    public void DrawNintendoWIIRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WII, SIDE.RIGHT);
    }
    public void DrawNintendoWIIURIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WIIU, SIDE.RIGHT);
    }

    //Sony
    public void DrawSonyPSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS, SIDE.RIGHT);
    }
    public void DrawSonyPS2RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS2, SIDE.RIGHT);
    }
    public void DrawSonyPSPRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PSP, SIDE.RIGHT);
    }
    public void DrawSonyPS3RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS3, SIDE.RIGHT);
    }
    public void DrawSonyPS_VITARIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS_VITA, SIDE.RIGHT);
    }
    public void DrawSonyPS4RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS4, SIDE.RIGHT);
    }

    //Microsoft
    public void DrawMicrosoftXBOXRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX, SIDE.RIGHT);
    }
    public void DrawMicrosoftXBOX360RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX360, SIDE.RIGHT);
    }
    public void DrawMicrosoftXBOXONERIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOXONE, SIDE.RIGHT);
    }

    //SEGA
    public void DrawSegaGENESISRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GENESIS, SIDE.RIGHT);
    }
    public void DrawSegaGAMEGEARRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GAMEGEAR, SIDE.RIGHT);
    }
    public void DrawSegaCDRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_CD, SIDE.RIGHT);
    }
    public void DrawSegaSATURNRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_SATURN, SIDE.RIGHT);
    }
    public void DrawSegaDREAMCASTRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_DREAMCAST, SIDE.RIGHT);
    }

    //PC
    public void DrawPCPCRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.PC).DrawHidePlatform(draw, PLATFORM.PC, SIDE.RIGHT);
    }

    //Other
    public void DrawOtherATARI2600RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.ATARI2600, SIDE.RIGHT);
    }
    public void DrawOtherNEO_GEORIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.NEO_GEO, SIDE.RIGHT);
    }
    public void DrawOtherWONDER_SWANRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.WONDER_SWAN, SIDE.RIGHT);
    }
    public void DrawOtherTG16RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.TG16, SIDE.RIGHT);
    }
    public void DrawOtherPANASONIC3DORIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM._3DO, SIDE.RIGHT);
    }
    public void DrawOtherPCFXRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.PCFX, SIDE.RIGHT);
    }
}