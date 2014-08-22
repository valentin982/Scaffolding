﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using Microsoft.Framework.CodeGeneration;
using Microsoft.Framework.Runtime;

namespace Microsoft.Framework.CodeGenerators.Mvc
{
    public class StaticFilesDependencyInstaller : DependencyInstaller
    {
        public StaticFilesDependencyInstaller([NotNull]ILibraryManager libraryManager)
            : base(libraryManager)
        {
        }

        public override void Install(IApplicationEnvironment application)
        {
            CopyFolderContentsRecursive(application.ApplicationBasePath, TemplateFolders.First());
        }

        public override IEnumerable<Dependency> Dependencies
        {
            get
            {
                return new List<Dependency>()
                {
                    StandardDependencies.StaticFilesDependency
                };
            }
        }

        public override string TemplateFoldersName
        {
            get
            {
                return "StaticFiles";
            }
        }
    }
}