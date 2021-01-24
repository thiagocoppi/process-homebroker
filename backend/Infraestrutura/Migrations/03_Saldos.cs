using FluentMigrator;

namespace Infraestrutura.Migrations
{
    [Migration(03)]
    [Tags("Production", "Development")]
    public class Saldos : BaseMigration
    {
        public override void Down()
        {
            Delete.Table("saldo");
            Delete.Table("lancamento");
        }

        public override void Up()
        {
            Create.Table("saldo").WithDescription("Armazena os saldos dos correntistas do homebroker")
                .WithColumn("id").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid).PrimaryKey().WithColumnDescription("Identificador único da tabela")
                .WithColumn("usuario_id").AsGuid().NotNullable().ForeignKey("usuario", "id")
                .WithColumn("saldo_atual").AsDecimal().NotNullable().WithColumnDescription("Saldo atual do correntista");

            Create.Table("lancamento").WithDescription("Armazena os lançamentos realizados pelo correntista")
                .WithColumn("id").AsGuid().NotNullable().WithDefault(SystemMethods.NewGuid).PrimaryKey().WithColumnDescription("Identificador único da tabela")
                .WithColumn("usuario_id").AsGuid().NotNullable().ForeignKey("usuario", "id").WithColumnDescription("Identificador único do usuário")
                .WithColumn("ordem_id").AsGuid().Nullable().ForeignKey("ordem", "id").WithColumnDescription("Identificador da ordem")
                .WithColumn("tipo_lancamento").AsString().NotNullable().WithColumnDescription("Tipo do lançamento (R - Retirada / C - Compra / V - Venda)")
                .WithColumn("data").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime).WithColumnDescription("Data/hora do lançamento");
        }
    }
}