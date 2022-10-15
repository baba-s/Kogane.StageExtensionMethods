using System;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Kogane
{
    public static class StageExtensionMethods
    {
        public static Component FindComponentOfType( this Stage self, Type type )
        {
            return self.stageHandle.FindComponentOfType( type );
        }

        public static Component[] FindComponentsOfType( this Stage self, Type type )
        {
            return self.stageHandle.FindComponentsOfType( type );
        }
    }
}