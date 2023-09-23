/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Peter Bjorklund. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.IO;
using System.Linq;
using EcsReplicator.Attributes.Scan;
using EcsReplicator.Serialization.Unity.Generate;
using UnityEngine;
using Piot.Clog;
using Piot.Clog.Unity;

namespace EcsReplicator.Serialization.Generator.Unity
{
	public static class Generator
	{
		public static void Generate(string absoluteAssemblyPath = "")
		{
			var scriptAssembliesPath =
				Directory.GetParent(Application.dataPath).ToString() + "/Library/ScriptAssemblies/";
			var mainDll = "Assembly-CSharp.dll";

			var completePathToAssembly = scriptAssembliesPath + mainDll;

			using var readCompiledGameScriptAssembly = Scanner.ReadAssembly(completePathToAssembly);

			var log = new Log(new UnityLogger());

			var replicateAttributes = Scanner.Scan(log, readCompiledGameScriptAssembly);
			var fileContent = EcsSerializerToCode.Generate(replicateAttributes.ToArray());

			const string targetDirectory = "Assets/EcsReplicator/_Generated/";
			if(!Directory.Exists(targetDirectory))
			{
				Directory.CreateDirectory(targetDirectory);
			}

			File.WriteAllText(targetDirectory + "Generated.cs", fileContent);
		}
	}
}