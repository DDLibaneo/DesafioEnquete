namespace DesafioEnquete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsPollAndOption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OptionDescription = c.String(nullable: false, maxLength: 500),
                        Votes = c.Int(nullable: false),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poll", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Poll",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollDescription = c.String(nullable: false, maxLength: 700),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Option", "PollId", "dbo.Poll");
            DropIndex("dbo.Option", new[] { "PollId" });
            DropTable("dbo.Poll");
            DropTable("dbo.Option");
        }
    }
}
