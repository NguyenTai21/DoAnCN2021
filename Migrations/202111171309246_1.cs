namespace DoAnCN2021.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ListCoursTCs", newName: "ListCourseTCs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ListCourseTCs", newName: "ListCoursTCs");
        }
    }
}
