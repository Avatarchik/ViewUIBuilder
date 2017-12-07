using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Video;
using UnityEngine.UI;

namespace ViewUIBuilder.Helpers.Components.Movie
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(VideoPlayer))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(RawImage))]
    public class Movie:MonoBehaviour
    {
        #region Delegates
        public delegate void OnComplete();
        public OnComplete onComplete;
        #endregion

        public bool loop = false;
        public bool useSound = false;

        private VideoPlayer media;
        //private DisplayUGUI ugui;
        private string pathUrl;
        private bool pathValid;
        private bool dispatched;
        private float time;

        void Awake()
        {
            media = GetComponent<VideoPlayer>();
            media.isLooping = loop;
            media.playOnAwake = false;
            media.aspectRatio = VideoAspectRatio.NoScaling;
            media.targetTexture = new RenderTexture(1920, 1080, 24);
            GetComponent<RawImage>().texture = media.targetTexture;
        }

        protected void Initialize()
        {
            if (!pathValid)
                path = pathUrl;
        }

        protected void OnUpdate()
        {
            
        }

        public string path 
        {
            set
            {
                pathUrl = value;

                pathValid = true;

                string moviePath = Application.dataPath + "../" + value;

                media.Stop();
                media.url = moviePath;
                if (useSound)
                {
                    media.controlledAudioTrackCount = 1;
                    media.audioOutputMode = VideoAudioOutputMode.AudioSource;
                    media.EnableAudioTrack(0, true);
                    media.SetTargetAudioSource(0, GetComponent<AudioSource>());
                }
                media.loopPointReached += onCompleteVideo;
                media.Play();

                dispatched = false;
                time = Time.time;
            }
        }

        public void onCompleteVideo(VideoPlayer player)
        {
            if (onComplete != null)
                onComplete();
        }

        public double GetVideoCurrentTime()
        {
            return media.time;
        }

        void OnEnable()
        {
            if (gameObject.activeInHierarchy)
                StartCoroutine(EnableVideo(true));
        }

        void OnDisable()
        {
            ToogleVideo(false);
        }

        private IEnumerator EnableVideo(bool enable)
        {
            yield return media;

            ToogleVideo(enable);
        }

        private void ToogleVideo(bool enable)
        {
            try
            {
                if (media != null)
                {
                    if (enable)
                    {
                        media.Play();

                        time = Time.time;

                        dispatched = false;
                    }
                    else
                    {
                        //media.Rewind(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex.StackTrace.ToString());
            }
        }
    }
}
