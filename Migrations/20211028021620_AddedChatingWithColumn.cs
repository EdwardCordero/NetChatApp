// using Microsoft.EntityFrameworkCore.Migrations;

// namespace NetChatApp.Migrations
// {
//     public partial class AddedChatingWithColumn : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.AddColumn<string>(
//                 name: "ChatingWithId",
//                 table: "UserChats",
//                 type: "varchar(767)",
//                 nullable: true);

//             migrationBuilder.CreateIndex(
//                 name: "IX_UserChats_ChatingWithId",
//                 table: "UserChats",
//                 column: "ChatingWithId");

//             migrationBuilder.AddForeignKey(
//                 name: "FK_UserChats_AspNetUsers_ChatingWithId",
//                 table: "UserChats",
//                 column: "ChatingWithId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Restrict);
//         }

//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_UserChats_AspNetUsers_ChatingWithId",
//                 table: "UserChats");

//             migrationBuilder.DropIndex(
//                 name: "IX_UserChats_ChatingWithId",
//                 table: "UserChats");

//             migrationBuilder.DropColumn(
//                 name: "ChatingWithId",
//                 table: "UserChats");
//         }
//     }
// }
