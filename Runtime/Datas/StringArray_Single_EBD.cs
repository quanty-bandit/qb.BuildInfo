using System;
using UnityEngine;

namespace qb.EnvironmentBuild
{
    [CreateAssetMenu(menuName = "qb/Environement Build/Data/StringArray_Single_EBD", fileName = "StringArray_Single_EBD")]
    public class StringArray_Single_EBD: SingleEnvBuildData<string[]>
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