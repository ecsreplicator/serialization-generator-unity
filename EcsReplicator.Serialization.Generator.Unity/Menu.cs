/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Peter Bjorklund. All rights reserved. https://github.com/ecsreplicator
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

﻿using UnityEditor;

namespace EcsReplicator.Serialization.Generator.Unity
{
    public static class Menu
    {
        [MenuItem("Ecs Replicator/Generate")]
        private static void GenerateCode()
        {
            Generator.Generate();
        }
    }
}