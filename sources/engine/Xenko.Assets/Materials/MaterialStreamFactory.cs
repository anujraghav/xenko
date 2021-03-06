// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using Xenko.Core.Extensions;
using Xenko.Rendering.Materials;

namespace Xenko.Assets.Materials
{
    /// <summary>
    /// <see cref="MaterialStreamDescriptor"/> factory.
    /// </summary>
    public static class MaterialStreamFactory
    {
        /// <summary>
        /// Gets the available streams.
        /// </summary>
        /// <returns>List&lt;MaterialStreamDescriptor&gt;.</returns>
        public static List<MaterialStreamDescriptor> GetAvailableStreams()
        {
            var streams = new List<MaterialStreamDescriptor>();
            foreach (var type in typeof(IMaterialStreamProvider).GetInheritedInstantiableTypes())
            {
                if (type.GetConstructor(Type.EmptyTypes) != null)
                {
                    var provider = (IMaterialStreamProvider)Activator.CreateInstance(type);
                    streams.AddRange(provider.GetStreams());
                }
            }
            return streams;
        }
    }
}
