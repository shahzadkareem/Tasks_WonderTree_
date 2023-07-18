namespace TasksProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class STuCorData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student_Course_Result",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Stu_ID = c.Int(nullable: false),
                        Cours_ID = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Cours_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Stu_ID, cascadeDelete: true)
                .Index(t => t.Stu_ID)
                .Index(t => t.Cours_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student_Course_Result", "Stu_ID", "dbo.Students");
            DropForeignKey("dbo.Student_Course_Result", "Cours_ID", "dbo.Courses");
            DropIndex("dbo.Student_Course_Result", new[] { "Cours_ID" });
            DropIndex("dbo.Student_Course_Result", new[] { "Stu_ID" });
            DropTable("dbo.Student_Course_Result");
        }
    }
}
