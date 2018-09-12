using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecycleAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(maxLength: 128, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IsAdministrator = table.Column<bool>(nullable: false),
                    AllowDuplicateOrderNumbers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    APIKeyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(maxLength: 36, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: true),
                    LastName = table.Column<string>(maxLength: 64, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 128, nullable: true),
                    VendorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.APIKeyId);
                    table.ForeignKey(
                        name: "FK_Keys_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<string>(maxLength: 36, nullable: true),
                    OrderNumber = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    AccountName = table.Column<string>(maxLength: 128, nullable: true),
                    ContactLastName = table.Column<string>(maxLength: 64, nullable: false),
                    ContactFirstName = table.Column<string>(maxLength: 64, nullable: true),
                    ContactEmail = table.Column<string>(maxLength: 128, nullable: true),
                    ContactPhone = table.Column<string>(maxLength: 32, nullable: true),
                    Address1 = table.Column<string>(maxLength: 64, nullable: false),
                    Address2 = table.Column<string>(maxLength: 64, nullable: true),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    State = table.Column<string>(maxLength: 64, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 24, nullable: false),
                    Country = table.Column<string>(maxLength: 64, nullable: false),
                    Reference1 = table.Column<string>(maxLength: 128, nullable: true),
                    Reference2 = table.Column<string>(maxLength: 128, nullable: true),
                    ProgramInfoId = table.Column<string>(maxLength: 12, nullable: false),
                    VendorId = table.Column<int>(nullable: true),
                    NumberOfBatteries = table.Column<int>(nullable: false),
                    KitQuantity = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: false),
                    OrderStatusDate = table.Column<DateTime>(nullable: false),
                    OrderTrackingNumber = table.Column<string>(maxLength: 64, nullable: true),
                    ReciptTrackingNumber = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keys_VendorId",
                table: "Keys",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VendorId",
                table: "Orders",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
