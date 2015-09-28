using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BareKnuckleJson {
    
    public static class Json {
        
        public static string Serialize(Object g){
            
            using(var sw = new StringWriter()){
                InnerSerialize(g, sw);
                return sw.ToString();
            }
            
        }
        
        static void InnerSerialize(Object g, StringWriter sw){

            if (g == null)
            {
              sw.Write("null");
              return;
            }

            var valueType = g as ValueType;

            if (valueType != null)
            {
                sw.Write(valueType);
                return;
            }
        
            var stringType = g as String;
        
            if (stringType != null)
            {
                sw.Write("\"" + stringType + "\"");
                return;
            }
            
            var enumerable = g as IEnumerable;
                
            if (enumerable != null)
            {
                var count = 0;
                sw.Write("[");
                
                foreach (var item in enumerable)
                {
                    if (count++ > 0){
                        sw.Write(", ");
                    }
                    InnerSerialize(item, sw);
                }
                sw.Write("]");
                return;
            }
            
            sw.Write("{");
            var pcount = 0;
            var type = g.GetType();
        
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (pcount++ > 0){
                    sw.Write(", ");
                }
                string name = propertyInfo.Name;
                dynamic val = propertyInfo.GetValue(g, null);
                sw.Write("\""+name+"\":");
                InnerSerialize(val, sw);
            }
            
            sw.Write("}");
    
        }
    }
}
