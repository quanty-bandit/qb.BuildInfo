using System.Collections;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
namespace qb.EnvironmentBuild
{
    public class DisableFromBuildInfo : MonoBehaviour
    {
        [SerializeField,Required]
        BuildInfo buildInfo;
        [SerializeField]
        BuildInfo.EnvironmentType disableEnvironmentType = BuildInfo.EnvironmentType.Production;

        private void Awake()
        {
            if(buildInfo == null || buildInfo.Environment == disableEnvironmentType) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}
