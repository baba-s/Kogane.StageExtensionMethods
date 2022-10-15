using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kogane
{
    public static class StageHandleExtensionMethods
    {
        public static bool IsMainStage( this StageHandle self )
        {
            var type         = typeof( StageHandle );
            var propertyInfo = type.GetProperty( "isMainStage", BindingFlags.Instance | BindingFlags.NonPublic );

            return ( bool )propertyInfo.GetValue( self );
        }

        public static Scene CustomScene( this StageHandle self )
        {
            var type         = typeof( StageHandle );
            var propertyInfo = type.GetProperty( "customScene", BindingFlags.Instance | BindingFlags.NonPublic );

            return ( Scene )propertyInfo.GetValue( self );
        }

        public static Component FindComponentOfType( this StageHandle self, Type type )
        {
            if ( !self.IsValid() ) throw new Exception( "Stage is not valid." );

            var objectsOfTypeAll = Resources
                    .FindObjectsOfTypeAll( type )
                    .OfType<Component>()
                    .ToArray()
                ;

            return self.IsMainStage()
                    ? objectsOfTypeAll.FirstOrDefault( x => !EditorUtility.IsPersistent( x ) && !EditorSceneManager.IsPreviewScene( x.gameObject.scene ) )
                    : objectsOfTypeAll.FirstOrDefault( x => x.gameObject.scene == self.CustomScene() )
                ;
        }


        public static Component[] FindComponentsOfType( this StageHandle self, Type type )
        {
            if ( !self.IsValid() ) throw new Exception( "Stage is not valid." );

            var objectsOfTypeAll = Resources
                    .FindObjectsOfTypeAll( type )
                    .OfType<Component>()
                    .ToArray()
                ;

            return self.IsMainStage()
                    ? objectsOfTypeAll.Where( x => !EditorUtility.IsPersistent( x ) && !EditorSceneManager.IsPreviewScene( x.gameObject.scene ) ).ToArray()
                    : objectsOfTypeAll.Where( x => x.gameObject.scene == self.CustomScene() ).ToArray()
                ;
        }
    }
}