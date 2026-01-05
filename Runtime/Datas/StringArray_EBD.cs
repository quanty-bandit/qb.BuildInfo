using System;
using UnityEngine;

namespace qb.EnvironmentBuild
{
    /// <summary>
    /// Represents an environment build data that stores a string aray values.
    /// </summary>
    /// <remarks>
    /// Use this class to define and manage string-based configuration or metadata within the
    /// environment build system. This type must be created as a Unity asset in editor workflows but not at runtime!
    /// </remarks>
    [CreateAssetMenu(menuName = "qb/Environement Build/Data/StringArray_EBD", fileName = "StringArray_EBD")]
    public class StringArray_EBD: EnvBuildData<string[]>
    {
        public string GetValue(IConvertible index) 
        {
            return GetValue((int)index);
        }
        public string GetValue(int index = 0)
        {
            var values = Value;
            if (index < 0 || values == null || index>=values.Length)
            {
                return null;
            }
            return values[index];
        }
    }
}