namespace modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Nombre = c.String(),
                        Usuario_Id = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tratamientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        img_url = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                        Usuario_Doctor = c.String(),
                        Usuario_Paciente = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Documento = c.Int(nullable: false),
                        Fecha_nac = c.DateTime(nullable: false),
                        Nombre_usuario = c.String(),
                        password = c.String(),
                        tratamiento_Id = c.Int(nullable: false),
                        Rol_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tratamientoes");
            DropTable("dbo.Imagens");
        }
    }
}
