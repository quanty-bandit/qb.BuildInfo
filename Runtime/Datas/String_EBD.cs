using UnityEngine;
namespace qb.EnvironmentBuild
{
    /// <summary>
    /// Represents an environment build data that stores a string value.
    /// </summary>
    /// <remarks>
    /// Use this class to define and manage string-based configuration or metadata within the
    /// environment build system. This type must be created as a Unity asset in editor workflows but not at runtime!
    /// </remarks>
    [CreateAssetMenu(fileName = "String_EBD", menuName = "qb/Environement Build/Data/String_EBD")]
    public class String_EBD : EnvBuildData<string>
    {

    }
}
