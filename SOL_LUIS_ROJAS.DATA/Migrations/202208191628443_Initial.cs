namespace SOL_LUIS_ROJAS.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookLoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanDate = c.DateTime(nullable: false),
                        LoanPurpose = c.String(),
                        ReturnDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(),
                        Name = c.String(),
                        Category = c.String(),
                        Author = c.String(),
                        Country = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DNI = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Status = c.Boolean(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLoans", "UserId", "dbo.Users");
            DropForeignKey("dbo.BookLoans", "BookId", "dbo.Books");
            DropIndex("dbo.BookLoans", new[] { "UserId" });
            DropIndex("dbo.BookLoans", new[] { "BookId" });
            DropTable("dbo.Users");
            DropTable("dbo.Books");
            DropTable("dbo.BookLoans");
        }
    }
}
