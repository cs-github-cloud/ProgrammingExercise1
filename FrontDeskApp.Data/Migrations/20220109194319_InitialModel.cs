using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontDeskApp.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerLastName = table.Column<string>(maxLength: 100, nullable: false),
                    CustomerFirstName = table.Column<string>(maxLength: 100, nullable: false),
                    CustomerPhoneNumer = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "StorageFacility",
                columns: table => new
                {
                    StorageFacilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageType = table.Column<string>(maxLength: 20, nullable: false),
                    FacilityId = table.Column<int>(nullable: false),
                    SlotCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageFacility", x => x.StorageFacilityId);
                    table.ForeignKey(
                        name: "FK_StorageFacility_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageFacilityId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    StorageStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storage_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storage_StorageFacility_StorageFacilityId",
                        column: x => x.StorageFacilityId,
                        principalTable: "StorageFacility",
                        principalColumn: "StorageFacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "FacilityId", "FacilityName" },
                values: new object[] { 1, "Facility 1" });

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "FacilityId", "FacilityName" },
                values: new object[] { 2, "Facility 2" });

            migrationBuilder.InsertData(
                table: "Facility",
                columns: new[] { "FacilityId", "FacilityName" },
                values: new object[] { 3, "Facility 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Storage_CustomerId",
                table: "Storage",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_StorageFacilityId",
                table: "Storage",
                column: "StorageFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageFacility_FacilityId",
                table: "StorageFacility",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "StorageFacility");

            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
