using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AzuriCore.Version
{
    public class AzuriVersion : Versioninfo
    {
        public void LogVersion()
        {
            Debug.Log("AzuriCore Version: " + version + " " + versionName);
        }
    }
}