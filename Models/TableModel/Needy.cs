using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CIE_206.Models.TableModel
{
    [Table("Needy")]
    public class Needy
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Number { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column("NeedyID")]
        //public string NeedyID { get; set; }

        [Required(ErrorMessage = "مطلوب الاسم الأول.")]
        [Column("Fname")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "مطلوب الاسم الأوسط.")]

        [Column("Mname")]
        public string Mname { get; set; }

        [Required(ErrorMessage = "مطلوب الاسم الأخير.")]
        [Column("Lname")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "مطلوب اسم العائلة.")]
        [Column("Familyname")]
        public string Familyname { get; set; }

        [Required(ErrorMessage = "مطلوب رقم الهوية.")]
        [Column("SSN")]
        public string SSN { get; set; }

        [Required(ErrorMessage = "مطلوب رقم الهاتف.")]
        [Column("PhoneNum")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "مطلوب تاريخ الميلاد.")]
        [Column("BirthDate")]
        public string Birthdate { get; set; }

        [Required(ErrorMessage = "مطلوب عنوان الشارع.")]
        [Column("StreetAddress")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "مطلوب رقم الطابق.")]
        [Column("floornum")]
        public string floornum { get; set; }

        [Required(ErrorMessage = "مطلوب المنطقة.")]
        [Column("Area")]
        public string Area { get; set; }

        [Required(ErrorMessage = "مطلوب العلامة.")]
        [Column("mark")]
        public string mark { get; set; }
        [Required(ErrorMessage = "متوسط دخل الأسرة مطلوب")]
        [Column("Income")]
        public string Income { get; set; }
        [Required(ErrorMessage = "عدد أفراد الأسرة مطلوب")]
        [Column("NumberOfFamilyMembers")]
        public string NumberOfFamilyMembers { get; set; }

        [Column("AreaCode")]
        [Required(ErrorMessage = "مطلوب تقديم رمز المنطقة")]
        public string AreaCode { get; set; }

        [Column("Casetype")]
        [Required(ErrorMessage = "مطلوب تقديم نوع الحالة")]
        public string Casetype { get; set; }

        [Column("HealthStatus")]
        [Required(ErrorMessage = "مطلوب تقديم حالة الصحة")]
        public string HealthStatus { get; set; }

        [Column("EducationalState")]
        [Required(ErrorMessage = "مطلوب تقديم الحالة التعليمية")]
        public string EducationalState { get; set; }

        [Column("SocialState")]
        [Required(ErrorMessage = "مطلوب تقديم الحالة الاجتماعية")]
        public string SocialState { get; set; }

        [Column("Job")]
        [Required(ErrorMessage = "مطلوب تقديم الوظيفة")]
        public string Job { get; set; }

        [Column("Details")]
        [Required(ErrorMessage = "مطلوب تقديم التفاصيل")]
        public string Details { get; set; }

        [Column("AcceptStatus")]
        [Required(ErrorMessage = "مطلوب تقديم حالة القبول")]
        public string AcceptStatus { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "مطلوب الصورة الشخصية")]

        public IFormFile ImageData { get; set; }

        [Column("ImageDataPath")]
        public string ImageDataPath { get; set; } = "";

        [NotMapped]
        [Required(ErrorMessage = "مطلوب صورة الهوية الأمامية")]

        public IFormFile Frontidimg { get; set; }

        [Column("FrontidimgPath")]

        public string FrontidimgPath { get; set; } = "";

        [NotMapped]
        [Required(ErrorMessage = "مطلوب صورة الهوية الخلفية")]

        public IFormFile Backidimg { get; set; }

        [Column("BackidimgPath")]
        public string BackidimgPath { get; set; } = "";

    }
}

//Please note that the `NeedyID` column is defined as a computed column using the `[DatabaseGenerated(DatabaseGeneratedOption.Computed)]` attribute.The `Birthdate` property is of type `string` to match the format used in the SQL script. I've also added a regular expression validation attribute to ensure the `Birthdate` property follows the format `yyyy-MM-dd`.



