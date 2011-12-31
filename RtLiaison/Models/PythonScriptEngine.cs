using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace RtLiaison.Models
{
    class PythonScriptEngine
    {
        private ScriptEngine _engine;
        private ScriptScope _scope;

        public PythonScriptEngine()
        {
            _engine = Python.CreateEngine();


        }

        public string Execute(string command)
        {
            string text = "";
            text += "> " + command;
            text += "\n";

            try
            {
                var sw = new StringWriter();
                Console.SetOut(sw);

                var ret = _engine.Execute(command, _scope);

                text += sw.ToString();
                sw.Dispose();

                if (ret != null)
                {
                    text += ret.ToString();
                    text += "\n";
                }
            }
            catch (Exception ex)
            {
                text += ex.Message;
                text += "\n";
            }

            return text;
        }
    }
}
