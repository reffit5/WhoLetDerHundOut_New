 using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breed",
                c => new
                    {
                        BreedId = c.Int(nullable: false, identity: true),
                        BreedName = c.String(maxLength: 20),
                        Country = c.String(maxLength: 30),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.BreedId);
            
            CreateTable(
                "dbo.DogInfo",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NickName = c.String(maxLength: 20),
                        Breed = c.String(nullable: false),
                        BreedId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        NumberofDogs = c.Int(nullable: false),
                        DogId = c.Int(nullable: false),
                        junk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DogBreed",
                c => new
                    {
                        Dog_DogId = c.Int(nullable: false),
                        Breed_BreedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dog_DogId, t.Breed_BreedId })
                .ForeignKey("dbo.DogInfo", t => t.Dog_DogId, cascadeDelete: true)
                .ForeignKey("dbo.Breed", t => t.Breed_BreedId, cascadeDelete: true)
                .Index(t => t.Dog_DogId)
                .Index(t => t.Breed_BreedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogInfo", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.DogBreed", "Breed_BreedId", "dbo.Breed");
            DropForeignKey("dbo.DogBreed", "Dog_DogId", "dbo.DogInfo");
            DropIndex("dbo.DogBreed", new[] { "Breed_BreedId" });
            DropIndex("dbo.DogBreed", new[] { "Dog_DogId" });
            DropIndex("dbo.DogInfo", new[] { "Users_Id" });
            DropTable("dbo.DogBreed");
            DropTable("dbo.Users");
            DropTable("dbo.DogInfo");
            DropTable("dbo.Breed");
        }
    }

