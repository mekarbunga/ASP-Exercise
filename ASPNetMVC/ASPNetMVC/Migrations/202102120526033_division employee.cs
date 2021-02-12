namespace ASPNetMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class divisionemployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Tb_M_Division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tb_M_Employee", "Account_Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tb_M_Employee", "Division_Id", c => c.Int());
            AlterColumn("dbo.Tb_M_Employee", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Tb_M_Employee", "Account_Email");
            CreateIndex("dbo.Tb_M_Employee", "Division_Id");
            AddForeignKey("dbo.Tb_M_Employee", "Account_Email", "dbo.Tb_M_Account", "Email");
            AddForeignKey("dbo.Tb_M_Employee", "Division_Id", "dbo.Tb_M_Division", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Employee", "Division_Id", "dbo.Tb_M_Division");
            DropForeignKey("dbo.Tb_M_Employee", "Account_Email", "dbo.Tb_M_Account");
            DropIndex("dbo.Tb_M_Employee", new[] { "Division_Id" });
            DropIndex("dbo.Tb_M_Employee", new[] { "Account_Email" });
            AlterColumn("dbo.Tb_M_Employee", "Email", c => c.String());
            DropColumn("dbo.Tb_M_Employee", "Division_Id");
            DropColumn("dbo.Tb_M_Employee", "Account_Email");
            DropTable("dbo.Tb_M_Division");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
