using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    IdProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.IdProfile);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    IdPurchaseOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReqShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerPO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.IdPurchaseOrder);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfile = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profiles",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetails",
                columns: table => new
                {
                    IdPurchaseOrderDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPurchaseOrder = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ordered = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetails", x => x.IdPurchaseOrderDetail);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetails_PurchaseOrders_IdPurchaseOrder",
                        column: x => x.IdPurchaseOrder,
                        principalTable: "PurchaseOrders",
                        principalColumn: "IdPurchaseOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingStatusLogs",
                columns: table => new
                {
                    IdTrackingStatusLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPurchaseOrder = table.Column<int>(type: "int", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PalletNumber = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedBy = table.Column<int>(type: "int", nullable: true),
                    EditedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingStatusLogs", x => x.IdTrackingStatusLog);
                    table.ForeignKey(
                        name: "FK_TrackingStatusLogs_PurchaseOrders_IdPurchaseOrder",
                        column: x => x.IdPurchaseOrder,
                        principalTable: "PurchaseOrders",
                        principalColumn: "IdPurchaseOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderStatusLogs",
                columns: table => new
                {
                    IdPurchaseOrderStatusLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPurchaseOrder = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderStatusLogs", x => x.IdPurchaseOrderStatusLog);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderStatusLogs_PurchaseOrders_IdPurchaseOrder",
                        column: x => x.IdPurchaseOrder,
                        principalTable: "PurchaseOrders",
                        principalColumn: "IdPurchaseOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderStatusLogs_Status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderStatusLogs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trackings",
                columns: table => new
                {
                    IdTracking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPurchaseOrderDetail = table.Column<int>(type: "int", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PalletNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    BedNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ReviewedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackings", x => x.IdTracking);
                    table.ForeignKey(
                        name: "FK_Trackings_PurchaseOrderDetails_IdPurchaseOrderDetail",
                        column: x => x.IdPurchaseOrderDetail,
                        principalTable: "PurchaseOrderDetails",
                        principalColumn: "IdPurchaseOrderDetail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "IdProfile", "CreatedAt", "CreatedBy", "EditedAt", "EditedBy", "IsActive", "ProfileName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8212), 0, null, null, true, "Administrador" },
                    { 2, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8216), 0, null, null, true, "Super Usuario" },
                    { 3, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8217), 0, null, null, true, "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "IdStatus", "CreatedAt", "CreatedBy", "Description", "EditedAt", "EditedBy", "IsActive", "StatusName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8352), 0, "Orden Importada desde un archivo .csv, sin tener ningún Item escaneado.", null, null, true, "Creada" },
                    { 2, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8353), 0, "Orden que ha comenzado con el proceso de escaneo de sus Items.", null, null, true, "En Proceso" },
                    { 3, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8354), 0, "Orden con todos los Items escaneados correctamente.", null, null, true, "Completada" },
                    { 4, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8355), 0, "Orden con algunos Items faltantes, que pudiese ser enviada.", null, null, true, "Incompleta" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "CreatedAt", "CreatedBy", "EditedAt", "EditedBy", "Email", "FirstName", "HashPassword", "IdProfile", "IsActive", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8309), 0, null, null, "admin@example.com", "Administrador", "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97", 1, true, "Sistema", "admin" },
                    { 2, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8311), 0, null, null, "gerardo.martinez@drivespro.com", "Gerardo", "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97", 1, true, "Martinez Briones", "gerardo.martinez" },
                    { 3, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8312), 0, null, null, "victor.luna@drivespro.com", "Victor", "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97", 1, true, "Luna Narvaez", "victor.luna" },
                    { 4, new DateTime(2024, 7, 7, 21, 11, 31, 561, DateTimeKind.Local).AddTicks(8313), 0, null, null, "israel.salas@drivespro.com", "Israel", "46708f23d682fef9aa996ecbb139bfb6c9ffdc039905ad6ad5c85a88b9411d97", 1, true, "Salas", "israel.salas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_IdPurchaseOrder",
                table: "PurchaseOrderDetails",
                column: "IdPurchaseOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderStatusLogs_IdPurchaseOrder",
                table: "PurchaseOrderStatusLogs",
                column: "IdPurchaseOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderStatusLogs_IdStatus",
                table: "PurchaseOrderStatusLogs",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderStatusLogs_IdUser",
                table: "PurchaseOrderStatusLogs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_IdPurchaseOrderDetail",
                table: "Trackings",
                column: "IdPurchaseOrderDetail");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingStatusLogs_IdPurchaseOrder",
                table: "TrackingStatusLogs",
                column: "IdPurchaseOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfile",
                table: "Users",
                column: "IdProfile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderStatusLogs");

            migrationBuilder.DropTable(
                name: "Trackings");

            migrationBuilder.DropTable(
                name: "TrackingStatusLogs");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");
        }
    }
}
