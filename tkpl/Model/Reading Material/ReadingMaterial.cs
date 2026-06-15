using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.Reading_Material
{
    public class ReadingMaterial
    {
        public int Reading_Material_ID { get; set; }
        public int Module_ID { get; set; } 
        public string title { get; set; }
        public string string_material { get; set; }

        public ReadingMaterial() { }

        public ReadingMaterial(int id, int moduleId, string title, string material)
        {
            Reading_Material_ID = id;
            Module_ID = moduleId;
            this.title = title;
            string_material = material;
        }
    }
}
