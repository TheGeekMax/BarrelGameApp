public static class LocalState{
    //pour 30 sec , 60 sec et 120 sec
    private static int[] score;
    
    //pour mode normal
    private static int normalScore;
    private static int normalLevel;

    //les options
    private static int soundValue;
    private static int touchValue;

    //music et touchtype sont dans stock.cs
    //options pour savoir ou en est le jeu
    private static int type;
    //type -> 0 - normal ; 1 - 30s; 2 - 60s ; 3 - 120s;

    public static int[] Score{
        get 
        {
            return score;
        }
        set 
        {
            score = value;
        }
    }

    public static int NormalScore{
        get 
        {
            return normalScore;
        }
        set 
        {
            normalScore = value;
        }
    }

    public static int NormalLevel{
        get 
        {
            return normalLevel;
        }
        set 
        {
            normalLevel = value;
        }
    }

    public static int Type{
        get 
        {
            return type;
        }
        set 
        {
            type = value;
        }
    }
}
