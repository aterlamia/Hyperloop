using System;

namespace ld47
{
    [Flags]
    public enum Statetype
    {
        NONE = 0,
        //level1
        PHONE_DONE = 1,  //DONE
        DOOR_OPENED = 2, //DONE
        //level2
        CORRECT_NPC_TALKED_TO = 4,
        SLEEP_TALK = 8,
        //level3
        SPEAKER_FIRED = 16,
        HIDDEN = 32,
        //level4
        HAS_CARD= 64,
        PHONE2_DONE=128,
        //level 5
        HAS_TOOL= 256,
        PANEL_OPENED = 512,
        // END ?
        BOMB_DEFUSED = 1024,
        DOOR3 = 2048,
    }
}