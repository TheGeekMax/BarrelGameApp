public static class Stats{
    private static int level, time,touchtype,music;
    private static bool timer,sound;

    public static int Level{
        get 
        {
            return level;
        }
        set 
        {
            level = value;
        }
    }

    public static int Time{
        get 
        {
            return time;
        }
        set 
        {
            time = value;
        }
    }

    public static int Touchtype{
        get 
        {
            return touchtype;
        }
        set 
        {
            touchtype = value;
        }
    }

    public static bool Timer{
        get 
        {
            return timer;
        }
        set 
        {
            timer = value;
        }
    }

    public static bool Sound{
        get 
        {
            return sound;
        }
        set 
        {
            sound = value;
        }
    }

    public static int Music{
        get 
        {
            return music;
        }
        set 
        {
            music = value;
        }
    }
}
