namespace LibraryApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        VendorCode = c.String(),
                        YearOfPublication = c.DateTime(nullable: false),
                        Instances = c.Int(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssuedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuedDate = c.DateTime(nullable: false),
                        NameBook = c.Int(nullable: false),
                        Reader = c.Int(nullable: false),
                        DateOfDelivery = c.DateTime(nullable: false),
                        StatusIssuedBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reader = c.String(),
                        DateBirth = c.DateTime(nullable: false),
                        NumberPhone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Readers");
            DropTable("dbo.IssuedBooks");
            DropTable("dbo.Books");
        }
    }
}
