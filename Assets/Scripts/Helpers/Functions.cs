using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine;
using YagizAYER.Helper.MetaClasses;
using System;

namespace YagizAYER
{
    namespace Helper
    {
        public class Functions : MonoBehaviour
        {
            /// <summary>
            /// Open a new tab at default browser with given url
            /// </summary>
            /// <param name="urlName">Desired web site</param>
            public void LoadURL(string urlName)
            {
                Application.OpenURL(urlName);
            }
            /// <summary>
            /// Open desired scene
            /// </summary>
            /// <param name="sceneName">Desired scene name</param>
            public void LoadScene(string sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
            /// <summary>
            /// RefreshCurrentScene
            /// </summary>
            public void RefreshScene()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            /// <summary>
            /// Returns non-repetative random list from given object pool
            /// </summary>
            /// <param name="objectPool">The object list which contains all possible objects</param>
            /// <param name="desiredListCount">Length of list to be return.</param>
            /// <typeparam name="T">Any type which can be instantiated.</typeparam>
            /// <returns>List with given generic type</returns>
            public List<T> GetUniqueRandomList<T>(List<T> objectPool, int desiredListCount)
            {
                List<int> excludedIndexes = new List<int>();
                List<T> result = new List<T>();
                System.Random r = new System.Random();
                int retryCount = 0;
                while (true)
                {
                    if (retryCount < 500) retryCount++;
                    else
                    {
                        Debug.LogWarning("Size error");
                        return new List<T>();
                    }
                    if (result.Count == desiredListCount) return result;

                    int randomIndex = r.Next(0, objectPool.Count);
                    if (excludedIndexes.Contains(randomIndex)) continue;

                    result.Add(objectPool[randomIndex]);
                    excludedIndexes.Add(randomIndex);
                }
            }
            /// <summary>
            /// Returns non-repetative random list from given int object pool
            /// </summary>
            /// <param name="size">Length of list to be return.</param>
            /// <returns>List with given int type</returns>
            public List<int> GetUniqueRandomIntList(int size)
            {
                List<int> result = new List<int>();
                for (int i = 0; i < size; i++)
                    result.Add(i);
                return GetUniqueRandomList<int>(result, size);
            }
            /// <summary>
            /// Shakes Given object for given duration and magnitude
            /// </summary>
            /// <param name="targetObject">Object to Shake</param>
            /// <param name="duration">Shake duration</param>
            /// <param name="magnitude">Shake magnitude</param>
            public void Shake(Transform targetObject, float duration = .1f, float magnitude = 5)
            {
                StartCoroutine(ShakingCamera(targetObject, duration, magnitude));
            }

            private IEnumerator ShakingCamera(Transform targetObject, float duration = .1f, float magnitude = 5)
            {

                Vector3 startPos = targetObject.transform.position;
                float timeElapsed = 0;
                while (timeElapsed < duration)
                {
                    float x = UnityEngine.Random.Range(-1, 1) * magnitude;
                    float y = UnityEngine.Random.Range(-1, 1) * magnitude;
                    targetObject.transform.localPosition = new Vector3(x, y, startPos.z);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                targetObject.transform.position = startPos;
            }
        }
    }
}
