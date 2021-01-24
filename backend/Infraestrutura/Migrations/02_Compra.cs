using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration(02)]
    [Tags("Production", "Development")]
    public class Compra : BaseMigration
    {
        public override void Down()
        {
            Delete.Table("ordem");
        }

        public override void Up()
        {
            Create.Table("ordem").WithDescription("Tabela onde é armazenado todas as ordens emitidas pelos clientes dentro da plataforma")
                .WithColumn("id").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid).PrimaryKey().WithColumnDescription("Identificador único da tabela")
                .WithColumn("data").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime).WithColumnDescription("Data/Hora da execução da ordem")
                .WithColumn("preco").AsDecimal().NotNullable().WithColumnDescription("Preço que foi pago unitariamente pela ação")
                .WithColumn("quantidade").AsInt32().NotNullable().WithColumnDescription("Quantidade de ativos que foi comprado")
                .WithColumn("codigo").AsString().NotNullable().WithColumnDescription("Código do ativo que foi comprado")
                .WithColumn("valor_total").AsDecimal().NotNullable().WithColumnDescription("Valor total da ordem (Quantidade x Valor)")
                .WithColumn("usuario_id").AsGuid().NotNullable().ForeignKey("usuario", "id");
        }
    }
}