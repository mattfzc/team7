namespace team7WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        InquirerID = c.Int(nullable: false),
                        DeptID = c.Int(nullable: false),
                        LiasonID = c.Int(nullable: false),
                        MeetTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HasInquiererAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
