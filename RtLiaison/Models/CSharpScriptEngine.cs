using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace RtLiaison.Models
{
    class CSharpScriptEngine
    {
        private ScriptEngine _engine;
        private Session _session;

        public CSharpScriptEngine()
        {
            _engine = new ScriptEngine(
                references: new[]{
                    typeof(object).Assembly.Location,
                    typeof(Enumerable).Assembly.Location
                },
                importedNamespaces: new[]{
                    "System",
                    "System.Collections.Generic",
                    "System.Linq"
                });
            _session = Session.Create();
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

                var ret = _engine.Execute(command, _session);

                text += sw.ToString();
                sw.Dispose();

                if (ret != null)
                {
                    text += ret.ToString();
                    text+= "\n";
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
