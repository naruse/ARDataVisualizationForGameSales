/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved
 */

public enum SIDE {
    LEFT = 0,
    RIGHT = 1
}

public enum CONSOLE {
    NINTENDO = 0,
    SONY = 1,
    MICROSOFT = 2,
    SEGA = 3,
    PC = 4,
    OTHER = 5
}

public enum GENRE {
    SPORTS = 0,
    PLATFORM = 1,
    RACING = 2,
    ROLE_PLAYING = 3,
    PUZZLE = 4,
    SHOOTER = 5,
    SIMULATION = 6,
    ACTION = 7,
    FIGHTING = 8,
    ADVENTURE = 9,
    STRATEGY = 10,
    MISC = 11,
    UNKNOWN = -1
}

public enum PLATFORM {
    //nintendo
    NES = 0,
    SNES = 1,
    GB = 2,
    GBA = 3,
    DS = 4,
    N3DS = 5,
    N64 = 6,
    GAME_CUBE = 7,//game cube
    WII = 8,
    WIIU = 9,

    //Sony
    PS = 10,
    PS2 = 11,
    PS3 = 12,
    PS4 = 13,
    PSP = 14,
    PS_VITA = 15,//ps vita

    //Microsoft
    XBOX = 16,
    XBOX360 = 17,
    XBOXONE = 18,

    //SEGA
    SEGA_SATURN = 19,//sega saturn
    SEGA_CD = 20,//sega CD
    SEGA_GENESIS = 21,//genesis
    SEGA_DREAMCAST = 22,//dreamcast
    SEGA_GAMEGEAR = 23,

    //PC
    PC = 24,

    //other
    ATARI2600 = 25,
    WONDER_SWAN = 26,//wonder swan
    NEO_GEO = 27,
    TG16 = 28,//turbo grafx 16
    _3DO = 29,//3DO
    PCFX = 30,//PCFX

    UNKNOWN = -1
}

public enum RATING {
    E = 0,//Everyone, same as K-A
    M = 1,//Mature 17+ years
    T = 2,//Teen, 13+ years
    E10PLUS = 3,//E10+ Everyone, 10+ years
    AO = 4,//Adults only
    EC = 5,//Early childhood
    RP = 6,//Rating pending
    UNKNOWN = -1// GAMES PRE-1994 when the ESRB started
}