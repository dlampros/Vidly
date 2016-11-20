namespace Vidly.DataContexts.VidlyMigrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAvailableNumberToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));

            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }

        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Short(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
