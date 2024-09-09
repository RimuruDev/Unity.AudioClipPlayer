#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace RimuruDev.Editor
{
    [HelpURL("https://github.com/RimuruDev/Unity.AudioClipPlayer")]
    public sealed class AudioClipPlayerWindow : EditorWindow
    {
        private const string FindFilter = "t:AudioClip";

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // NOTE: Don't add readonly!!!
        private List<AudioClip> audioClips = new();

        private bool loopAudio;
        private Vector2 scrollPos;
        private AudioSource audioSource;

        [MenuItem("RimuruDev Tools/Audio Clip Player")]
        public static void ShowWindow() =>
            GetWindow(typeof(AudioClipPlayerWindow), false, "Audio Clip Player");

        private void OnGUI()
        {
            GUILayout.Label("Audio Clip Player", EditorStyles.boldLabel);

            if (GUILayout.Button("Select Folder and Load Audio Clips"))
                LoadAudioClipsFromFolder();

            if (audioClips.Count > 0)
            {
                loopAudio = EditorGUILayout.Toggle("Loop", loopAudio);

                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

                for (var i = 0; i < audioClips.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    audioClips[i] = (AudioClip)EditorGUILayout.ObjectField(audioClips[i], typeof(AudioClip), false);

                    if (GUILayout.Button("Play", GUILayout.Width(50)))
                        PlayClip(audioClips[i]);

                    if (GUILayout.Button("Remove", GUILayout.Width(70)))
                    {
                        audioClips.RemoveAt(i);
                        break;
                    }

                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndScrollView();

                if (GUILayout.Button("Clear All"))
                {
                    audioClips.Clear();
                    StopClip();
                }

                if (GUILayout.Button("Stop All"))
                {
                    StopClip();
                }
            }
            else
            {
                GUILayout.Label("No Audio Clips added", EditorStyles.helpBox);
            }
        }

        private void LoadAudioClipsFromFolder()
        {
            var folderPath = EditorUtility.OpenFolderPanel("Select Folder with Audio Clips", "Assets", "");
            var relativePath = "Assets" + folderPath.Replace(Application.dataPath, "").Replace("\\", "/");

            if (!string.IsNullOrEmpty(folderPath))
            {
                var guids = AssetDatabase.FindAssets(FindFilter, new[] { relativePath });

                audioClips.Clear();
                foreach (string guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var clip = AssetDatabase.LoadAssetAtPath<AudioClip>(path);

                    if (clip != null)
                        audioClips.Add(clip);
                }

                if (audioClips.Count == 0)
                {
                    Debug.LogWarning("No audio clips found in the selected folder.");
                }
            }
        }

        private void PlayClip(AudioClip clip)
        {
            if (audioSource == null)
            {
                GameObject audioSourceGameObject = new GameObject("EditorAudioSource");
                audioSource = audioSourceGameObject.AddComponent<AudioSource>();
                audioSource.hideFlags = HideFlags.HideAndDontSave;
            }

            audioSource.clip = clip;
            audioSource.loop = loopAudio;
            audioSource.Play();
        }

        private void StopClip()
        {
            if (audioSource != null && audioSource.isPlaying)
                audioSource.Stop();
        }

        private void OnDisable()
        {
            if (audioSource != null)
                DestroyImmediate(audioSource.gameObject);
        }
    }
}
#endif
