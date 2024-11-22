using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace MarkSetBotAlpha.Module.MarkSetBotWWW.Migrations.EntityBuilders
{
    public class MarkSetBotWWWEntityBuilder : AuditableBaseEntityBuilder<MarkSetBotWWWEntityBuilder>
    {
        private const string _entityTableName = "MarkSetBotAlphaMarkSetBotWWW";
        private readonly PrimaryKey<MarkSetBotWWWEntityBuilder> _primaryKey = new("PK_MarkSetBotAlphaMarkSetBotWWW", x => x.MarkSetBotWWWId);
        private readonly ForeignKey<MarkSetBotWWWEntityBuilder> _moduleForeignKey = new("FK_MarkSetBotAlphaMarkSetBotWWW_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public MarkSetBotWWWEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override MarkSetBotWWWEntityBuilder BuildTable(ColumnsBuilder table)
        {
            MarkSetBotWWWId = AddAutoIncrementColumn(table,"MarkSetBotWWWId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> MarkSetBotWWWId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
