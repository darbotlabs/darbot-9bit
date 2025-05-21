using System;
using System.Collections.Generic;
using NLua;

namespace Scripting
{
    public class LuaScript
    {
        private Lua luaState;
        private Dictionary<string, LuaFunction> luaFunctions;

        public LuaScript()
        {
            luaState = new Lua();
            luaFunctions = new Dictionary<string, LuaFunction>();
        }

        public void LoadScript(string scriptPath)
        {
            luaState.DoFile(scriptPath);
            CacheLuaFunctions();
        }

        private void CacheLuaFunctions()
        {
            foreach (var functionName in luaState.GetFunctionNames())
            {
                luaFunctions[functionName] = luaState.GetFunction(functionName);
            }
        }

        public void CallFunction(string functionName, params object[] args)
        {
            if (luaFunctions.TryGetValue(functionName, out var luaFunction))
            {
                luaFunction.Call(args);
            }
            else
            {
                throw new Exception($"Lua function '{functionName}' not found.");
            }
        }

        public void SetGlobal(string name, object value)
        {
            luaState[name] = value;
        }

        public object GetGlobal(string name)
        {
            return luaState[name];
        }
    }
}
