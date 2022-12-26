using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode
{
    public static bool debug_mode = true;
    public struct Level {
        private string level;
        public string Name {
            get { return level; }
            set { level = value; }
        }

    }

    public struct SO
    {
        private bool Windows;
        private bool Webgl;
        private bool Android;
        public bool windows
        {
            get { return Windows; }
            set { Windows = value; }
        }
        public bool webgl
        {
            get { return Webgl; }
            set { Webgl = value; }
        }
        public bool android
        {
            get { return Android; }
            set { Android = value; }
        }
        public void GetSO()
        {
            #if UNITY_STANDALONE_WIN
                windows = true;
            #endif
            #if UNITY_WEBGL
                webgl = true;
            #endif
            #if UNITY_ANDROID
                android = true;
            #endif
        }
    }


}
