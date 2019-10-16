namespace ProjectManagerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeindatabases : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskDescription", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskDescription", c => c.String(nullable: false, maxLength: 300, unicode: false));
        }
    }
}
