using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tasker.Tests
{
    public static class TestHelpers
    {
        private static Program _program = new Program();
        private static readonly string _projectName = "Tasker";

        public static Assembly[] GetSolutionAssemblies()
        {
            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(filePath => AssemblyName.GetAssemblyName(filePath))
                .Where(assemblyName => assemblyName.Name != null && assemblyName.Name.StartsWith(_projectName))
                .Select(Assembly.Load);
            return assemblies.ToArray();
        }
        
        public static Type GetClassType(string fullName)
        {
            // return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
            //         where assembly.FullName != null && assembly.FullName.StartsWith(_projectName)
            //         from type in assembly.GetTypes()
            //         where type.FullName == fullName
            //         select type).FirstOrDefault();
            var assemblies = GetSolutionAssemblies();
            var projectTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).ToList();
            var foundType = projectTypes?.FirstOrDefault(type => type.FullName == fullName);
            return foundType;
        }

        public static string GetRootString()
        {
            return ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar;
        }
    }
}
