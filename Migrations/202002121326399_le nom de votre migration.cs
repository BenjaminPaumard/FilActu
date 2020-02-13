namespace FilActualite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lenomdevotremigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LienCategories", "Lien_Id", "dbo.Liens");
            DropForeignKey("dbo.LienCategories", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.LienCategories", new[] { "Lien_Id" });
            DropIndex("dbo.LienCategories", new[] { "Categorie_Id" });
            AddColumn("dbo.Liens", "CategorieId", c => c.Guid(nullable: false));
            AddColumn("dbo.Liens", "Categorie_Id", c => c.Guid());
            AddColumn("dbo.Liens", "Categorie_Id1", c => c.Guid());
            CreateIndex("dbo.Liens", "CategorieId");
            CreateIndex("dbo.Liens", "Categorie_Id");
            CreateIndex("dbo.Liens", "Categorie_Id1");
            AddForeignKey("dbo.Liens", "CategorieId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Liens", "Categorie_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Liens", "Categorie_Id1", "dbo.Categories", "Id");
            DropTable("dbo.LienCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LienCategories",
                c => new
                    {
                        Lien_Id = c.Guid(nullable: false),
                        Categorie_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lien_Id, t.Categorie_Id });
            
            DropForeignKey("dbo.Liens", "Categorie_Id1", "dbo.Categories");
            DropForeignKey("dbo.Liens", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Liens", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Liens", new[] { "Categorie_Id1" });
            DropIndex("dbo.Liens", new[] { "Categorie_Id" });
            DropIndex("dbo.Liens", new[] { "CategorieId" });
            DropColumn("dbo.Liens", "Categorie_Id1");
            DropColumn("dbo.Liens", "Categorie_Id");
            DropColumn("dbo.Liens", "CategorieId");
            CreateIndex("dbo.LienCategories", "Categorie_Id");
            CreateIndex("dbo.LienCategories", "Lien_Id");
            AddForeignKey("dbo.LienCategories", "Categorie_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LienCategories", "Lien_Id", "dbo.Liens", "Id", cascadeDelete: true);
        }
    }
}
