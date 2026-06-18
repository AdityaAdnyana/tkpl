using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("level_module_detail")]
    public class LevelModuleDetailModels
    {
        [Key]
        [Column("Detail_ID")]
        public int DetailId { get; set; }

        [Column("Module_ID")]
        public int ModuleId { get; set; }

        [Column("Level_ID")]
        public int LevelId { get; set; }

        public ModuleModels? Module { get; set; }
        public LevelModels? Level { get; set; }
    }
}
