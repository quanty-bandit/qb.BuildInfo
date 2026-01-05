using UnityEngine;
namespace qb.EnvironmentBuild
{
    /// <summary>
    /// Provides a base class for storing environment-specific build data as a Unity ScriptableObject.
    /// </summary>
    /// <remarks>This class is intended to be inherited to define strongly-typed build data for different
    /// environments, such as development, staging, or production. The data is typically configured in the Unity Editor
    /// and used at runtime to access environment-specific settings or resources.</remarks>
    /// <typeparam name="T">The type of the value associated with the environment build data.</typeparam>
    public abstract class EnvBuildData<T> : ScriptableObject
    {
        [SerializeField]
        EnvBuildEntries<T> entries;
        public BuildInfo BuildInfo => entries?.BuildInfo;
        public BuildInfo.EnvironmentType Environment => BuildInfo.Environment;
        public T Value => entries.Value;
    }
}
