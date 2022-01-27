
using System.Diagnostics;

public static class Logger
{

    [Conditional("ENABLE_LOGS")]

    public static void Debug(string logMsg)
    {

        UnityEngine.Debug.Log(logMsg);

    }

    public static void Debug(string logMsg, object obj)
    {

        UnityEngine.Debug.Log(logMsg + obj.GetType() + " " + obj.ToString());

    }

}

