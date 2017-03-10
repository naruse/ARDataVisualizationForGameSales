using UnityEngine;

/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This is basically a class that connects the DataLoader class with the Unity UI
 */

[RequireComponent(typeof(DataLoader))]
public class GUIConnector : MonoBehaviour {

    private DataLoader dataLoader;

    void Start() {
        dataLoader = GetComponent<DataLoader>();
        if(dataLoader == null)
            Debug.LogError("Cant connect DataLoader to UI");
    }

    //UI connections. these functions get called from the GameObjects in the UI
    //Nintendo
    public void DrawNintendoNES(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.NES);
    }
    public void DrawNintendoSNES(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.SNES);
    }
    public void DrawNintendoGB(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GB);
    }
    public void DrawNintendoGBA(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GBA);
    }
    public void DrawNintendoN64(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N64);
    }
    public void DrawNintendoGAME_CUBE(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.GAME_CUBE);
    }
    public void DrawNintendoDS(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.DS);
    }
    public void DrawNintendo3DS(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.N3DS);
    }
    public void DrawNintendoWII(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WII);
    }
    public void DrawNintendoWIIU(bool draw) {
        dataLoader.GetConsole(CONSOLE.NINTENDO).DrawHidePlatform(draw, PLATFORM.WIIU);
    }

    //Sony
    public void DrawSonyPS(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS);
    }
    public void DrawSonyPS2(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS2);
    }
    public void DrawSonyPSP(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PSP);
    }
    public void DrawSonyPS3(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS3);
    }
    public void DrawSonyPS_VITA(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS_VITA);
    }
    public void DrawSonyPS4(bool draw) {
        dataLoader.GetConsole(CONSOLE.SONY).DrawHidePlatform(draw, PLATFORM.PS4);
    }

    //Microsoft
    public void DrawMicrosoftXBOX(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX);
    }
    public void DrawMicrosoftXBOX360(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOX360);
    }
    public void DrawMicrosoftXBOXONE(bool draw) {
        dataLoader.GetConsole(CONSOLE.MICROSOFT).DrawHidePlatform(draw, PLATFORM.XBOXONE);
    }

    //SEGA
    public void DrawSegaGENESIS(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GENESIS);
    }
    public void DrawSegaGAMEGEAR(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_GAMEGEAR);
    }
    public void DrawSegaCD(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_CD);
    }
    public void DrawSegaSATURN(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_SATURN);
    }
    public void DrawSegaDREAMCAST(bool draw) {
        dataLoader.GetConsole(CONSOLE.SEGA).DrawHidePlatform(draw, PLATFORM.SEGA_DREAMCAST);
    }

    //PC
    public void DrawPCPC(bool draw) {
        dataLoader.GetConsole(CONSOLE.PC).DrawHidePlatform(draw, PLATFORM.PC);
    }

    //Other
    public void DrawOtherATARI2600(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.ATARI2600);
    }
    public void DrawOtherNEO_GEO(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.NEO_GEO);
    }
    public void DrawOtherWONDER_SWAN(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.WONDER_SWAN);
    }
    public void DrawOtherTG16(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.TG16);
    }
    public void DrawOtherPANASONIC3DO(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM._3DO);
    }
    public void DrawOtherPCFX(bool draw) {
        dataLoader.GetConsole(CONSOLE.OTHER).DrawHidePlatform(draw, PLATFORM.PCFX);
    }
}