using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class UploadedFile
    {
        [Key]
        public int FileId { get; set; } // Primary key

        [Required]
        public string FileName { get; set; } // Name of the file

        [Required]
        public string ContentType { get; set; } // Type of file, e.g., image/png

        [Required]
        public byte[] Content { get; set; } // File content stored as byte array

        public DateTime UploadDate { get; set; } = DateTime.Now; // Timestamp of upload
    }
}