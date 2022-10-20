using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMarket.Infrastructure.Persistence.Migrations
{
    public partial class _4thimageslotaddedtophotosentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "AdvertisesPhotos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image4",
                table: "AdvertisesPhotos");
        }
    }
}
