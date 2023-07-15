using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzuriCore;

namespace AzuriCore.Logging
{
    public class AzuriLog : MonoBehaviour
    {
        public void InfoLog(string currentscript, string message)
        {
            Debug.Log(currentscript + ": " + message);
        }
        public void WarningLog(string currentscript, string message)
        {
            Debug.LogWarning(currentscript + ": " + message);
        }
        public void ErrorLog(string currentscript, string message)
        {
            Debug.LogError(currentscript + ": " + message);
        }
    }
}