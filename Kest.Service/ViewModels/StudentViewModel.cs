//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Text;

//namespace Kest.Application.ViewModels
//{
//    /// <summary>
//    /// 子领域 Student 的试图模型
//    /// </summary>
//    public class StudentViewModel
//    {
//        [Key]
//        public Guid Id { get; set; }

//        [Required(ErrorMessage = "The Name is Required")]
//        [MinLength(2)]
//        [MaxLength(100)]
//        [DisplayName("Name")]
//        public string Name { get; set; }

//        [Required(ErrorMessage = "The Email is Required")]
//        [EmailAddress]
//        [DisplayName("E-mail")]
//        public string Email { get; set; }
        
//    }
//}
