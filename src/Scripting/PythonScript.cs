using System;
using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Scripting
{
    public class PythonScript
    {
        private ScriptEngine pythonEngine;
        private ScriptScope pythonScope;
        private Dictionary<string, dynamic> pythonFunctions;

        public PythonScript()
        {
            pythonEngine = Python.CreateEngine();
            pythonScope = pythonEngine.CreateScope();
            pythonFunctions = new Dictionary<string, dynamic>();
        }

        public void LoadScript(string scriptPath)
        {
            pythonEngine.ExecuteFile(scriptPath, pythonScope);
            CachePythonFunctions();
        }

        private void CachePythonFunctions()
        {
            foreach (var variable in pythonScope.GetVariableNames())
            {
                var pythonFunction = pythonScope.GetVariable(variable);
                if (pythonFunction is IronPython.Runtime.Types.PythonFunction)
                {
                    pythonFunctions[variable] = pythonFunction;
                }
            }
        }

        public void CallFunction(string functionName, params object[] args)
        {
            if (pythonFunctions.TryGetValue(functionName, out var pythonFunction))
            {
                pythonFunction(args);
            }
            else
            {
                throw new Exception($"Python function '{functionName}' not found.");
            }
        }

        public void SetGlobal(string name, object value)
        {
            pythonScope.SetVariable(name, value);
        }

        public object GetGlobal(string name)
        {
            return pythonScope.GetVariable(name);
        }
    }
}
