namespace FilActualite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Liens", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Liens", "Categorie_Id1", "dbo.Categories");
            DropIndex("dbo.Liens", new[] { "Categorie_Id" });
            DropIndex("dbo.Liens", new[] { "Categorie_Id1" });
            DropColumn("dbo.Liens", "Categorie_Id");
            DropColumn("dbo.Liens", "Categorie_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Liens", "Categorie_Id1", c => c.Guid());
            AddColumn("dbo.Liens", "Categorie_Id", c => c.Guid());
            CreateIndex("dbo.Liens", "Categorie_Id1");
            CreateIndex("dbo.Liens", "Categorie_Id");
            AddForeignKey("dbo.Liens", "Categorie_Id1", "dbo.Categories", "Id");
            AddForeignKey("dbo.Liens", "Categorie_Id", "dbo.Categories", "Id");
        }
    }
}
