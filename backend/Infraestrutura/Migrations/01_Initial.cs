using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration(01)]
    [Tags("Production", "Development")]
    public class Initial : BaseMigration
    {
        public override void Down()
        {
            Delete.Table("usuario");
        }

        public override void Up()
        {
            Execute.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
            Create.Table("usuario").WithDescription("Tabela que contém as contas dos correntistas")
                .WithColumn("id").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid).PrimaryKey().WithColumnDescription("Identificador único da tabela")
                .WithColumn("nome").AsString().NotNullable().WithColumnDescription("Nome do usuário")
                .WithColumn("senha").AsString().NotNullable().WithColumnDescription("Senha do usuário")
                .WithColumn("senha_transacao").AsString().NotNullable().WithColumnDescription("Senha das transações eletrônicas")
                .WithColumn("email").AsString().NotNullable().WithColumnDescription("Email do usuário")
                .WithColumn("cpf").AsString().NotNullable().WithColumnDescription("CPF do usuário")
                .WithColumn("celular").AsString().NotNullable().WithColumnDescription("Celular do usuário")
                .WithColumn("dtnascimento").AsDate().NotNullable().WithColumnDescription("Data de nascimento");
        }
    }
}