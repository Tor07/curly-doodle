using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task3
{
    class Program
    {
        class Value
        {
            public int id;
            public string value;
        }

        class Test
        {
            public int id;
            public string title;
            public string value;
            public Test[] values;
        }

        static void SetTestsValues(Test[] values, Dictionary<int, string> map)
        {
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    try
                    {
                        values[i].value = map[values[i].id];
                    }
                    catch { }

                    SetTestsValues(values[i].values, map);
                }
            }
        }

        static void Main(string[] args)
        {
            JObject valuesJObject = JObject.Load(new JsonTextReader(new StringReader(System.IO.File.ReadAllText(args[1]))));
            JObject testsJObject = JObject.Load(new JsonTextReader(new StringReader(System.IO.File.ReadAllText(args[0]))));
            List<Value> values = valuesJObject["values"].ToArray().Select(value => value.ToObject<Value>()).ToList();
            List<Test> tests = testsJObject["tests"].ToArray().Select(value => value.ToObject<Test>()).ToList();
            Dictionary<int, string> map = values.Distinct().ToDictionary(x => x.id, x => x.value);
            for (int i = 0; i < tests.Count; i++)
            {
                tests[i].value = map[tests[i].id];
                SetTestsValues(tests[i].values, map);
            }

            using (StreamWriter file = File.CreateText(@"report.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, tests);
            }

        }
    }
}