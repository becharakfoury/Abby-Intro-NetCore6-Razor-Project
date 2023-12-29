using System.ComponentModel.DataAnnotations;

namespace Abyweb.Model
{
    public class Category
    {
        [Key]// optionanl because its name is Id
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name="Display Order")]
        [Range(1, 50, ErrorMessage ="Dispaly cannot be greater then 50")]
        public int DisplayOrder { get; set; }


    }
}
