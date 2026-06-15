using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.Reading_Material
{
    public class MateriImageTable
    {
        public int Reading_Material_Image_ID { get; set; }
        public int Reading_Material_ID { get; set; }
        public string image_url { get; set; }
        public MateriImageTable() { }
        public MateriImageTable(int id, int readingMaterialId, string imageUrl)
        {
            Reading_Material_Image_ID = id;
            Reading_Material_ID = readingMaterialId;
            image_url = imageUrl;
        }
    }
}
