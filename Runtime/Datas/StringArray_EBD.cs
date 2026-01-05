using System;
using UnityEngine;

namespace qb.EnvironmentBuild
{
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