using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    public class ReadingMaterial
    {
        [Table("reading_material")]
        public class ReadingMaterialModels
        {
            [Key]
            public int Reading_Material_ID { get; set; }
            public int? Module_ID { get; set; }

            [Column("title")]
            public string? Title { get; set; }

            [Column("string_material")]
            public string? String_Material { get; set; }

            [JsonIgnore]
            [ForeignKey("Module_ID")]
            public ModuleModels? Module { get; set; }

            public List<ReadingMaterialImageModels> Images { get; set; } = new List<ReadingMaterialImageModels>();
        }

        [Table("reading_material_image")]
        public class ReadingMaterialImageModels
        {
            [Key]
            public int Reading_Material_Image_ID { get; set; }
            public int? Reading_Material_ID { get; set; }

            [Column("image_url")]
            public string? Image_Url { get; set; }

            [JsonIgnore]
            [ForeignKey("Reading_Material_ID")]
            public ReadingMaterialModels? ReadingMaterial { get; set; }
        }
    }
}
