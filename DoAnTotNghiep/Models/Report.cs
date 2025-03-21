namespace DoAnTotNghiep.Models
{
    using DoAnTotNghiep.Models.BaseEntities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /*public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-Increment
        public int ReportID { get; set; }

        [Required]
        public ReportType ReportType { get; set; }  // Enum loại báo cáo

        [Required]
        public string ReportContent { get; set; }  // Nội dung báo cáo

        [Required]
        public DateTime GeneratedDate { get; set; } = DateTime.Now;  // Ngày tạo báo cáo
    }

    // Enum loại báo cáo
    public enum ReportType
    {
        Daily,
        Weekly,
        Monthly,
        Annual
    }*/
    public class Report:BaseEntity
    {
        
        [Required]
        [EnumDataType(typeof(ReportTypeEnum))]
        public ReportTypeEnum ReportType { get; set; }

        [Required]
        public string ReportContent { get; set; }

        [Required]
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }

    public enum ReportTypeEnum
    {
        Daily,
        Weekly,
        Monthly,
        Annual,
        Summary
    }
}
