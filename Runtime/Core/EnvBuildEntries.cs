using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace qb.EnvironmentBuild
{
    [System.Serializable]
    public class EnvBuildEntries<T>
    {
        [SerializeField, Required, InlineEditor]
        BuildInfo buildInfo;
        public BuildInfo BuildInfo => buildInfo;

#if UNITY_EDITOR
        [OnValueChanged(nameof(UpdateUrlInfoFromEnvValidation))]
        [InfoBox("$" + nameof(UrlInfoMessage), TriMessageType.Error, visibleIf: nameof(ShowUrlInfoMessageBox))]
#endif
        [SerializeField]
        List<Entry<T>> values = new List<Entry<T>>();

        public T Value => values[(int)buildInfo.Environment].Value;

        #region inspector validation
#if UNITY_EDITOR
        private void UpdateUrlInfoFromEnvValidation()
        {
            int envTypeCount = Enum.GetNames(typeof(BuildInfo.EnvironmentType)).Length;
            int index = 0;
            List<Entry<T>> sizeConstraintedList = new List<Entry<T>>();
            foreach (var entry in values)
            {
                entry.BuildEnvironment = (BuildInfo.EnvironmentType)index;
                sizeConstraintedList.Add(entry);
                index++;
                if (index == envTypeCount)
                    break;
            }
            values = sizeConstraintedList;
        }
        bool ShowUrlInfoMessageBox => values.Count != Enum.GetNames(typeof(BuildInfo.EnvironmentType)).Length;
        string UrlInfoMessage => $"You must add {Enum.GetNames(typeof(BuildInfo.EnvironmentType)).Length - values.Count} more element(s) in the folowing list!";
#endif
        #endregion

        #region internal class
        [Serializable]
        public class Entry<TT>
        {
            [SerializeField, ReadOnly]
            BuildInfo.EnvironmentType buildEnvironment = BuildInfo.EnvironmentType.Development;
            public BuildInfo.EnvironmentType BuildEnvironment
            {
                get => buildEnvironment;
#if UNITY_EDITOR
                set
                {
                    if (Application.isPlaying)
                        throw new Exception("This parameter cannot be set at runtime!");
                    buildEnvironment = value;
                }
#endif
            }

            [SerializeField]
            private TT value;
            public TT Value => value;
        }
        #endregion
    }
}
