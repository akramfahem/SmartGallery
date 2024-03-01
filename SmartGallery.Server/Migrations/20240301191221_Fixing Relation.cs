using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartGallery.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reservations_ReservationId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "502969b9-84d9-409f-829e-4e4ee8fe5632");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4ae77f72-6594-4d29-b058-cdb97e7674fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "105e956e-4642-4132-a959-e9e60b0c7c5e", "0f2d3970-b86a-4c44-b5be-01531d6272bc", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f6af32-7aa0-4f7f-b3b3-2c339a5544ad", "AQAAAAIAAYagAAAAEGoU+4X0ZJDnH9mSaqRqgsyzGScujOB0AdPldK94+6f8dw5oladzTMxmJ7okbUF0Ag==", "2c89eca6-3e3f-4916-89c1-5b8f5262992a" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reservations_ReservationId",
                table: "Reviews",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reservations_ReservationId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "105e956e-4642-4132-a959-e9e60b0c7c5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "729a813e-948c-4b63-b90b-e4c4f8fdd927");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "502969b9-84d9-409f-829e-4e4ee8fe5632", "f7b22742-bf1b-494d-8946-241db90837a9", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd0d3393-2b58-456b-9c19-c23add916953", "AQAAAAIAAYagAAAAELKIL4UN9SmVhK18SilqA4mAgEfed6E+Jvzdqz2S/VLkWr/5MNbumEKCyygE8uODSw==", "0bd91391-580d-4721-88aa-f6a21c7bbaf8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reservations_ReservationId",
                table: "Reviews",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
