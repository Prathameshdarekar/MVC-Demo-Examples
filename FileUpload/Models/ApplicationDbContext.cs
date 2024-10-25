using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace FileUpload.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<UploadedFile> UploadedFiles { get; set; } // Add DbSet for UploadedFile

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}