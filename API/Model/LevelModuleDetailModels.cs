using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("level_module_detail")]
    public class LevelModuleDetailModels
    {
        [Key]
        public int Detail_ID { get; set; }

        public int? Module_ID { get; set; }
        public int? Level_ID { get; set; }

        [ForeignKey("Module_ID")]
        public ModuleModels? Module { get; set; }

        [ForeignKey("Level_ID")]
        public LevelModels? Level { get; set; }
    }
}