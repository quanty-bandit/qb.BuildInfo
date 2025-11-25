using UnityEngine;
namespace qb.EnvironmentBuild
{
    public abstract class EnvBuildData<T> : ScriptableObject
    {
        [SerializeField]
        EnvBuildEntries<T> entries;
        public BuildInfo BuildInfo => entries?.BuildInfo;
        public BuildInfo.EnvironmentType Environment => BuildInfo.Environment;
        public T Value => entries.Value;
    }
}
