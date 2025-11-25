
using qb.Pattern;
using UnityEngine;
namespace qb.EnvironmentBuild
{
    public abstract class SingleEnvBuildData<T> : SOSingleton<SingleEnvBuildData<T>>
    {
        [SerializeField]
        EnvBuildEntries<T> entries;
        public BuildInfo BuildInfo => entries?.BuildInfo;
        public BuildInfo.EnvironmentType Environment => BuildInfo.Environment;
        public T Value => entries.Value;
    }

}