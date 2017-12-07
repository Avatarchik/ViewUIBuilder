using System;
using System.IO;
using UnityEngine;

namespace ViewUIBuilder.Helpers.Components.Log
{
    class Log : MonoBehaviour
    {
        #region Singleton
        static private Log instance;
        static public Log Instance { get { return instance; } }

        void Awake()
        {
            instance = this;
        }
        #endregion

        #region Initialize
        static private GameObject go;
        static public void Initialize(GameObject gameObject)
        {
            go = gameObject;

            go.AddComponent<Log>();

            instance.Init();
        }
        #endregion
        
        private bool debug;
        private string filename = "log.txt";

        public void Init()
        {
            debug = true;
            if (!debug)
            {
                return;
            }

            if (!Directory.Exists("Debug\\"))
            {
                Directory.CreateDirectory("Debug");
            }

            filename = "Debug\\" + filename.Replace(".", "_" + (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + ".");

            if (File.Exists(filename))
            {
                Debug.Log(filename + " already exists.");
            }
            else
            {
                var sr = File.CreateText(filename);
                sr.Close();
            }

            File.AppendAllText(filename, "Projeto iniciado. ");
            File.AppendAllText(filename, System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public void Error(string msg)
        {
            WriteMsg("0", msg);
        }

        public void Info(string msg)
        {
            WriteMsg("0", msg);
        }

        public void InfoWithDate(string msg)
        {
            WriteMsg("0", msg + " - " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        private void WriteMsg(string type, string msg)
        {
            if (!debug)
            {
                return;
            }
            File.AppendAllText(filename, "\n");
            File.AppendAllText(filename, msg);
        }
    }
}
