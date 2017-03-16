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

    private GameObject platformHandleLeft;
    private GameObject platformHandleRight;

    //callbacks for buttons
    //private float platformHandlesMovementSpeed = 10;
    private float amount = 0.5f;
    public void MoveForwardLEFT() {
//        platformHandleLeft.transform.position -= new Vector3(0, 0, platformHandlesMovementSpeed*Time.deltaTime);
        if(platformHandleLeft)
            platformHandleLeft.transform.localPosition -= new Vector3(0, 0, amount);
    }
    public void MoveBackwardLEFT() {
//        platformHandleLeft.transform.position += new Vector3(0, 0, platformHandlesMovementSpeed*Time.deltaTime);
        if(platformHandleLeft)
            platformHandleLeft.transform.localPosition += new Vector3(0, 0, amount);
    }
    public void MoveForwardRIGHT() {
        if(platformHandleRight)
            platformHandleRight.transform.localPosition -= new Vector3(0, 0, amount);
    }
    public void MoveBackwardRIGHT() {
        if(platformHandleRight)
            platformHandleRight.transform.localPosition += new Vector3(0, 0, amount);
    }
    //**********************//

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
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.NES);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for nes not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoSNESLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.SNES, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.SNES);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for snes not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoGBLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GB, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GB);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for gb not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoGBALEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GBA, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GBA);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for gba not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoN64LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N64, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.N64);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for nes n64 found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoGAME_CUBELEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GAME_CUBE, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GAME_CUBE);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for game cube not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoDSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.DS, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.DS);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ds not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendo3DSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N3DS, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.N3DS);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for n3ds not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoWIILEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WII, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.WII);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for wii not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawNintendoWIIULEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WIIU, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.WIIU);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for wiiu not found");
        } else { platformHandleLeft = null; }
    }

    //Sony
    public void DrawSonyPSLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ps not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSonyPS2LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS2, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS2);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ps2 not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSonyPSPLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PSP, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PSP);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for psp not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSonyPS3LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS3, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS3);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ps3 not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSonyPS_VITALEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS_VITA, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS_VITA);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ps vita not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSonyPS4LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS4, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS4);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for ps4 not found");
        } else { platformHandleLeft = null; }
    }

    //Microsoft
    public void DrawMicrosoftXBOXLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOX);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for xbox not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawMicrosoftXBOX360LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX360, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOX360);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for xbox 360 not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawMicrosoftXBOXONELEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOXONE, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOXONE);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for xbox one not found");
        } else { platformHandleLeft = null; }
    }

    //SEGA
    public void DrawSegaGENESISLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GENESIS, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_GENESIS);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for sega genesis not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSegaGAMEGEARLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GAMEGEAR, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_GAMEGEAR);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for sega game gear not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSegaCDLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_CD, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_CD);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for sega CD not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSegaSATURNLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_SATURN, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_SATURN);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for sega saturn not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawSegaDREAMCASTLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_DREAMCAST, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_DREAMCAST);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for sega dreamcast not found");
        } else { platformHandleLeft = null; }
    }

    //PC
    public void DrawPCPCLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.PC).DrawHidePlatform(draw, PLATFORM.PC, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.PC).GetCachedPlatform(PLATFORM.PC);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for PC not found");
        } else { platformHandleLeft = null; }
    }

    //Other
    public void DrawOtherATARI2600LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.ATARI2600, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.ATARI2600);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for atari 2600 not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawOtherNEO_GEOLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.NEO_GEO, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.NEO_GEO);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for PC not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawOtherWONDER_SWANLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.WONDER_SWAN, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.WONDER_SWAN);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for wonder swan not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawOtherTG16LEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.TG16, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.TG16);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for TG16 not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawOtherPANASONIC3DOLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM._3DO, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM._3DO);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for Panasonic 3do not found");
        } else { platformHandleLeft = null; }
    }
    public void DrawOtherPCFXLEFT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.PCFX, SIDE.LEFT);
        if(draw) {
            platformHandleLeft = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.PCFX);
            if(platformHandleLeft == null) Debug.LogError("Platform handle left for PCFX not found");
        } else { platformHandleLeft = null; }
    }




    //RIGHT SIDE UI
    //Nintendo
    public void DrawNintendoNESRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.NES, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.NES);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for nes not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoSNESRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.SNES, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.SNES);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for snes not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoGBRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GB, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GB);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for gb not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoGBARIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GBA, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GBA);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for gba not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoN64RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N64, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.N64);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for n64 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoGAME_CUBERIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GAME_CUBE, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.GAME_CUBE);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for game cube not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoDSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.DS, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.DS);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ds not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendo3DSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N3DS, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.N3DS);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for 3ds not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoWIIRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WII, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.WII);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for wii not found");
        } else { platformHandleRight = null; }
    }
    public void DrawNintendoWIIURIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WIIU, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.NINTENDO).GetCachedPlatform(PLATFORM.WIIU);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for wiiu not found");
        } else { platformHandleRight = null; }
    }

    //Sony
    public void DrawSonyPSRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ps not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSonyPS2RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS2, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS2);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ps2 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSonyPSPRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PSP, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PSP);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for psp not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSonyPS3RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS3, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS3);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ps3 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSonyPS_VITARIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS_VITA, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS_VITA);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ps vita not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSonyPS4RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS4, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SONY).GetCachedPlatform(PLATFORM.PS4);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for ps4 not found");
        } else { platformHandleRight = null; }
    }

    //Microsoft
    public void DrawMicrosoftXBOXRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOX);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for xbox not found");
        } else { platformHandleRight = null; }
    }
    public void DrawMicrosoftXBOX360RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX360, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOX360);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for xbox 360 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawMicrosoftXBOXONERIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOXONE, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.MICROSOFT).GetCachedPlatform(PLATFORM.XBOXONE);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for xbox one not found");
        } else { platformHandleRight = null; }
    }

    //SEGA
    public void DrawSegaGENESISRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GENESIS, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_GENESIS);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for sega genesis not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSegaGAMEGEARRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GAMEGEAR, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_GAMEGEAR);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for sega gamegear not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSegaCDRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_CD, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_CD);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for sega cd not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSegaSATURNRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_SATURN, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_SATURN);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for sega saturn not found");
        } else { platformHandleRight = null; }
    }
    public void DrawSegaDREAMCASTRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_DREAMCAST, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.SEGA).GetCachedPlatform(PLATFORM.SEGA_DREAMCAST);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for sega dreamcast not found");
        } else { platformHandleRight = null; }
    }

    //PC
    public void DrawPCPCRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.PC).DrawHidePlatform(draw, PLATFORM.PC, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.PC).GetCachedPlatform(PLATFORM.PC);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for pc not found");
        } else { platformHandleRight = null; }
    }

    //Other
    public void DrawOtherATARI2600RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.ATARI2600, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.ATARI2600);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for atari2600 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawOtherNEO_GEORIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.NEO_GEO, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.NEO_GEO);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for neo geo not found");
        } else { platformHandleRight = null; }
    }
    public void DrawOtherWONDER_SWANRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.WONDER_SWAN, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.WONDER_SWAN);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for wonder swan not found");
        } else { platformHandleRight = null; }
    }
    public void DrawOtherTG16RIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.TG16, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.TG16);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for tg16 not found");
        } else { platformHandleRight = null; }
    }
    public void DrawOtherPANASONIC3DORIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM._3DO, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM._3DO);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for 3do not found");
        } else { platformHandleRight = null; }
    }
    public void DrawOtherPCFXRIGHT(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.PCFX, SIDE.RIGHT);
        if(draw) {
            platformHandleRight = dataLoader.GetConsole(CONSOLE.OTHER).GetCachedPlatform(PLATFORM.PCFX);
            if(platformHandleRight == null) Debug.LogError("Platform handle right for pcfx not found");
        } else { platformHandleRight = null; }
    }
}