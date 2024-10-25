namespace FileUpload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUploadedFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadedFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        ContentType = c.String(nullable: false),
                        Content = c.Binary(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadedFiles");
        }
    }
}
