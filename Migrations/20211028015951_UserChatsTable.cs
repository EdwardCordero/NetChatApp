// using System;
// using Microsoft.EntityFrameworkCore.Migrations;

// namespace NetChatApp.Migrations
// {
//     public partial class UserChatsTable : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "UserChats",
//                 columns: table => new
//                 {
//                     ChatId = table.Column<string>(type: "varchar(767)", nullable: false),
//                     UserId = table.Column<string>(type: "varchar(767)", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_UserChats", x => x.ChatId);
//                     table.ForeignKey(
//                         name: "FK_UserChats_AspNetUsers_UserId",
//                         column: x => x.UserId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "ChatEntity",
//                 columns: table => new
//                 {
//                     ChatId = table.Column<string>(type: "varchar(767)", nullable: false),
//                     ChatText = table.Column<string>(type: "text", nullable: true),
//                     ReciverId = table.Column<string>(type: "varchar(767)", nullable: true),
//                     SenderId = table.Column<string>(type: "varchar(767)", nullable: true),
//                     Date = table.Column<DateTime>(type: "datetime", nullable: false),
//                     UserChatsEntityChatId = table.Column<string>(type: "varchar(767)", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_ChatEntity", x => x.ChatId);
//                     table.ForeignKey(
//                         name: "FK_ChatEntity_AspNetUsers_ReciverId",
//                         column: x => x.ReciverId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_ChatEntity_AspNetUsers_SenderId",
//                         column: x => x.SenderId,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Restrict);
//                     table.ForeignKey(
//                         name: "FK_ChatEntity_UserChats_UserChatsEntityChatId",
//                         column: x => x.UserChatsEntityChatId,
//                         principalTable: "UserChats",
//                         principalColumn: "ChatId",
//                         onDelete: ReferentialAction.Restrict);
//                 });

//             migrationBuilder.CreateIndex(
//                 name: "IX_ChatEntity_ReciverId",
//                 table: "ChatEntity",
//                 column: "ReciverId");

//             migrationBuilder.CreateIndex(
//                 name: "IX_ChatEntity_SenderId",
//                 table: "ChatEntity",
//                 column: "SenderId");

//             migrationBuilder.CreateIndex(
//                 name: "IX_ChatEntity_UserChatsEntityChatId",
//                 table: "ChatEntity",
//                 column: "UserChatsEntityChatId");

//             migrationBuilder.CreateIndex(
//                 name: "IX_UserChats_UserId",
//                 table: "UserChats",
//                 column: "UserId");
//         }

//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "ChatEntity");

//             migrationBuilder.DropTable(
//                 name: "UserChats");
//         }
//     }
// }
